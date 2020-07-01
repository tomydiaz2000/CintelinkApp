using CintelinkApp.ApiClient;
using CintelinkApp.ApiClient.Models;
using CintelinkApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CintelinkApp.Services
{
    public class CintelinkApiService : ICintelinkApiService
    {
        ICintelinkRest _cintelinkRest;
        public CintelinkApiService()
        {
            _cintelinkRest = DependencyService.Get<ICintelinkRest>();
        }

        public async Task<bool> Login(string user, string pass)
        {
            var sendModel = new LoginRequestModel
            {
                User = user,
                Pass = pass
            };

            var response = await _cintelinkRest.Login(sendModel);
            
            return response;
        }

        public async Task<List<FuelTank>> GetFuelTanksList(int id)
        {
            ListFuelTanksRequestModel model = new ListFuelTanksRequestModel
            {
                Accion = "listar",
                Inicio = 0,
                Qty = 50,
                EquipoId = id,
            };

            var response = await _cintelinkRest.GetFuelTanks(model);

            return response.Select(x=> new FuelTank() {
                Cant = x.cantidad,
                Capacity = x.capacidad,
                Description = x.descripcion,
                DescriptionTank = x.tanque_descripcion,
                Equipment = x.equipo,
                EquipmentId = x.id_equipo,
                Product = x.producto,
                ProductName = x.nombre_producto,
                Quantity = x.cantidad,
                Tank = x.tanque,
                TankId = x.id_tanque,
                Last_Date = x.ultima_fecha,
                Last_Quantity = x.ultima_cantidad
            }).ToList();
        }
        public async Task<List<Equipment>> GetEquipmentsList()
        {
            try
            {
                var response = await _cintelinkRest.GetEquipments("checkStatusSites");

                return response.Select(x => new Equipment
                {
                    Description = x.descripcion,
                    EquipmentId = int.Parse(x.id_equipo),
                    IPAdress = int.Parse(x.direccion_ip),
                    LastConnection = x.ultima_conexion,
                    LastDate = x.ultima_conexion,
                    LastSync = x.ultima_sincronizacion,
                    Online = x.online != "0",
                    Sync = x.sync
                }).ToList();
            }
            catch(Exception e)
            {
                return new List<Equipment>();
            }
        }
    }
    public interface ICintelinkApiService
    {
        Task<bool> Login(string user, string pass);
        Task<List<FuelTank>> GetFuelTanksList(int id);
        Task<List<Equipment>> GetEquipmentsList();
    }
}
