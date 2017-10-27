using EmpTrack.ViewModels.Auction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmpTrack.Views.Auction
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AuctionPageForUser1 : ContentPage
    {
        AuctionViewModelForUser1 auctionViewModel;
        public AuctionPageForUser1()
        {
            InitializeComponent();
            auctionViewModel = new AuctionViewModelForUser1(Navigation);
            BindingContext = auctionViewModel;
        }
    }
}