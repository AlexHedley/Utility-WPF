using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

using Utility_WPF.Core;
using Utility_WPF.Modules.SqlBuilder.Views;

namespace Utility_WPF.Modules.SqlBuilder
{
    /// <summary>
    /// Sql Builder - Module
    /// </summary>
    public class SqlBuilderModule : IModule
    {
        #region Properties

        private readonly IRegionManager _regionManager;

        #endregion Properties

        /// <summary>
        /// Sql Builder - Module
        /// </summary>
        public SqlBuilderModule(IRegionManager regionManager)
        {
            _regionManager = regionManager;
        }

        /// <summary>
        /// On Initialized
        /// </summary>
        /// <param name="containerProvider"></param>
        public void OnInitialized(IContainerProvider containerProvider)
        {
            _regionManager.RequestNavigate(RegionNames.ContentRegionSqlBuilder, nameof(SqlBuilderView));
        }

        /// <summary>
        /// Register Types
        /// </summary>
        /// <param name="containerRegistry"></param>
        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<SqlBuilderView>();
        }
    }
}