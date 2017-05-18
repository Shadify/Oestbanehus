using Oestbanehus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Template10.Services.NavigationService;
using Windows.UI.Xaml.Navigation;

namespace Oestbanehus.ViewModels
{
    class ApartmentViewModel : ViewModelBase
    {
        private ApartmentDetails _apartment;
        public ApartmentDetails apartment
        {
            get
            {
                return _apartment;
            }
            set
            {
                Set(ref _apartment, value);

            }
        }


        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            var Dapartment = (Apartment)parameter;
            apartment = await Persistence.Persistence.getApartmentDetails(Dapartment.Id);
            var a = apartment;
        }

        public void GotoSettings() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 0);

        public void GotoPrivacy() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);
    }
}
