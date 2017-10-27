using EmpTrack.ViewModels.LotDetail;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmpTrack.Views.LotDetail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LotDetailPage : ContentPage
    {
        LotDetailViewModel lotdetailViewModel;
        public LotDetailPage(Vehicle vehicle)
        {
            InitializeComponent();
            lotdetailViewModel = new LotDetailViewModel(Navigation);
            BindingContext = vehicle;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            
        }
        
    }
}