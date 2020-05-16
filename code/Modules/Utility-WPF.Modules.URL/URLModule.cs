using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using Utility_WPF.Core;
using Utility_WPF.Modules.URL.Views;

namespace Utility_WPF.Modules.URL
{
    /// <summary>
    /// URL Module
    /// </summary>
    public class URLModule : IModule
    {
        #region Properties

        private readonly IRegionManager _regionManager;

        #endregion Properties

        /// <summary>
        /// URL Module
        /// </summary>
        /// <param name="regionManager"></param>
        public URLModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        /// <summary>
        /// On Initialized
        /// </summary>
        /// <param name="containerProvider"></param>
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegionURL, nameof(UrlView));
        }

        /// <summary>
        /// Register Types
        /// </summary>
        /// <param name="containerRegistry"></param>
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<UrlView>();
        }

    }
}