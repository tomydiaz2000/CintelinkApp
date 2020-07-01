using System;
using System.Collections.Generic;
using System.Text;

namespace CintelinkApp.ApiClient.Models
{
    public class LoginResponseModel
    {
        public int UserId { get; set; }
        public string Token { get; set; }
        public string Cookie { get; set; }
    }
}
