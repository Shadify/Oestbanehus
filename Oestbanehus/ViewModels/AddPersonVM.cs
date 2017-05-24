using Oestbanehus.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template10.Mvvm;

namespace Oestbanehus.ViewModels
{
    class AddPersonVM : ViewModelBase
    {

        private Person _newPerson;
        public Person newPerson
        {
            get
            {
                return _newPerson;
            }
            set
            {
                Set(ref _newPerson, value);

            }
        }

        private string _name;
        public string name
        {
            get
            {
                return _name;
            }
            set
            {
                Set(ref _name, value);

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


        private string _phone;
        public string phone
        {
            get
            {
                return _phone;
            }
            set
            {
                Set(ref _phone, value);

            }
        }


        private int _type;
        public int type
        {
            get
            {
                return _type;
            }
            set
            {
                Set(ref _type, value);

            }
        }



        public AddPersonVM()
        {
            newPerson = new Person() { Type=1 };
        }


        DelegateCommand _sendPost;
        public DelegateCommand sendPost
            => _sendPost ?? (_sendPost = new DelegateCommand(() =>
            {
                newPerson.Name = name;
                newPerson.Phone = phone;
                newPerson.Email = email;
                newPerson.Type = type;
                Persistence.Persistence.addPerson(newPerson);
            }, () => true));

        public void GotoSettings() =>
         NavigationService.Navigate(typeof(Views.SettingsPage), 0);

        public void GotoPrivacy() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 1);

        public void GotoAbout() =>
            NavigationService.Navigate(typeof(Views.SettingsPage), 2);
    }
}
