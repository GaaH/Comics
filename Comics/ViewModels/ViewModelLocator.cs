using Comics.Views;
using GalaSoft.MvvmLight;
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

            if (ViewModelBase.IsInDesignModeStatic)
            {

            }
            else
            {
                SimpleIoc.Default.Register(BuildNavigationService);
            }
        }

        private INavigationService BuildNavigationService()
        {
            var service = new NavigationService();
            var pageTypes = new Type[] { typeof(MainPage) };

            foreach (var pageType in pageTypes)
            {
                service.Configure(pageType.Name, pageType);
            }

            return service;
        }
    }
}
