namespace Utility_WPF.Services.Interfaces
{
    /// <summary>
    /// Interface - JSON Service
    /// </summary>
    public interface IJSONService
    {
        /// <summary>
        /// Pretty JSON
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        string PrettyJSON(string json);
    }
}
