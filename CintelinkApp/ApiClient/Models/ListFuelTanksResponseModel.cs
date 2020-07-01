using System;
using System.Collections.Generic;
using System.Text;

namespace CintelinkApp.ApiClient.Models
{
    public class ListFuelTanksResponseModel
    {
        public class Row
        {
            public string id_tanque { get; set; }
            public string id_equipo { get; set; }
            public string tanque { get; set; }
            public string producto { get; set; }
            public double cantidad { get; set; }
            public string ultima_cantidad { get; set; }
            public string ultima_fecha { get; set; }
            public double capacidad { get; set; }
            public string log_interval { get; set; }
            public string baja { get; set; }
            public string sync { get; set; }
            public string alarma { get; set; }
            public string nivel_alarma { get; set; }
            public string mail_enviado { get; set; }
            public string descripcion { get; set; }
            public string coef_var_vol { get; set; }
            public string nombre_producto { get; set; }
            public string tanque_descripcion { get; set; }
            public string equipo { get; set; }
        }

        public class Data
        {
            public int inicio { get; set; }
            public int qty { get; set; }
            public object next { get; set; }
            public int last { get; set; }
            public object prev { get; set; }
            public int first { get; set; }
            public IList<object> pagAtras { get; set; }
            public int pagActual { get; set; }
            public IList<object> pagAdelante { get; set; }
            public string total { get; set; }
            public int cantPaginas { get; set; }
            public IList<Row> rows { get; set; }
        }

        public class Main
        {
            public Data data { get; set; }
            public int error { get; set; }
            public IList<object> errores { get; set; }
            public object msg { get; set; }
        }
    }
}
