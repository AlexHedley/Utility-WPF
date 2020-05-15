namespace Utility_WPF.Services.Interfaces
{
    /// <summary>
    /// Interface - Html Service
    /// </summary>
    public interface IHtmlService
    {
        /// <summary>
        /// Decode
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        string Decode(string content);

        /// <summary>
        /// Encode
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        string Encode(string content);
    }
}
