using Comics.Services;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System.Windows.Input;

namespace Comics.ViewModels
{
    public class ExplosmViewModel : ComicViewModel
    {
        public override ICommand ResumeComicCommand { get; }


        public ExplosmViewModel(INavigationService navigationService, ExplosmProvider comicProvider) : base(navigationService, comicProvider)
        {
            ResumeComicCommand = new RelayCommand(ResumeComicAsync);
        }

        private async void ResumeComicAsync()
        {
            if (Comic == null)
            {
                Comic = await ComicProvider.LoadLatestComicAsync();
            }
        }
    }
}
