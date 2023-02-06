namespace Utility_WPF.Services.Interfaces
{
    /// <summary>
    /// Interface - Sql Service
    /// </summary>
    public interface ISqlService
    {
        /// <summary>
        /// Format Sql
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        string FormatSql(string sql);
    }
}
