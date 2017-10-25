using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TopGear.Api.Models;

namespace TopGear.Api.DataApi
{
    public class ClienteApi : TopGearApi<Cliente>
    {
        public static Response<Cliente> Login(LoginRequest req)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PostAsJsonAsync("cliente/Login", req).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<Response<Cliente>>().Result;
                return result;
            }
            else return new Response<Cliente> { Sucesso = false };
        }
    }
}
