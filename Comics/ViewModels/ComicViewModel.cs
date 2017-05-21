using Comics.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Views;

namespace Comics.ViewModels
{
    public class ComicViewModel : ViewModelBase
    {
        private INavigationService NavigationService { get; }

        private Comic comic;
        public Comic Comic
        {
            get { return comic; }
            set { Set(ref comic, value); }
        }


        public ComicViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;
        }
    }
}
