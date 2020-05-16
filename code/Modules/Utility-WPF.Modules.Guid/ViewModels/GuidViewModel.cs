using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

using Utility_WPF.Core.Mvvm;

namespace Utility_WPF.Modules.Guid.ViewModels
{
    /// <summary>
    /// Guid - View Model
    /// </summary>
    public class GuidViewModel : RegionViewModelBase
    {
        #region Properties

        private string _zeroGuid;
        public string ZeroGuid
        {
            get { return _zeroGuid; }
            set { SetProperty(ref _zeroGuid, value); }
        }

        private string _newGuid;
        public string NewGuid
        {
            get { return _newGuid; }
            set { SetProperty(ref _newGuid, value); }
        }

        private int _guidCount;
        public int GuidCount
        {
            get { return _guidCount; }
            set { SetProperty(ref _guidCount, value); }
        }

        private string _newGuids;
        public string NewGuids
        {
            get { return _newGuid; }
            set { SetProperty(ref _newGuid, value); }
        }

        #endregion Properties

        #region Commands

        public DelegateCommand CopyZeroGuidCommand { get; private set; }
        public DelegateCommand GenerateCommand { get; private set; }
        public DelegateCommand CopyNewGuidCommand { get; private set; }
        public DelegateCommand GenerateGuidsCommand { get; private set; }
        public DelegateCommand CopyNewGuidsCommand { get; private set; }

        #endregion Commands

        /// <summary>
        /// Guid - View Model
        /// </summary>
        /// <param name="regionManager"></param>
        public GuidViewModel(IRegionManager regionManager) : base(regionManager)
        {
            ZeroGuid = System.Guid.Empty.ToString(); //00000000-0000-0000-0000-000000000000
            GuidCount = 5;

            CopyZeroGuidCommand = new DelegateCommand(CopyZeroGuid);
            GenerateCommand = new DelegateCommand(GenerateGuid);
            CopyNewGuidCommand = new DelegateCommand(CopyNewGuid);
            GenerateGuidsCommand = new DelegateCommand(GenerateGuids);
            CopyNewGuidsCommand = new DelegateCommand(CopyNewGuids);
        }

        #region Private

        /// <summary>
        /// Copy Zero Guid
        /// </summary>
        private void CopyZeroGuid()
        {
            Clipboard.SetText(ZeroGuid);
        }

        /// <summary>
        /// Generate Guid
        /// </summary>
        private void GenerateGuid()
        {
            NewGuid = System.Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Copy New Guid
        /// </summary>
        private void CopyNewGuid()
        {
            Clipboard.SetText(NewGuid);
        }

        /// <summary>
        /// Generate Guids
        /// </summary>
        private void GenerateGuids()
        {
            NewGuids = string.Empty; //Checkbox to append?

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < GuidCount; i++)
            {
                var guid = System.Guid.NewGuid().ToString() + Environment.NewLine;
                builder.Append(guid);
            }

            NewGuids = builder.ToString();
        }

        /// <summary>
        /// Copy New Guids
        /// </summary>
        private void CopyNewGuids()
        {
            Clipboard.SetText(NewGuids);
        }

        #endregion Private
    }
}
