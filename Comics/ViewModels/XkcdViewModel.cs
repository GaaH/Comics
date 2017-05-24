using Comics.Models;
using Comics.Services;
using Comics.UserStorage;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System.Windows.Input;

namespace Comics.ViewModels
{
    public class XkcdViewModel : ComicViewModel
    {
        public override ICommand ResumeComicCommand { get; }

        protected override Comic Comic
        {
            set
            {
                base.Comic = value;
                Description = (Comic as XkcdComic)?.Description;
            }
        }


        private string description;
        public string Description
        {
            get { return description; }
            private set
            {
                Set(ref description, value);
            }
        }


        public XkcdViewModel(INavigationService navigationService, XkcdProvider comicProvider) : base(navigationService, comicProvider, ComicSettings.XkcdSettings)
        {
            ResumeComicCommand = new RelayCommand(ResumeComic);
        }

        private async void ResumeComic()
        {
            if (Comic == null)
            {
                var comicUri = ComicSettings.XkcdSettings.LastViewedUri;
                XkcdComic xkcd = null;

                if (comicUri == null)
                {
                    xkcd = (XkcdComic)await ComicProvider.LoadLatestComicAsync();
                }
                else
                {
                    xkcd = (XkcdComic)await ComicProvider.LoadComicAsync(comicUri);
                }

                Comic = xkcd;
                Description = xkcd.Description;
            }
        }
    }
}
