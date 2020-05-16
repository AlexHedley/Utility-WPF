using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Utility_WPF.Core;
using Utility_WPF.Modules.Guid.Views;

namespace Utility_WPF.Modules.Guid
{
    /// <summary>
    /// Guid Module
    /// </summary>
    public class GuidModule : IModule
    {
        #region Properties

        private readonly IRegionManager _regionManager;

        #endregion Properties

        /// <summary>
        /// Guid Module
        /// </summary>
        /// <param name="regionManager"></param>
        public GuidModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        /// <summary>
        /// On Initialized
        /// </summary>
        /// <param name="containerProvider"></param>
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegionGuid, nameof(GuidView));
        }

        /// <summary>
        /// Register Types
        /// </summary>
        /// <param name="containerRegistry"></param>
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<GuidView>();
        }

    }
}