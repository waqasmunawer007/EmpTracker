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
            },
            new PricingViewModel
            {
                 id=5,
                 price=29,
                 distance=38
            },
            new PricingViewModel
            {
                 id=6,
                 price=86,
                 distance=20
            },
            new PricingViewModel
            {
                 id=7,
                 price=96,
                 distance=15
            },
            new PricingViewModel
            {
                 id=8,
                 price=99,
                 distance=12
            },
            new PricingViewModel
            {
                 id=9,
                 price=56,
                 distance=66
            },
            new PricingViewModel
            {
                 id=10,
                 price=66,
                 distance=77
            },
            new PricingViewModel
            {
                 id=11,
                 price=73,
                 distance=31
            },
            new PricingViewModel
            {
                 id=12,
                 price=26,
                 distance=78
            },
            new PricingViewModel
            {
                 id=13,
                 price=49,
                 distance=30
            },
            new PricingViewModel
            {
                 id=14,
                 price=22,
                 distance=17
            },
            new PricingViewModel
            {
                 id=15,
                 price=62,
                 distance=19
            }

        };
            return obj1;

        }

    }
}
