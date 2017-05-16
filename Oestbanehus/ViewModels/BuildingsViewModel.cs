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
        public ObservableCollection<Apartment> apartments = ApartmentsSingleton.Instance.ObservableCollection;

        private Building _selectedBuilding;
        public Building selectedBuilding
        {
            get
            {
                return _selectedBuilding;
            }
            set
            {        
                Set(ref _selectedBuilding, value);
                ApartmentsSingleton.LoadApartmentsInBuildingAsync(_selectedBuilding.Id);
            }
        }

        public BuildingsViewModel()
        {
            
        }

        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            var a = BuildingsSingleton.Instance;
            buildings = a.ObservableCollection; 
        }


        DelegateCommand _LoadAptsCommand;
        public DelegateCommand LoadAptsCommand = new DelegateCommand(() =>
            {
                ApartmentsSingleton.LoadApartmentsInBuildingAsync(1);
            }, () => false);


        public void GotoSettings() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 0);

        public void GotoPrivacy() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);

    }
}
