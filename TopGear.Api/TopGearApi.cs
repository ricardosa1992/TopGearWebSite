using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using TopGear.Api.Models;

namespace TopGear.Api
{
    public static class TopGearApi<T>
    {
        private static HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://topgearapi.azurewebsites.net/api/")
        };

        public static Response<T> Get(string relativePath)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(relativePath).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<Response<T>>().Result;
            }
            else return new Response<T> { Sucesso = false };
        }

        public static Response<T> Get(int id, string relativePath)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.GetAsync(relativePath + "/" + id.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<Response<T>>().Result;
            }
            else return new Response<T> { Sucesso = false };
        }

        public static Response<T> Post(T objeto, string relativePath)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PostAsJsonAsync(JsonConvert.SerializeObject(objeto), relativePath).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<Response<T>>().Result;
            }
            else return new Response<T> { Sucesso = false };
        }

        public static Response<T> Put(T objeto, int id, string relativePath)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PutAsJsonAsync(JsonConvert.SerializeObject(objeto), 
                                                                    relativePath + "/" + id.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<Response<T>>().Result;
            }
            else return new Response<T> { Sucesso = false };
        }

        public static Response<T> Delete(int id, string relativePath)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.DeleteAsync(relativePath + "/" + id.ToString()).Result;
            if (response.IsSuccessStatusCode)
            {
                return response.Content.ReadAsAsync<Response<T>>().Result;
            }
            else return new Response<T> { Sucesso = false };
        }
    }
}
