using System;
using System.Collections.Generic;
using System.Text;

namespace CintelinkApp.ApiClient.Models
{
    public class ListEquipmentsResponseModel
    {
        public class Row
        {
            public string id_equipo { get; set; }
            public string descripcion { get; set; }
            public string ultima_sincronizacion { get; set; }
            public string ultima_fecha { get; set; }
            public string ultima_fecha_h { get; set; }
            public string ultima_conexion { get; set; }
            public string fecha_dif { get; set; }
            public string fecha_dif_h { get; set; }
            public string online { get; set; }
            public string sync { get; set; }
            public string baja { get; set; }
            public string direccion_ip { get; set; }
        }

        public class Data
        {
            public int inicio { get; set; }
            public int qty { get; set; }
            public int next { get; set; }
            public int last { get; set; }
            public int prev { get; set; }
            public int first { get; set; }
            public IList<object> pagAtras { get; set; }
            public string pagActual { get; set; }
            public IList<object> pagAdelante { get; set; }
            public int total { get; set; }
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
