using CintelinkApp.Models;
using CintelinkApp.Services;
using CintelinkApp.Services.PageService;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CintelinkApp.ViewModels
{
    public class ListFuelTanksViewModel : BaseViewModel
    {
        #region Commands
        #endregion
        #region Services
        ICintelinkApiService _cintelinkApiService;
        IPageService _pageService;
        #endregion
        #region CTOR
        public ListFuelTanksViewModel(PageService pageService, int id)
        {
            _cintelinkApiService = DependencyService.Get<ICintelinkApiService>();
            _pageService = pageService;

            IsBusy = false;

            Task.Run(async () => await GetFuelTanks(id));
        }
        #endregion
        #region Properties
        public ObservableCollection<FuelTank> ListFuelTanks { get; private set; } = new ObservableCollection<FuelTank>();

        bool _isVisibleList = true;
        public bool IsVisibleList
        {
            get => _isVisibleList;
            set
            {
                SetProperty(ref _isVisibleList, value);
                OnPropertyChanged();
            }
        }
        #endregion
        #region Methods
        async Task GetFuelTanks(int id)
        {
            await ActivityIndicatorRunning(true);
            var listModel = await _cintelinkApiService.GetFuelTanksList(id);

            foreach(var item in listModel)
            {
                ListFuelTanks.Add(item);
            }
            await ActivityIndicatorRunning(false);
        }

        async Task ActivityIndicatorRunning(bool state)
        {
            if (state)
            {
                IsBusy = true;
                IsVisibleList = false;
            }
            else
            {
                IsBusy = false;
                IsVisibleList = true;
            }
        }
        #endregion
    }
}
