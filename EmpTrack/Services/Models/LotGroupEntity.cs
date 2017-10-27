using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace Services.Models
{
    public class LotGroupEntity : INotifyPropertyChanged
    {
        private bool _expanded;
        private bool _checked;
        private int itemscount;


        public string Location { get; set; }
        public ObservableCollection<Vehicle> vehicle { get; set; }

        public LotGroupEntity(string location , bool expanded = false)
        {
            Location = location;
            Expanded = expanded;
        }

        public bool Expanded
        {
            get
            {
                return _expanded;
            }
            set
            {
                _expanded = value;
                OnPropertyChanged("Expanded");
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

        public int ItemsCount
        {
            get
            {
                return itemscount;
            }
            set
            {
                itemscount = value;
                OnPropertyChanged("ItemsCount");
            }
        }

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
