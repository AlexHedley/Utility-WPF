using System.IO;
using System.Windows;

using Prism.Ioc;
using Prism.Modularity;

using Utility_WPF.Modules.Guid;
using Utility_WPF.Modules.HTML;
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
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterSingleton<IWebHelperService, WebHelperService>();
        }

        //protected override IModuleCatalog CreateModuleCatalog()
        //{
        //    DynamicDirectoryModuleCatalog catalog = new DynamicDirectoryModuleCatalog(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Modules"));
        //    return catalog;
        //}

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<HTMLModule>();
            moduleCatalog.AddModule<URLModule>();
            moduleCatalog.AddModule<GuidModule>();
            moduleCatalog.AddModule<XMLPPModule>();
        }
    }
}
