using System;
using System.Collections.Generic;
using System.Linq;
using Oestbanehus.Models;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;
using System.Collections.ObjectModel;

namespace Oestbanehus.ViewModels
{
    class ConditionViewModel : ViewModelBase
    {

        public ObservableCollection<ConditionsOfItem> Conditions { get; set; }

        public ConditionViewModel()
        {
            Conditions = new ObservableCollection<ConditionsOfItem>();
        }
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
           var b = await Persistence.Persistence.getConditionsOfApartment((int)parameter);
            foreach (var c in b)
            {
                Conditions.Add(c);
            } 
        }

        public void GotoSettings() =>
           NavigationService.Navigate(typeof(Views.SettingsPage), 0);

        public void GotoPrivacy() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);
    }
}
