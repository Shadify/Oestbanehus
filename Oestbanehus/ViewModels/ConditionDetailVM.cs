using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;
using Windows.UI.Xaml.Navigation;
using Oestbanehus.Models;

namespace Oestbanehus.ViewModels
{
    class ConditionDetailVM : ViewModelBase
    {

        private ConditionsOfItem _condition;
        public ConditionsOfItem condition
        {
            get
            {
                return _condition;
            }
            set
            {
                Set(ref _condition, value);
            }
        }

        public ConditionDetailVM()
        {
            
        }
        public override async Task OnNavigatedToAsync(object parameter, NavigationMode mode, IDictionary<string, object> suspensionState)
        {
            shit((int)parameter);
        }

        public async void shit(int id)
        {
            condition = await Persistence.Persistence.getConditionDetails(id);
        }

        public void GotoSettings() =>
           NavigationService.Navigate(typeof(Views.SettingsPage), 0);

        public void GotoPrivacy() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);
    }
}
