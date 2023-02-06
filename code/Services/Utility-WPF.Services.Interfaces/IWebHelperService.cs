namespace Utility_WPF.Services.Interfaces
{
    /// <summary>
    /// Interface - Html Service
    /// </summary>
    public interface IWebHelperService
    {
        /// <summary>
        /// Decode Html
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        string DecodeHtml(string content);

        /// <summary>
        /// Decode Url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        string DecodeUrl(string url);
        /// <summary>
        /// Encode Html
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        string EncodeHtml(string content);

        /// <summary>
        /// Encode Url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        string EncodeUrl(string url);

    }
}
