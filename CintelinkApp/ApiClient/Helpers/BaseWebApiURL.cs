using CintelinkApp.ApiClient.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace CintelinkApp.ApiClient.Helpers
{
    public static class BaseWebApiURL
    {
        //private const string CintelinkApiURL = "https://dev.cintelink.com.ar/";
        //private const string CintelinkApiURL = "https://cintelink.com.ar/login.mod.php";
        public const string BASE_URL = "https://playground.cintelink.com.ar";

        const string PHP = ".mod.php";

        public const string LOGIN = "/login" + PHP;
        public const string FUEL_TANK = "/tank" + PHP;
        public const string EQUIPMENT = "/site" + PHP;

        public static string AddParameter(string url, Parameter parameter)
        {
            return url + "?" + parameter.Name + "=" + parameter.Value;
        }

        public static string AddParametersList(string url, List<Parameter> parameters)
        {
            string urlParameters = string.Empty;

            for (int i = 0; i < parameters.Count; i++)
            {
                if (!string.IsNullOrEmpty(parameters[i].Name) && !string.IsNullOrEmpty(parameters[i].Value))
                {
                    if (i == 0)
                        urlParameters = urlParameters + "" + parameters[i].Name + "=" + parameters[i].Value;
                    else
                        urlParameters = urlParameters + "&" + parameters[i].Name + "=" + parameters[i].Value;
                }
            }

            return urlParameters;
        }
    }
}
