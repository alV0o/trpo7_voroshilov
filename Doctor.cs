using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace trpo7_voroshilov_pr
{
    public class Doctor : INotifyPropertyChanged
    {
        private string _name;
        public string Name
        {
            get
            {
                return _name;
            }
            set
            {
                _name = value;
                OnPropertyChanged();
            }
        }
        private string _lastname;
        public string LastName
        {
            get
            {
                return _lastname;
            }
            set
            {
                _lastname = value;
                OnPropertyChanged();
            } 
        }
        private string _middlename;
        public string MiddleName
        {
            get
            {
                return _middlename;
            }
            set
            {
                _middlename = value;
                OnPropertyChanged();
            }
        }
        private string _specialisation;
        public string Specialisation
        {
            get
            {
                return _specialisation;
            }
            set
            {
                _specialisation = value;
                OnPropertyChanged();
            }
        }
        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
        private string _repeatpassword;
        [JsonIgnore]
        public string RepeatPassword
        {
            get
            {
                return _repeatpassword;
            }
            set
            {
                _repeatpassword= value;
                OnPropertyChanged();
            }
        }
        private int _id;
        [JsonIgnore]
        public int ID 
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? propName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

    }
}
