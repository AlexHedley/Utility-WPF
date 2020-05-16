namespace Utility_WPF.Services.Interfaces
{
    /// <summary>
    /// Interface - XML Service
    /// </summary>
    public interface IXMLService
    {
        /// <summary>
        /// Pretty XML
        /// </summary>
        /// <param name="xml"></param>
        /// <returns></returns>
        string PrettyXML(string xml);
    }
}
