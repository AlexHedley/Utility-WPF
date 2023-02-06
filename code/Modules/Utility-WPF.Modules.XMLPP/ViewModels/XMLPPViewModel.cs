using System;
using System.Diagnostics;
using System.Windows;

using Prism.Commands;
using Prism.Regions;

using Utility_WPF.Core.Mvvm;
using Utility_WPF.Services;
using Utility_WPF.Services.Interfaces;

namespace Utility_WPF.Modules.XMLPP.ViewModels
{
    /// <summary>
    /// XML Pretty Print - ViewModel
    /// </summary>
    public class XMLPPViewModel : RegionViewModelBase
    {
        #region Properties

        protected IXMLService XMLService { get; private set; }

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
        /// <param name="xmlService"></param>
        public XMLPPViewModel(IRegionManager regionManager, IXMLService xmlService) : base(regionManager)
        {
            XMLService = xmlService;

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
                Xml = XMLService.PrettyXML(Xml);
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
