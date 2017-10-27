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
    public partial class AuctionPageForUser2 : ContentPage
    {
        AuctionViewModelForUser2 auctionViewModel;
        public AuctionPageForUser2()
        {
            InitializeComponent();
            auctionViewModel = new AuctionViewModelForUser2(Navigation);
            BindingContext = auctionViewModel;
        }
    }
}