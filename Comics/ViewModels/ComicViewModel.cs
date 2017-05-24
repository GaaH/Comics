using Comics.Models;
using Comics.Services;
using Comics.UserStorage;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System;
using System.Windows.Input;
using Windows.UI.Xaml.Media.Imaging;

namespace Comics.ViewModels
{
    public abstract class ComicViewModel : ViewModelBase
    {
        protected INavigationService NavigationService { get; }
        protected IComicProvider ComicProvider { get; }

        private ComicSettings Settings { get; }

        private Comic comic;
        protected virtual Comic Comic
        {
            get { return comic; }
            set
            {
                Set(ref comic, value);

                ComicStrip = comic.ComicStrip;
                ComicUri = comic.ComicUri;

                LoadOldestComicCommand.RaiseCanExecuteChanged();
                LoadLatestComicCommand.RaiseCanExecuteChanged();
                LoadPreviousComicCommand.RaiseCanExecuteChanged();
                LoadNextComicCommand.RaiseCanExecuteChanged();

                Settings.LastViewedUri = Comic.ComicUri;
            }
        }

        public abstract ICommand ResumeComicCommand { get; }
        public RelayCommand LoadOldestComicCommand { get; }
        public RelayCommand LoadLatestComicCommand { get; }
        public RelayCommand LoadPreviousComicCommand { get; }
        public RelayCommand LoadNextComicCommand { get; }

        private BitmapImage comicStrip;
        public BitmapImage ComicStrip
        {
            get { return comicStrip; }
            private set { Set(ref comicStrip, value); }
        }

        private Uri comicUri;
        public Uri ComicUri
        {
            get { return comicUri; }
            set { Set(ref comicUri, value); }
        }



        public ComicViewModel(INavigationService navigationService, IComicProvider comicProvider, ComicSettings settings)
        {
            NavigationService = navigationService;
            ComicProvider = comicProvider;
            Settings = settings;

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
