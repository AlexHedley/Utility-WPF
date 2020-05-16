using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

using Utility_WPF.Core.Mvvm;
using Utility_WPF.Services.Interfaces;

namespace Utility_WPF.Modules.URL.ViewModels
{
    /// <summary>
    /// Url - View Model
    /// </summary>
    public class UrlViewModel : RegionViewModelBase
    {
        #region Properties

        protected IWebHelperService WebHelperService { get; private set; }

        private string _encodeUrl;
        public string EncodeUrl
        {
            get { return _encodeUrl; }
            set { SetProperty(ref _encodeUrl, value); }
        }

        private string _decodeUrl;
        public string DecodeUrl
        {
            get { return _decodeUrl; }
            set { SetProperty(ref _decodeUrl, value); }
        }

        #endregion Properties

        #region Commands

        public DelegateCommand EncodeCommand { get; private set; }
        public DelegateCommand DecodeCommand { get; private set; }
        public DelegateCommand CopyCommand { get; private set; }

        #endregion Commands

        /// <summary>
        /// Url - View Model
        /// </summary>
        /// <param name="regionManager"></param>
        /// <param name="webHelperService"></param>
        public UrlViewModel(IRegionManager regionManager, IWebHelperService webHelperService) : base(regionManager)
        {
            WebHelperService = webHelperService;

            EncodeUrl = "http://www.alexhedley.com/";

            EncodeCommand = new DelegateCommand(Encode);
            DecodeCommand = new DelegateCommand(Decode);
            CopyCommand = new DelegateCommand(CopyUrl);
        }

        #region Private

        #region Commands

        /// <summary>
        /// Encode
        /// </summary>
        private void Encode()
        {
            DecodeUrl = WebHelperService.EncodeUrl(EncodeUrl);
        }

        /// <summary>
        /// Decode
        /// </summary>
        private void Decode()
        {
            EncodeUrl = WebHelperService.DecodeUrl(DecodeUrl);
        }

        /// <summary>
        /// Copy Url
        /// </summary>
        private void CopyUrl()
        {
            Clipboard.SetText(DecodeUrl);
        }

        #endregion Commands

        #endregion Private
    }
}
