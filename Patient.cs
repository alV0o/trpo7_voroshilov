using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace trpo7_voroshilov_pr
{
    internal class Patient : INotifyPropertyChanged
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
        private string _birthday;
        public string Birthday
        {
            get
            {
                return _birthday;
            }
            set
            {
                _birthday = value;
                OnPropertyChanged();
            }
        }
        private string _phoneNumber;
        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {
                _phoneNumber = value;
                OnPropertyChanged();
            }
        }
        /*private string _lastAppointment = "--.--.----";
        public string LastAppointment 
        {
            get
            {
                return _lastAppointment;
            }
            set
            {
                _lastAppointment = value;
                OnPropertyChanged();
            }
        }
        private int _lastDoctor = 0;
        public int LastDoctor 
        {
            get
            {
                return _lastDoctor;
            }
            set
            {
                _lastDoctor = value;
                OnPropertyChanged();
            }
        }
        private string _diagnosis = "-";
        public string Diagnosis 
        {
            get
            {
                return _diagnosis;
            }
            set
            {
                _diagnosis = value;
                OnPropertyChanged();
            }
        }
        private string _recomendations = "-";
        public string Recomendations 
        {
            get
            {
                return _recomendations;
            }
            set
            {
                _recomendations = value;
                OnPropertyChanged();
            }
        }*/

        private ObservableCollection<Appointment> _appointmentStories;
        public ObservableCollection<Appointment> AppointmentStories
        {
            get
            {
                return _appointmentStories;
            }
            set
            {
                _appointmentStories = value;
                OnPropertyChanged();
            }
        }

        private int _id = 0; 
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
        private Doctor _doctor = new Doctor();
        [JsonIgnore]
        public Doctor LastDoctorObj
        {
            get
            {
                return _doctor;
            }
            set
            {
                _doctor = value;
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
