using Microsoft.VisualStudio.TestTools.UnitTesting;

using Utility_WPF.Services.Interfaces;

namespace Utility_WPF.Services.Tests
{
    /// <summary>
    /// XML Service - Tests
    /// </summary>
    [TestClass]
    public class XMLServiceTests
    {
        #region Properties

        IXMLService _xmlService;

        #endregion Properties

        /// <summary>
        /// XML Service - Tests
        /// </summary>
        public XMLServiceTests()
        {
            _xmlService = new XMLService();
        }

        //[TestMethod]
        //public void TestMethod1()
        //{
        //    var xml = @"<note><to>Tove</to><from>Jani</from><heading>Reminder</heading><body>Don't forget me this weekend!</body></note>";
        //    var formattedXml = _xmlService.PrettyXML(xml);
        //}
    }
}
