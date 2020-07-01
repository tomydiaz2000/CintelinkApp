using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using CintelinkApp.Services;
using CintelinkApp.Views;
using CintelinkApp.ApiClient;
using Akavache;
using CintelinkApp.Services.PageService;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace CintelinkApp
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<CintelinkApiService>();
            DependencyService.Register<CintelinkRest>();
            //DependencyService.Register<PageService>();

            CacheInit();

            var token = Task.Run(() => IsLoggedIn()).Result;

            if (token)
            {
                MainPage = new NavigationPage (new ListEquipmentsPage());
            }
            else
            {
                MainPage = new LoginPage();
            }
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }

        public void CacheInit()
        {
            BlobCache.EnsureInitialized();
            BlobCache.ApplicationName = "CintelinkCache"; // Name
        }

        public async Task<bool> IsLoggedIn()
        {
            bool response = false;
            try
            {
                var token = await BlobCache.LocalMachine.GetObject<string>("token");

                if (!string.IsNullOrEmpty(token))
                {
                    response = true;
                }
            }
            catch(Exception e)
            {
                //throw e;
            }
            return response;
        }
    }
}
