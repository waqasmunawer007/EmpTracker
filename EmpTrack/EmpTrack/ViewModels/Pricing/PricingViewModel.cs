using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmpTrack.ViewModels.Pricing
{
    public class PricingViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public int id { get; set; }
        public int price { get; set; }
        public int distance { get; set; }

        public bool check;

        public bool Check
        {
            get
            {
                return check;
            }
            set
            {
                check = value;
                OnPropertyChanged("Check");
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public PricingViewModel()
        {
        }

        public ObservableCollection<PricingViewModel> getdata()
        {
            ObservableCollection<PricingViewModel> obj1 = new ObservableCollection<PricingViewModel>()
        {
            new PricingViewModel
            {
                 id=1,
                 price=100,
                 distance=50
            },
            new PricingViewModel
            {
                 id=2,
                 price=75,
                 distance=45
            },
            new PricingViewModel
            {
                 id=3,
                 price=45,
                 distance=34
            },
            new PricingViewModel
            {
                 id=4,
                 price=26,
                 distance=78
            }

        };
            return obj1;

        }

    }
}
