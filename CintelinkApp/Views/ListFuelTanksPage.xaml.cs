using CintelinkApp.Services.PageService;
using CintelinkApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CintelinkApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListFuelTanksPage : ContentPage
    {
        public ListFuelTanksPage(int id, string title)
        {
            var pageService = new PageService();

            this.Title = title;

            InitializeComponent();

            BindingContext = new ListFuelTanksViewModel(pageService, id);
        }
    }
}