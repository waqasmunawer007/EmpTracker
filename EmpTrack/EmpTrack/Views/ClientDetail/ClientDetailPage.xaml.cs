using EmpTrack.ViewModels.ClientDetail;
using Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmpTrack.Views.ClientDetail
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ClientDetailPage : ContentPage
    {
        ClientDetailViewModel clientdetailViewModel;
        public ClientDetailPage(Client clientdetails)
        {
            InitializeComponent();
            clientdetailViewModel = new ClientDetailViewModel(Navigation);
            BindingContext = clientdetails;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
        }
        
    }
}