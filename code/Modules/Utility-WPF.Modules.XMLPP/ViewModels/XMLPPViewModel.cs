using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

using Utility_WPF.Core.Mvvm;

namespace Utility_WPF.Modules.XMLPP.ViewModels
{
    /// <summary>
    /// XML Pretty Print - ViewModel
    /// </summary>
    public class XMLPPViewModel : RegionViewModelBase
    {
        #region Properties

        private string _xml;
        public string Xml
        {
            get { return _xml; }
            set { SetProperty(ref _xml, value); }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { SetProperty(ref _errorMessage, value); }
        }

        #endregion Properties

        #region Commands

        public DelegateCommand PrettyCommand { get; private set; }
        public DelegateCommand CopyCommand { get; private set; }

        #endregion Commands

        /// <summary>
        /// XML Pretty Print - ViewModel
        /// </summary>
        /// <param name="regionManager"></param>
        public XMLPPViewModel(IRegionManager regionManager) : base(regionManager)
        {
            PrettyCommand = new DelegateCommand(PrettyXml);
            CopyCommand = new DelegateCommand(CopyXml);
        }

        #region Navigation

        /// <summary>
        /// On Navigated To
        /// </summary>
        /// <param name="navigationContext"></param>
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }

        #endregion Navigation

        #region Private

        #region Commands

        /// <summary>
        /// Pretty Xml
        /// </summary>
        private void PrettyXml()
        {
            ErrorMessage = "";

            if (string.IsNullOrEmpty(Xml))
                return;

            try
            {
                // http://thechriskent.com/2012/05/01/prettify-your-xml-in-net/

                var sw = new StringWriter();
                var xw = new XmlTextWriter(sw);
                xw.Formatting = Formatting.Indented;
                xw.Indentation = 4;

                var doc = new XmlDocument();
                doc.LoadXml(Xml);
                doc.Save(xw);

                Xml = sw.ToString();
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                ErrorMessage = ex.Message;
            }
        }

        /// <summary>
        /// Copy Xml
        /// </summary>
        private void CopyXml()
        {
            Clipboard.SetText(Xml);
        }

        #endregion Commands

        #endregion Private
    }
}
