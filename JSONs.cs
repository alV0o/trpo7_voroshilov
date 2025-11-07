using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace trpo7_voroshilov_pr
{
    public class JSONs : INotifyPropertyChanged
    {
        private int _countall = 0;
        public int CountAll
        {
            get
            {
                return _countall;
            }
            set
            {
                _countall = value;
                OnPropertyChanged();
            }
        }
        private int _countDoc = 0;
        public int CountDoctors
        {
            get
            {
                return _countDoc;
            }
            set
            {
                _countDoc = value;
                OnPropertyChanged();
            }
        }
        private int _countPat = 0;
        public int CountPatients 
        {
            get
            {
                return _countPat;
            }
            set
            {
                _countPat = value;
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
