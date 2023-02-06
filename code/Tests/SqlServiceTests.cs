using Microsoft.VisualStudio.TestTools.UnitTesting;

using Utility_WPF.Services.Interfaces;

namespace Utility_WPF.Services.Tests
{
    /// <summary>
    /// Sql Service Tests
    /// </summary>
    [TestClass]
    public class SqlServiceTests
    {
        #region Properties

        ISqlService _sqlService;

        #endregion Properties

        public SqlServiceTests()
        {
            _sqlService = new SqlService();
        }

        //[TestMethod]
        //public void FormatSql()
        //{
        //}
    }
}
