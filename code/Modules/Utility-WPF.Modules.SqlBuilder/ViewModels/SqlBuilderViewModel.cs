using Prism.Commands;
using Prism.Regions;
using System;
using System.Linq;
using System.Windows;
using Utility_WPF.Core.Mvvm;

namespace Utility_WPF.Modules.SqlBuilder.ViewModels
{
    /// <summary>
    /// Sql Builder - View Model
    /// </summary>
    public class SqlBuilderViewModel : RegionViewModelBase
    {
        #region Properties

        private string _sql;
        public string Sql
        {
            get { return _sql; }
            set { SetProperty(ref _sql, value); }
        }

        private string _sqlParsed;
        public string SqlParsed
        {
            get { return _sqlParsed; }
            set { SetProperty(ref _sqlParsed, value); }
        }

        private string _seperator;
        public string Seperator
        {
            get { return _seperator; }
            set { SetProperty(ref _seperator, value); }
        }

        #endregion Properties

        #region Commands

        public DelegateCommand ParseCommand { get; private set; }
        public DelegateCommand ClearCommand { get; private set; }
        public DelegateCommand CopyCommand { get; private set; }

        #endregion Commands

        /// <summary>
        /// Sql Builder - View Model
        /// </summary>
        public SqlBuilderViewModel(IRegionManager regionManager) : base(regionManager)
        {
            Sql = ""; // "a\nb\nc\nd";

            ParseCommand = new DelegateCommand(ParseSql);
            ClearCommand = new DelegateCommand(ClearSql);
            CopyCommand = new DelegateCommand(CopySql);
        }

        #region Navigation

        /// <summary>
        /// On Navigated To
        /// </summary>
        /// <param name="navigationContext"></param>
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            //do something
        }

        #endregion Navigation

        #region Private

        #region Commands

        /// <summary>
        /// Parse Sql
        /// </summary>
        private void ParseSql()
        {
            if (string.IsNullOrEmpty(Sql))
                return;

            var items = Sql.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            var inItems = string.Join(",", items.Select(i => $"{Seperator}{i.Trim()}{Seperator}"));

            SqlParsed = $"IN ({inItems})";
        }

        /// <summary>
        /// Clear Sql
        /// </summary>
        private void ClearSql()
        {
            Sql = string.Empty;
            SqlParsed = string.Empty;
        }

        /// <summary>
        /// Copy Sql
        /// </summary>
        private void CopySql()
        {
            Clipboard.SetText(SqlParsed);
        }

        #endregion Commands

        #endregion Private
    }
}
