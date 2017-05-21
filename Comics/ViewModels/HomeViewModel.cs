using Comics.Models;
using Comics.Views;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using System.Collections.Generic;
using System.Windows.Input;

namespace Comics.ViewModels
{


    public class HomeViewModel
    {
        private INavigationService NavigationService { get; }

        public IEnumerable<PageLink> Links { get; }

        public ICommand GoToPageCommand { get; }


        public HomeViewModel(INavigationService navigationService)
        {
            NavigationService = navigationService;

            Links =
                new List<PageLink>()
                {
                    new PageLink(ComicWebsite.Explosm, nameof(ExplosmPage)),
                    new PageLink(ComicWebsite.Xkcd, nameof(XkcdPage))
                };

            GoToPageCommand = new RelayCommand<PageLink>(GoToPage);
        }

        private void GoToPage(PageLink pageLink)
        {
            NavigationService.NavigateTo(pageLink.PageKey);
        }
    }
}
