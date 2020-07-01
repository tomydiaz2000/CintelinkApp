using Akavache;
using CintelinkApp.ApiClient.Helpers;
using CintelinkApp.ApiClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Reactive.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CintelinkApp.ApiClient
{
    public class CintelinkRest : ICintelinkRest
    {
        HttpClient _httpClient;

        public CintelinkRest()
        {
            _httpClient = new HttpClient();
        }

        public async Task<bool> Login(LoginRequestModel model)
        {
            bool boolResponse = false;

            string url = BaseWebApiURL.BASE_URL + BaseWebApiURL.LOGIN;

            string contentType = "application/json";
            Object json = new JObject
            {
                {"user", model.User},
                {"pass", model.Pass},
                {"accion", "LoginWSUser"},
                {"format", "json_object" }
            };

            try
            {
                var response = await _httpClient.PostAsync(url, new StringContent(json.ToString(), Encoding.UTF8, contentType));

                var getCookie = response.Headers.GetValues("Set-Cookie");

                var loginJson = await response.Content.ReadAsStringAsync();

                JObject data = JObject.Parse(loginJson);

                if (data["error"].ToString() == "0")
                {
                    LoginResponseModel loginModel = new LoginResponseModel();

                    loginModel.Token = data["data"][0]["token"].ToString();
                    loginModel.UserId = (int)data["data"][0]["id_usuario"];
                    loginModel.Cookie = getCookie.First();

                    if (!string.IsNullOrEmpty(loginModel.Token))
                    {
                        await BlobCache.LocalMachine.InsertObject("token", loginModel.Token);
                        await BlobCache.LocalMachine.InsertObject("id_user", loginModel.UserId);
                        await BlobCache.LocalMachine.InsertObject("cookie", loginModel.Cookie);
                        await BlobCache.LocalMachine.InsertObject("name_user", model.User);
                        await BlobCache.LocalMachine.InsertObject("pass_user", model.Pass);
                    }

                    boolResponse = true;
                }
            }
            catch(Exception e)
            {
                return false;
            }
            
            return boolResponse;
        }

        public async Task<List<ListFuelTanksResponseModel.Row>> GetFuelTanks(ListFuelTanksRequestModel model)
        {
            List<Parameter> listParameter = new List<Parameter>();

            #region parameters
            Parameter action = new Parameter
            {
                Name = "accion",
                Value = model.Accion
            };

            listParameter.Add(action);

            Parameter inicio = new Parameter
            {
                Name = "inicio",
                Value = model.Inicio.ToString()
            };

            listParameter.Add(inicio);

            Parameter qty = new Parameter
            {
                Name = "qty",
                Value = model.Qty.ToString()
            };

            listParameter.Add(qty);

            Parameter token = new Parameter
            {
                Name = "token",
                Value = await GetToken()
            };

            listParameter.Add(token);

            Parameter Pfusr = new Parameter
            {
                Name = "pfusr",
                Value = await GetUserId()
            };
            listParameter.Add(Pfusr);

            Parameter EquipoId = new Parameter
            {
                Name = "id_equipo",
                Value = model.EquipoId.ToString()
            };

            listParameter.Add(EquipoId);

            #endregion

            string url = BaseWebApiURL.AddParametersList("", listParameter);

            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(BaseWebApiURL.BASE_URL + BaseWebApiURL.FUEL_TANK),
                Method = HttpMethod.Post,
                Content = new StringContent(url, Encoding.UTF8, "application/x-www-form-urlencoded")
            };

            request.Headers.Add("Cookie", await GetCookie());

            try
            {
                var response = await _httpClient.SendAsync(request);

                var loginJson = await response.Content.ReadAsStringAsync();

                var convertModel = JsonConvert.DeserializeObject<ListFuelTanksResponseModel.Main>(loginJson);

                var modelresponse = convertModel.data.rows;

                return modelresponse.ToList();
            }
            catch (Exception e)
            {
                return new List<ListFuelTanksResponseModel.Row>();
            }         
        }

        public async Task<List<ListEquipmentsResponseModel.Row>> GetEquipments(string actionRequest)
        {
            #region Parameters
            List<Parameter> listParameter = new List<Parameter>();
            Parameter action = new Parameter
            {
                Name = "accion",
                Value = actionRequest
            };
            listParameter.Add(action);
            Parameter token = new Parameter
            {
                Name = "token",
                Value = await GetToken()
            };

            listParameter.Add(token);

            Parameter Pfusr = new Parameter
            {
                Name = "pfusr",
                Value = await GetUserId()
            };

            listParameter.Add(Pfusr);
            #endregion

            string url = BaseWebApiURL.AddParametersList("", listParameter);

            var request = new HttpRequestMessage()
            {
                RequestUri = new Uri(BaseWebApiURL.BASE_URL + BaseWebApiURL.EQUIPMENT),
                Method = HttpMethod.Post,
                Content = new StringContent(url, Encoding.UTF8, "application/x-www-form-urlencoded")
            };

            request.Headers.Add("Cookie", await GetCookie());

            try
            {
                var response = await _httpClient.SendAsync(request);

                var loginJson = await response.Content.ReadAsStringAsync();

                var convertModel = JsonConvert.DeserializeObject<ListEquipmentsResponseModel.Main>(loginJson);

                var modelresponse = convertModel.data.rows;

                return modelresponse.ToList();
            }
            catch (Exception e)
            {
                return new List<ListEquipmentsResponseModel.Row>();
            }
        }
        #region Helpers
        async Task<string> GetToken()
        {
            return await BlobCache.LocalMachine.GetObject<string>("token");
        }

        async Task<string> GetUserId()
        {
            return await BlobCache.LocalMachine.GetObject<string>("id_user");
        }

        async Task<string> GetCookie()
        {
            return await BlobCache.LocalMachine.GetObject<string>("cookie");
        }
        #endregion
    }
}
