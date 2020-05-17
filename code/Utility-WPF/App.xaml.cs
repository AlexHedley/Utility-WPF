using System.Windows;

using Prism.Ioc;
using Prism.Modularity;

using Utility_WPF.Modules.Guid;
using Utility_WPF.Modules.HTML;
using Utility_WPF.Modules.JSONPP;
using Utility_WPF.Modules.SqlBuilder;
using Utility_WPF.Modules.URL;
using Utility_WPF.Modules.XMLPP;
using Utility_WPF.Services;
using Utility_WPF.Services.Interfaces;
using Utility_WPF.Views;

namespace Utility_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        /// <summary>
        /// Create Shell
        /// </summary>
        /// <returns></returns>
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        /// <summary>
        /// Register Types
        /// </summary>
        /// <param name="containerRegistry"></param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IWebHelperService, WebHelperService>();
            containerRegistry.RegisterSingleton<IXMLService, XMLService>();
            containerRegistry.RegisterSingleton<IJSONService, JSONService>();
        }

        //protected override IModuleCatalog CreateModuleCatalog()
        //{
        //    DynamicDirectoryModuleCatalog catalog = new DynamicDirectoryModuleCatalog(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Modules"));
        //    return catalog;
        //}

        /// <summary>
        /// Configure Module Catalog
        /// </summary>
        /// <param name="moduleCatalog"></param>
        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<HTMLModule>();
            moduleCatalog.AddModule<URLModule>();
            moduleCatalog.AddModule<GuidModule>();
            moduleCatalog.AddModule<XMLPPModule>();
            moduleCatalog.AddModule<JSONPPModule>();
            moduleCatalog.AddModule<SqlBuilderModule>();
        }
    }
}
