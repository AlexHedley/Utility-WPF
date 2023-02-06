using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using Utility_WPF.Core;
using Utility_WPF.Modules.SqlFormatter.Views;

namespace Utility_WPF.Modules.SqlFormatter
{
    /// <summary>
    /// Sql Formatter - Module
    /// </summary>
    public class SqlFormatterModule : IModule
    {
        #region Properties

        private readonly IRegionManager _regionManager;

        #endregion Properties

        /// <summary>
        /// Sql Formatter - Module
        /// </summary>
        public SqlFormatterModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        /// <summary>
        /// On Initialized
        /// </summary>
        /// <param name="containerProvider"></param>
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegionSqlFormatter, nameof(SqlFormatterView));
        }

        /// <summary>
        /// Register Types
        /// </summary>
        /// <param name="containerRegistry"></param>
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<SqlFormatterView>();
        }
    }
}