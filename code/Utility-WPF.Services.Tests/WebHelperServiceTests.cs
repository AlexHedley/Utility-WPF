using Microsoft.VisualStudio.TestTools.UnitTesting;

using Utility_WPF.Services.Interfaces;

namespace Utility_WPF.Services.Tests
{
    /// <summary>
    /// Web Helper Service - Tests
    /// </summary>
    [TestClass]
    public class WebHelperServiceTests
    {
        #region Properties

        IWebHelperService _webHelperService;

        const string encodedHtmlSample = "&lt;p&gt;Hello&lt;p&gt;";
        const string decodedHtmlSample = "<p>Hello<p>";

        const string decodedUrlSample = "http://www.alexhedley.com/";
        const string encodedUrlSample = "http%3A%2F%2Fwww.alexhedley.com%2F";

        #endregion Properties

        /// <summary>
        /// Web Helper Service - Tests
        /// </summary>
        public WebHelperServiceTests()
        {
            _webHelperService = new WebHelperService();
        }

        [TestMethod]
        public void DecodeHtml()
        {
            var decodedHtml = _webHelperService.DecodeHtml(encodedHtmlSample);
            Assert.AreEqual(decodedHtmlSample, decodedHtml);
        }

        [TestMethod]
        public void EncodeHtml()
        {
            var encodedHtml = _webHelperService.EncodeHtml(decodedHtmlSample);
            Assert.AreEqual(encodedHtmlSample, encodedHtml);
        }

        [TestMethod]
        public void DecodeUrl()
        {
            var decodedUrl = _webHelperService.DecodeUrl(encodedUrlSample);
            Assert.AreEqual(decodedUrlSample, decodedUrl);
        }

        [TestMethod]
        public void EncodeUrl()
        {
            var encodedUrl = _webHelperService.EncodeUrl(decodedUrlSample);
            Assert.AreEqual(encodedUrlSample, encodedUrl);
        }
    }
}
