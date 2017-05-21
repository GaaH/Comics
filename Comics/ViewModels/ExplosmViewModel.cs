using Comics.Services;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System.Windows.Input;

namespace Comics.ViewModels
{
    public class ExplosmViewModel : ComicViewModel
    {
        public override RelayCommand LoadOldestComicCommand { get; }
        public override RelayCommand LoadLatestComicCommand { get; }
        public override ICommand ResumeComicCommand { get; }
        public override RelayCommand LoadPreviousComicCommand { get; }
        public override RelayCommand LoadNextComicCommand { get; }

        public ExplosmViewModel(INavigationService navigationService, ExplosmProvider comicProvider) : base(navigationService, comicProvider)
        {
            ResumeComicCommand = new RelayCommand(ResumeComicAsync);

            LoadOldestComicCommand = new RelayCommand(LoadOldestComicAsync, () => Comic == null || Comic.HasPreviousComic);
            LoadLatestComicCommand = new RelayCommand(LoadLatestComicAsync, () => Comic == null || Comic.HasNextComic);

            LoadPreviousComicCommand = new RelayCommand(LoadPreviousComicAsync, () => Comic != null && Comic.HasPreviousComic);
            LoadNextComicCommand = new RelayCommand(LoadNextComicAsync, () => Comic != null && Comic.HasNextComic);
        }

        private async void ResumeComicAsync()
        {
            Comic = await ComicProvider.LoadLatestComicAsync();
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
