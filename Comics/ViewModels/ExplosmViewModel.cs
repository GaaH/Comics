using Comics.Services;
using Comics.UserStorage;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System.Windows.Input;

namespace Comics.ViewModels
{
    public class ExplosmViewModel : ComicViewModel
    {
        public override ICommand ResumeComicCommand { get; }


        public ExplosmViewModel(INavigationService navigationService, ExplosmProvider comicProvider) : base(navigationService, comicProvider, ComicSettings.ExplosmSettings)
        {
            ResumeComicCommand = new RelayCommand(ResumeComicAsync);
        }

        private async void ResumeComicAsync()
        {
            if (Comic == null)
            {
                var comicUri = ComicSettings.ExplosmSettings.LastViewedUri;

                if (comicUri == null)
                {
                    Comic = await ComicProvider.LoadLatestComicAsync();
                }
                else
                {
                    Comic = await ComicProvider.LoadComicAsync(comicUri);
                }
            }
        }
    }
}
