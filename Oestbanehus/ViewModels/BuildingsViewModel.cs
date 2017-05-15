using Oestbanehus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;
using Template10.Services.NavigationService;
using Oestbanehus.Views;
using Newtonsoft.Json.Linq;
using Oestbanehus.Persistence;
using System.Collections.ObjectModel;

namespace Oestbanehus.ViewModels
{
    class BuildingsViewModel : ViewModelBase
    {

        public ObservableCollection<Building> buildings { get; set; }

        public BuildingsViewModel()
        {
            
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            var a = BuildingsSingleton.Instance;
            buildings = a.ObservableCollection;

            
        }
        public void GotoSettings() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 0);

        public void GotoPrivacy() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);

    }
}
