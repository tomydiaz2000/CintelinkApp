using Akavache;
using CintelinkApp.Models;
using CintelinkApp.Services;
using CintelinkApp.Services.PageService;
using CintelinkApp.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace CintelinkApp.ViewModels
{
    public class ListEquipmentsViewModel : BaseViewModel
    {
        #region Commands
        public ICommand LogOutCommand { get; private set; }
        #endregion
        #region Services
        ICintelinkApiService _cintelinkApiService;
        IPageService _pageService;
        #endregion
        #region CTOR
        public ListEquipmentsViewModel(PageService pageService)
        {
            _cintelinkApiService = DependencyService.Get<ICintelinkApiService>();
            _pageService = pageService;

            LogOutCommand = new Command(async() => await LogOut());

            Task.Run(async () => await GetEquipmentsList());
        }
        #endregion
        #region Properties
        public ObservableCollection<Equipment> ListEquipments { get; private set; } = new ObservableCollection<Equipment>();

        Equipment _equipmentsSeleted;
        public Equipment EquipmentsSeleted
        {
            get => _equipmentsSeleted;
            set
            {
                SetProperty(ref _equipmentsSeleted, value);
                if (value != null)
                    OnSeletedEquipment();
                OnPropertyChanged();
            }
        }
        #endregion
        #region Methods
        async Task GetEquipmentsList()
        {
            var listModel = await _cintelinkApiService.GetEquipmentsList();

            foreach (var item in listModel)
            {
                ListEquipments.Add(item);
            }
        }

        async Task LogOut()
        {
            try
            {
                await BlobCache.LocalMachine.InvalidateAll();

                var response = await _pageService.DisplayAlert("ATENCIÓN", "¿Desea cerrar la sesión?", "Salir", "Cancelar");
                if (response)
                {
                    await _pageService.SetMainPage(new LoginPage());
                }           
            }
            catch(Exception e)
            {
                await _pageService.DisplayAlert("ATENCIÓN", "No es posible cerrar la sesión, intente mas tarde","Ok");
            }
        }

        async void OnSeletedEquipment()
        {
            await _pageService.PushAsync(new ListFuelTanksPage(EquipmentsSeleted.EquipmentId, EquipmentsSeleted.Description));
            EquipmentsSeleted = null;
        }
        #endregion
    }
}
