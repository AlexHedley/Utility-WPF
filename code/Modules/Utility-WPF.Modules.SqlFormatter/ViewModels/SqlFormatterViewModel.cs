using System;
using System.Diagnostics;
using System.Windows;

using Prism.Commands;
using Prism.Regions;

using Utility_WPF.Core.Mvvm;
using Utility_WPF.Services.Interfaces;

namespace Utility_WPF.Modules.SqlFormatter.ViewModels
{
    /// <summary>
    /// Sql Formatter - View Model
    /// </summary>
    public class SqlFormatterViewModel : RegionViewModelBase
    {
        #region Properties

        protected ISqlService SqlService { get; private set; }

        private string _sql;
        public string Sql
        {
            get { return _sql; }
            set { SetProperty(ref _sql, value); }
        }

        private string _sqlFormatted;
        public string SqlFormatted
        {
            get { return _sqlFormatted; }
            set { SetProperty(ref _sqlFormatted, value); }
        }
        
        private string _errorMessage;
        public string ErrorMessage
        {
            get { return _errorMessage; }
            set { SetProperty(ref _errorMessage, value); }
        }

        #endregion Properties

        #region Commands

        public DelegateCommand FormatCommand { get; private set; }
        public DelegateCommand CopyCommand { get; private set; }

        #endregion Commands

        /// <summary>
        /// JSON Pretty Print - ViewModel
        /// </summary>
        /// <param name="regionManager"></param>
        /// <param name="sqlService"></param>
        public SqlFormatterViewModel(IRegionManager regionManager, ISqlService sqlService) : base(regionManager)
        {
            SqlService = sqlService;

            Sql = "select * from table";

            FormatCommand = new DelegateCommand(FormatSql);
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
        /// Format Sql
        /// </summary>
        private void FormatSql()
        {
            ErrorMessage = "";

            if (string.IsNullOrEmpty(Sql))
                return;

            try
            {
                SqlFormatted = SqlService.FormatSql(Sql);
            }
            catch (Exception ex)
            {
                Debug.Print(ex.Message);
                ErrorMessage = ex.Message;
            }
        }

        /// <summary>
        /// Copy Sql
        /// </summary>
        private void CopySql()
        {
            Clipboard.SetText(SqlFormatted);
        }

        #endregion Commands

        #endregion Private
    }
}
