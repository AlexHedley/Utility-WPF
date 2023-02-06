using PoorMansTSqlFormatterLib.Formatters;
using PoorMansTSqlFormatterLib.Interfaces;
using PoorMansTSqlFormatterLib.Parsers;
using PoorMansTSqlFormatterLib.Tokenizers;
using System;
using System.Xml;
using Utility_WPF.Services.Interfaces;

namespace Utility_WPF.Services
{
    /// <summary>
    /// Sql Service
    /// </summary>
    public class SqlService : ISqlService
    {
        #region Properties

        private ISqlTokenizer _tokenizer;
        private ISqlTokenParser _parser;
        private ISqlTreeFormatter _formatter;

        #endregion Properties

        /// <inheritdoc />
        public string FormatSql(string sql)
        {
            try
            {
                _tokenizer = (ISqlTokenizer)new TSqlStandardTokenizer();
                _parser = (ISqlTokenParser)new TSqlStandardParser();

                string indentString = "\t";
                int spacesPerTab = 4;
                int maxLineWidth = 999;
                bool expandCommaLists = true;
                bool trailingCommas = false;
                bool spaceAfterExpandedComma = false;
                bool expandBooleanExpressions = true;
                bool expandCaseStatements = true;
                bool expandBetweenConditions = true;
                bool breakJoinOnSections = false;
                bool uppercaseKeywords = true;
                bool htmlColoring = true;
                bool keywordStandardization = false;

                ISqlTreeFormatter underlyingFormatter = new TSqlStandardFormatter(indentString, spacesPerTab, maxLineWidth, expandCommaLists, trailingCommas, spaceAfterExpandedComma, expandBooleanExpressions, expandCaseStatements, expandBetweenConditions, breakJoinOnSections, uppercaseKeywords, htmlColoring, keywordStandardization);
                _formatter = (ISqlTreeFormatter)new HtmlPageWrapper(underlyingFormatter);
                ITokenList tokenList = _tokenizer.TokenizeSQL(sql);
                XmlDocument parsedSql = _parser.ParseSQL(tokenList);
                string formattedSql = _formatter.FormatSQLTree(parsedSql);

                return formattedSql;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }


}
