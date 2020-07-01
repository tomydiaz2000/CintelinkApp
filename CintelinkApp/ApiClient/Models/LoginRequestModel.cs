using System;
using System.Collections.Generic;
using System.Text;

namespace CintelinkApp.ApiClient.Models
{
    public class LoginRequestModel
    {
        public string User { get; set; }
        public string Pass { get; set; }
        public string Accion { get; set; }
        public string Format { get; set; }
    }
}
