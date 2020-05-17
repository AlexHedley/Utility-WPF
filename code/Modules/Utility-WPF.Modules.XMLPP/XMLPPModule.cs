using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using Utility_WPF.Core;
using Utility_WPF.Modules.XMLPP.Views;

namespace Utility_WPF.Modules.XMLPP
{
    /// <summary>
    /// XML Pretty Print - Module
    /// </summary>
    public class XMLPPModule : IModule
    {
        #region Properties

        private readonly IRegionManager _regionManager;

        #endregion Properties

        /// <summary>
        /// XML Pretty Print - Module
        /// </summary>
        public XMLPPModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        /// <summary>
        /// On Initialized
        /// </summary>
        /// <param name="containerProvider"></param>
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegionXml, nameof(XMLPPView));
        }

        /// <summary>
        /// Register Types
        /// </summary>
        /// <param name="containerRegistry"></param>
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<XMLPPView>();
        }
    }
}