using System.IO;
using System.Windows;

using Prism.Ioc;
using Prism.Modularity;

using Utility_WPF.Views;
using Utility_WPF.Modules.HTML;
using Utility_WPF.Services;
using Utility_WPF.Services.Interfaces;

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
            containerRegistry.RegisterSingleton<IHtmlService, HtmlService>();
        }

        //protected override IModuleCatalog CreateModuleCatalog()
        //{
        //    DynamicDirectoryModuleCatalog catalog = new DynamicDirectoryModuleCatalog(Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "Modules"));
        //    return catalog;
        //}

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            moduleCatalog.AddModule<HTMLModule>();
        }
    }
}
