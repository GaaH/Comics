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

        private XkcdComic xkcdComic;
        public XkcdComic XkcdComic
        {
            get { return xkcdComic; }
            protected set
            {
                Set(ref xkcdComic, value);
                Comic = XkcdComic;
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

                if (comicUri == null)
                {
                    XkcdComic = (XkcdComic)await ComicProvider.LoadLatestComicAsync();
                }
                else
                {
                    XkcdComic = (XkcdComic)await ComicProvider.LoadComicAsync(comicUri);
                }
            }
        }
    }
}
