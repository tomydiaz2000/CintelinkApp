using CintelinkApp.ApiClient.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CintelinkApp.ApiClient
{
    public interface ICintelinkRest
    {
        Task<bool> Login(LoginRequestModel model);
        Task<List<ListFuelTanksResponseModel.Row>> GetFuelTanks(ListFuelTanksRequestModel model);
        Task<List<ListEquipmentsResponseModel.Row>> GetEquipments(string actionRequest);
    }
}
