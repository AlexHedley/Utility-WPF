using System;
using System.Diagnostics;
using System.Windows;

using Prism.Commands;
using Prism.Regions;

using Utility_WPF.Core.Mvvm;
using Utility_WPF.Services.Interfaces;

namespace Utility_WPF.Modules.JSONPP.ViewModels
{
    /// <summary>
    /// JSON Pretty Print - ViewModel
    /// </summary>
    public class JSONPPViewModel : RegionViewModelBase
    {
        #region Properties

        protected IJSONService JSONService { get; private set; }

        private string _json;
        public string Json
        {
            get { return _json; }
            set { SetProperty(ref _json, value); }
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
        /// JSON Pretty Print - ViewModel
        /// </summary>
        /// <param name="regionManager"></param>
        /// <param name="jsonService"></param>
        public JSONPPViewModel(IRegionManager regionManager, IJSONService jsonService) : base(regionManager)
        {
            JSONService = jsonService;

            PrettyCommand = new DelegateCommand(PrettyJson);
            CopyCommand = new DelegateCommand(CopyJson);
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
        /// Pretty Json
        /// </summary>
        private void PrettyJson()
        {
            ErrorMessage = "";

            if (string.IsNullOrEmpty(Json))
                return;

            try
            {
                Json = JSONService.PrettyJSON(Json);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                ErrorMessage = ex.Message;
            }
        }

        /// <summary>
        /// Copy Json
        /// </summary>
        private void CopyJson()
        {
            Clipboard.SetText(Json);
        }

        #endregion Commands

        #endregion Private
    }
}
