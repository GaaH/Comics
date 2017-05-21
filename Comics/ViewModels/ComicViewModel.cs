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
        public RelayCommand LoadOldestComicCommand { get; }
        public RelayCommand LoadLatestComicCommand { get; }
        public RelayCommand LoadPreviousComicCommand { get; }
        public RelayCommand LoadNextComicCommand { get; }

        public ComicViewModel(INavigationService navigationService, IComicProvider comicProvider)
        {
            NavigationService = navigationService;
            ComicProvider = comicProvider;

            LoadOldestComicCommand = new RelayCommand(LoadOldestComicAsync, () => Comic == null || Comic.HasPreviousComic);
            LoadLatestComicCommand = new RelayCommand(LoadLatestComicAsync, () => Comic == null || Comic.HasNextComic);

            LoadPreviousComicCommand = new RelayCommand(LoadPreviousComicAsync, () => Comic != null && Comic.HasPreviousComic);
            LoadNextComicCommand = new RelayCommand(LoadNextComicAsync, () => Comic != null && Comic.HasNextComic);
        }

        private async void LoadOldestComicAsync()
        {
            Comic = await ComicProvider.LoadOldestComicAsync();
        }

        private async void LoadLatestComicAsync()
        {
            Comic = await ComicProvider.LoadLatestComicAsync();
        }

        private async void LoadPreviousComicAsync()
        {
            Comic = await ComicProvider.LoadComicAsync(Comic.PreviousComic);
        }

        private async void LoadNextComicAsync()
        {
            Comic = await ComicProvider.LoadComicAsync(Comic.NextComic);
        }
    }
}
