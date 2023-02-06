using System;
using System.IO;
using System.Xml;

using Utility_WPF.Services.Interfaces;

namespace Utility_WPF.Services
{
    /// <summary>
    /// XML Service
    /// </summary>
    public class XMLService : IXMLService
    {
        /// <inheritdoc />
        public string PrettyXML(string xml)
        {
            try
            {
                // http://thechriskent.com/2012/05/01/prettify-your-xml-in-net/

                var sw = new StringWriter();
                var xw = new XmlTextWriter(sw);
                xw.Formatting = Formatting.Indented;
                xw.Indentation = 4;

                var doc = new XmlDocument();
                doc.LoadXml(xml);
                doc.Save(xw);

                return sw.ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
