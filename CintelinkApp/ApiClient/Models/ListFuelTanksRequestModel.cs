using System;
using System.Collections.Generic;
using System.Text;

namespace CintelinkApp.ApiClient.Models
{
    public class ListFuelTanksRequestModel
    {
        public string Accion { get; set; }
        public int Inicio { get; set; }
        public int Qty { get; set; }
        public int EquipoId { get; set; }
    }
}
