using EmpTrack.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace EmpTrack.Views.Profile
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class EmpProfile : ContentPage
    {
        EmpProfileViewModel viewModel;
        public EmpProfile()
        {
            InitializeComponent();
            viewModel = new EmpProfileViewModel();
            BindingContext = viewModel;
        }
    }
}