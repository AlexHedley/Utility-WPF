using System.Text;

using Utility_WPF.Services.Interfaces;

namespace Utility_WPF.Services
{
    /// <summary>
    /// JSON Service
    /// </summary>
    public class JSONService : IJSONService
    {
        /// <inheritdoc />
        public string PrettyJSON(string json) 
        {
            return new JsonFormatter(json).Format();
        }

        #region Helpers

        // Simple JSON .NET formatter
        // https://www.limilabs.com/blog/json-net-formatter

        /// <summary>
        /// String Walker
        /// </summary>
        public class StringWalker
        {
            private readonly string _s;

            public int Index { get; private set; }
            public bool IsEscaped { get; private set; }
            public char CurrentChar { get; private set; }

            public StringWalker(string s)
            {
                _s = s;
                this.Index = -1;
            }

            public bool MoveNext()
            {
                if (this.Index == _s.Length - 1)
                    return false;

                if (IsEscaped == false)
                    IsEscaped = CurrentChar == '\\';
                else
                    IsEscaped = false;
                this.Index++;
                CurrentChar = _s[Index];
                return true;
            }
        };

        /// <summary>
        /// Indent Writer
        /// </summary>
        public class IndentWriter
        {
            private readonly StringBuilder _result = new StringBuilder();
            private int _indentLevel;

            public void Indent()
            {
                _indentLevel++;
            }

            public void UnIndent()
            {
                if (_indentLevel > 0)
                    _indentLevel--;
            }

            public void WriteLine(string line)
            {
                _result.AppendLine(CreateIndent() + line);
            }

            private string CreateIndent()
            {
                StringBuilder indent = new StringBuilder();
                for (int i = 0; i < _indentLevel; i++)
                    indent.Append("    ");
                return indent.ToString();
            }

            public override string ToString()
            {
                return _result.ToString();
            }
        };

        /// <summary>
        /// Json Formatter
        /// </summary>
        public class JsonFormatter
        {
            private readonly StringWalker _walker;
            private readonly IndentWriter _writer = new IndentWriter();
            private readonly StringBuilder _currentLine = new StringBuilder();
            private bool _quoted;

            public JsonFormatter(string json)
            {
                _walker = new StringWalker(json);
                ResetLine();
            }

            public void ResetLine()
            {
                _currentLine.Length = 0;
            }

            public string Format()
            {
                while (MoveNextChar())
                {
                    if (this._quoted == false && this.IsOpenBracket())
                    {
                        this.WriteCurrentLine();
                        this.AddCharToLine();
                        this.WriteCurrentLine();
                        _writer.Indent();
                    }
                    else if (this._quoted == false && this.IsCloseBracket())
                    {
                        this.WriteCurrentLine();
                        _writer.UnIndent();
                        this.AddCharToLine();
                    }
                    else if (this._quoted == false && this.IsColon())
                    {
                        this.AddCharToLine();
                        this.WriteCurrentLine();
                    }
                    else
                    {
                        AddCharToLine();
                    }
                }
                this.WriteCurrentLine();
                return _writer.ToString();
            }

            private bool MoveNextChar()
            {
                bool success = _walker.MoveNext();
                if (this.IsApostrophe())
                {
                    this._quoted = !_quoted;
                }
                return success;
            }

            public bool IsApostrophe()
            {
                return this._walker.CurrentChar == '"' && this._walker.IsEscaped == false;
            }

            public bool IsOpenBracket()
            {
                return this._walker.CurrentChar == '{'
                    || this._walker.CurrentChar == '[';
            }

            public bool IsCloseBracket()
            {
                return this._walker.CurrentChar == '}'
                    || this._walker.CurrentChar == ']';
            }

            public bool IsColon()
            {
                return this._walker.CurrentChar == ',';
            }

            private void AddCharToLine()
            {
                this._currentLine.Append(_walker.CurrentChar);
            }

            private void WriteCurrentLine()
            {
                string line = this._currentLine.ToString().Trim();
                if (line.Length > 0)
                {
                    _writer.WriteLine(line);
                }
                this.ResetLine();
            }
        };

        #endregion Helpers
    }
}
