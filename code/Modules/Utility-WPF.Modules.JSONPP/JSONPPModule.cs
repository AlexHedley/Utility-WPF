using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using Utility_WPF.Core;
using Utility_WPF.Modules.JSONPP.Views;

namespace Utility_WPF.Modules.JSONPP
{
    /// <summary>
    /// JSON Pretty Print - Module
    /// </summary>
    public class JSONPPModule : IModule
    {
        #region Properties

        private readonly IRegionManager _regionManager;

        #endregion Properties

        /// <summary>
        /// JSON Pretty Print - Module
        /// </summary>
        public JSONPPModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        /// <summary>
        /// On Initialized
        /// </summary>
        /// <param name="containerProvider"></param>
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegionJson, nameof(JSONPPView));
        }

        /// <summary>
        /// Register Types
        /// </summary>
        /// <param name="containerRegistry"></param>
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<JSONPPView>();
        }
    }
}