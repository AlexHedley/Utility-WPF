using System.IO;
using System.Net;

using Utility_WPF.Services.Interfaces;

namespace Utility_WPF.Services
{
    /// <summary>
    /// Html Service
    /// </summary>
    public class WebHelperService : IWebHelperService
    {
        /// <summary>
        /// Web Helper Service
        /// </summary>
        public WebHelperService()
        {
        }

        /// <inheritdoc />
        public string DecodeHtml(string content)
        {
            var writer = new StringWriter();
            WebUtility.HtmlDecode(content, writer);
            return writer.ToString();
        }

        /// <inheritdoc />
        public string DecodeUrl(string url)
        {
            return WebUtility.UrlDecode(url);
        }

        /// <inheritdoc />
        public string EncodeHtml(string content)
        {
            return WebUtility.HtmlEncode(content);
        }

        /// <inheritdoc />
        public string EncodeUrl(string url)
        {
            return WebUtility.UrlEncode(url);
        }
    }
}
