using Microsoft.VisualStudio.TestTools.UnitTesting;

using Utility_WPF.Services.Interfaces;

namespace Utility_WPF.Services.Tests
{
    /// <summary>
    /// JSON Service - Tests
    /// </summary>
    [TestClass]
    public class JSONServiceTests
    {
        #region Properties

        IJSONService _jsonService;

        #endregion Properties

        /// <summary>
        /// JSON Service - Tests
        /// </summary>
        public JSONServiceTests()
        {
            _jsonService = new JSONService();
        }

        //[TestMethod]
        //public void PrettyJSON()
        //{
        //}
    }

}
