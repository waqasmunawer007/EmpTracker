using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Services.Models
{
    public class LotGroupEntity : ObservableCollection<Vehicle> , INotifyPropertyChanged
    {
        private bool _expanded;
        private bool _checked;
        
        public string Location { get; set; }

        public ObservableCollection<Vehicle> vehicle { get; set; }

        public LotGroupEntity()
        {
        }

        public LotGroupEntity(string location , bool expanded = false)
        {
            Location = location;
            Expanded = expanded;
        }

        public bool Expanded
        {
            get { return _expanded; }
            set
            {
                if (_expanded != value)
                {
                    _expanded = value;
                    OnPropertyChanged("Expanded");
                    OnPropertyChanged("StateIcon");
                }
            }
        }

        public bool _Checked
        {
            get
            {
                return _checked;
            }
            set
            {
                _checked = value;
                OnPropertyChanged("_Checked");
            }
        }
        
        public int ItemsCount { get; set; }

        public string StateIcon
        {
            get { return Expanded ? "Collapse.png" : "Expand.png"; }
        }

        public string TitleWithItemCount
        {
            get { return string.Format("{0} ({1})", Location, ItemsCount); }
        }

        
        private void OnPropertyChanged(string data)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(data));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
    
}
