using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using GIns.Shared;
using Newtonsoft.Json;

namespace GIns.Client
{
    class clsSecurity
    {
        static UserModel newToken = null;

        public async Task<UserModel> GetSecurityToken(string UrlAddress, UserModel userParam)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(UrlAddress);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                //StringContent content = new StringContent(JsonConvert.SerializeObject(userParam), Encoding.UTF8, "application/json");

                // HTTP POST to get token
                HttpResponseMessage response1 = await client.PostAsync("api/User/authenticate", clsGlobal.GetStringContent_UTF8(userParam)); // content); //.Result();
                if (response1.IsSuccessStatusCode)
                {
                    //Return for windows Client
                    //newToken = await response1.Content.ReadAsStreamAsync();// <UserModel>();

                    var stringResponse = await response1.Content.ReadAsStringAsync();

                    UserModel newToken = JsonConvert.DeserializeObject<UserModel>(stringResponse);
                }
            }

            return newToken;
        }
    }
}

