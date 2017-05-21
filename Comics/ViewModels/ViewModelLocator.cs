using Comics.Services;
using Comics.Views;
using GalaSoft.MvvmLight.Ioc;
using GalaSoft.MvvmLight.Views;
using Microsoft.Practices.ServiceLocation;
using System;

namespace Comics.ViewModels
{
    public class ViewModelLocator
    {
        public ViewModelLocator()
        {
            ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

            SimpleIoc.Default.Register(BuildNavigationService);
            SimpleIoc.Default.Register<ExplosmProvider>();
            SimpleIoc.Default.Register<ExplosmViewModel>();
            SimpleIoc.Default.Register<HomeViewModel>();
        }

        private INavigationService BuildNavigationService()
        {
            var service = new NavigationService();
            var pageTypes = new Type[] { typeof(HomePage), typeof(ExplosmPage) };

            foreach (var pageType in pageTypes)
            {
                service.Configure(pageType.Name, pageType);
            }

            return service;
        }

        public ExplosmViewModel ExplosmViewModel => ServiceLocator.Current.GetInstance<ExplosmViewModel>();
        public HomeViewModel HomeViewModel => ServiceLocator.Current.GetInstance<HomeViewModel>();
    }
}
