using CintelinkApp.Services.PageService;
using CintelinkApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CintelinkApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            var pageService = new PageService();

            InitializeComponent();

            BindingContext = new LoginViewModel(pageService);
        }
    }
}