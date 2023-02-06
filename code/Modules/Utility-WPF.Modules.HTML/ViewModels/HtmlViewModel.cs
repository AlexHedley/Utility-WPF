using Prism.Commands;
using Prism.Regions;

using Utility_WPF.Core.Mvvm;
using Utility_WPF.Services.Interfaces;

namespace Utility_WPF.Modules.HTML.ViewModels
{
    /// <summary>
    /// Html - View Model
    /// </summary>
    public class HtmlViewModel : RegionViewModelBase
    {
        #region Properties

        protected IWebHelperService WebHelperService { get; private set; }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        private string _encode;
        public string Encode
        {
            get { return _encode; }
            set { 
                SetProperty(ref _encode, value); 

            }
        }

        private string _decode;
        public string Decode
        {
            get { return _decode; }
            set { SetProperty(ref _decode, value); }
        }

        private int _characterCount;
        public int CharacterCount
        {
            get { return _characterCount; }
            set { SetProperty(ref _characterCount, value); }
        }

        #endregion Properties

        #region Commands

        public DelegateCommand ClearCommand { get; private set; }
        public DelegateCommand EncodeCommand { get; private set; }
        public DelegateCommand DecodeCommand { get; private set; }

        #endregion Commands

        /// <summary>
        /// Html - View Model
        /// </summary>
        /// <param name="regionManager"></param>
        /// <param name="webHelperService"></param>
        public HtmlViewModel(IRegionManager regionManager, IWebHelperService webHelperService) :
            base(regionManager)
        {
            WebHelperService = webHelperService;

            Message = "Hello from HTML Module.";

            Encode = "&lt;p&gt;Hello&lt;p&gt;";
            Decode = ""; //"<p>Hello<p>";
            CharacterCount = 0;

            ClearCommand = new DelegateCommand(ClearContent);
            EncodeCommand = new DelegateCommand(EncodeContent);
            DecodeCommand = new DelegateCommand(DecodeContent);

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
        /// Clear Content
        /// </summary>
        private void ClearContent()
        {
            Encode = "";
            Decode = "";
        }

        /// <summary>
        /// Encode Content
        /// </summary>
        private void EncodeContent()
        {
            Encode = WebHelperService.EncodeHtml(Decode);
        }

        /// <summary>
        /// Decode Content
        /// </summary>
        private void DecodeContent()
        {
            CharacterCount = Encode.Length;
            Decode = WebHelperService.DecodeHtml(Encode);
        }

        #endregion Commands

        #endregion Private
    }
}
