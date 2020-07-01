using CintelinkApp.Services;
using CintelinkApp.Services.PageService;
using CintelinkApp.Views;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CintelinkApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        #region Commands
        public ICommand LoginCommand { get; private set; }
        #endregion
        #region Services
        ICintelinkApiService _cintelinkApiService;
        IPageService _pageService;
        #endregion
        #region CTOR
        public LoginViewModel(PageService pageService)
        {
            IsBusy = false;

            _cintelinkApiService = DependencyService.Get<ICintelinkApiService>();
            _pageService = pageService;

            userEntry = "devapp";
            passEntry = "devapp1234";

            LoginCommand = new Command(async () => await SendDataLogin());
        }
        #endregion

        #region Properties
        string _userEntry;
        string _passEntry;
        bool _loginIsVisible = true;

        public string userEntry
        {
            get => _userEntry;
            set
            {
                SetProperty(ref _userEntry, value);
                OnPropertyChanged();
            }
        }

        public string passEntry
        {
            get => _passEntry;
            set
            {
                SetProperty(ref _passEntry, value);
                OnPropertyChanged();
            }
        }

        public bool loginIsVisible
        {
            get => _loginIsVisible;
            set
            {
                SetProperty(ref _loginIsVisible, value);
                OnPropertyChanged();
            }
        }
        #endregion

        #region Methods
        async Task SendDataLogin()
        {
            await ActivityIndicatorRunning(true);

            var response = await _cintelinkApiService.Login(userEntry, passEntry);

            if (response)
            {
                await _pageService.SetMainPage(new NavigationPage (new ListEquipmentsPage()));
            }
            else
            {
                await ActivityIndicatorRunning(false);
                await _pageService.DisplayAlert("ATENCIÓN", "Usuario o contraseña incorrectas.","OK");
            }
        }

        async Task ActivityIndicatorRunning(bool state)
        {
            if (state)
            {
                IsBusy = true;
                loginIsVisible = false;
            }
            else
            {
                IsBusy = false;
                loginIsVisible = true;
            }
        }
        #endregion
    }
}
