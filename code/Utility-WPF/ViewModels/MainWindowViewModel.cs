using Prism.Mvvm;

namespace Utility_WPF.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Utility";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}
