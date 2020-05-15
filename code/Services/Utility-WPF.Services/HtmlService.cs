using System.IO;
using System.Net;

using Utility_WPF.Services.Interfaces;

namespace Utility_WPF.Services
{
    /// <summary>
    /// Html Service
    /// </summary>
    public class HtmlService : IHtmlService
    {
        /// <summary>
        /// Html Service
        /// </summary>
        public HtmlService()
        {

        }

        /// <inheritdoc />
        public string Decode(string content)
        {
            var writer = new StringWriter();
            WebUtility.HtmlDecode(content, writer);
            return writer.ToString();
        }

        /// <inheritdoc />
        public string Encode(string content)
        {
            return WebUtility.HtmlEncode(content);
        }
    }
}
