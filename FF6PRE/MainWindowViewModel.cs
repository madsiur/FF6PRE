using FF6PRE.MVVM;
using FF6PRE.ViewModels;

namespace FF6PRE
{
    public class MainWindowViewModel : ObservableObject
    {
        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set { OnPropertyChanged(ref _currentView, value); }
        }

        private MainMenuViewModel _mainMenuVM;
        public MainMenuViewModel MainMenuVM
        {
            get { return _mainMenuVM; }
            set { OnPropertyChanged(ref _mainMenuVM, value); }
        }

        public MainWindowViewModel()
        {
            CurrentView = new MainMenuViewModel(this);
        }
    }
}
