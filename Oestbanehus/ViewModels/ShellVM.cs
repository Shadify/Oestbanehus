using Oestbanehus.Models;
using Oestbanehus.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;

namespace Oestbanehus.ViewModels
{
    class ShellVM: ViewModelBase
    {

        public ShellVM()
        {
            loggedUserType = ShellSingleton.Instance.loggedUserType;
        }

        private Int32 _loggedUserType;
        public Int32 loggedUserType
        {
            get
            {
                return _loggedUserType;
            }
            set
            {
                Set(ref _loggedUserType, value);
            }
        }

        private string _error;
        public string error
        {
            get
            {
                return _error;
            }
            set
            {
                Set(ref _error, value);

            }
        }

        private string _email;
        public string email
        {
            get
            {
                return _email;
            }
            set
            {
                Set(ref _email, value);

            }
        }

        private string _password;
        public string password
        {
            get
            {
                return _password;
            }
            set
            {
                Set(ref _password, value);

            }
        }



        DelegateCommand _login;
        public DelegateCommand login
            => _login ?? (_login = new DelegateCommand(() =>
            {
                fuckyou(email, password);
            }, () => true));


        public async void fuckyou(string email,string password)
        {
            var p = new Person();
            p.Email = email;
            p.Password = password;
            var a = await Persistence.Persistence.Login(p);
            if (a != null)
            {
                loggedUserType = a.Type;
                switch (loggedUserType)
                {
                    case 0:
                        {
                            NavigationService.Navigate(typeof(Buildings));
                            break;
                        }
                    case 1:
                        {
                            NavigationService.Navigate(typeof(BuildingsWithConditions));
                            break;
                        }
                    case 2:
                        {
                            NavigationService.Navigate(typeof(Buildings));
                            break;
                        }
                    default:
                        break;
                }
            } else
            {
                error = "Wrong email or password";
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
