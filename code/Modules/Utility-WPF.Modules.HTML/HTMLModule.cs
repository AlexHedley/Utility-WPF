using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using Utility_WPF.Core;
using Utility_WPF.Modules.HTML.Views;

namespace Utility_WPF.Modules.HTML
{
    /// <summary>
    /// HTML Module
    /// </summary>
    public class HTMLModule : IModule
    {
        private readonly IRegionManager _regionManager;

        public HTMLModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegionHTML, nameof(HtmlView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<HtmlView>();
        }
    }
}