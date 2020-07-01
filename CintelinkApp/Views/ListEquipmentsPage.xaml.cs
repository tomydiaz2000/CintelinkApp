using CintelinkApp.Services.PageService;
using CintelinkApp.ViewModels;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CintelinkApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ListEquipmentsPage : ContentPage
    {
        public ListEquipmentsPage()
        {
            var pageService = new PageService();

            InitializeComponent();

            BindingContext = new ListEquipmentsViewModel(pageService);
        }
    }
}