using Comics.Models;
using Comics.Services;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System.Windows.Input;

namespace Comics.ViewModels
{
    public abstract class ComicViewModel : ViewModelBase
    {
        protected INavigationService NavigationService { get; }
        protected IComicProvider ComicProvider { get; }

        private Comic comic;
        public Comic Comic
        {
            get { return comic; }
            protected set
            {
                Set(ref comic, value);
                LoadOldestComicCommand.RaiseCanExecuteChanged();
                LoadLatestComicCommand.RaiseCanExecuteChanged();
                LoadPreviousComicCommand.RaiseCanExecuteChanged();
                LoadNextComicCommand.RaiseCanExecuteChanged();
            }
        }

        public abstract ICommand ResumeComicCommand { get; }
        public abstract RelayCommand LoadOldestComicCommand { get; }
        public abstract RelayCommand LoadLatestComicCommand { get; }
        public abstract RelayCommand LoadPreviousComicCommand { get; }
        public abstract RelayCommand LoadNextComicCommand { get; }

        public ComicViewModel(INavigationService navigationService, IComicProvider comicProvider)
        {
            NavigationService = navigationService;
            ComicProvider = comicProvider;
        }
    }
}
