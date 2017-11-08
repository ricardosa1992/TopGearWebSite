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
    class LocacaoApi : TopGearApi<Locacao>
    {
     
        public static Response<List<Locacao>> ObterLocacoes(Request<int> req)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PostAsJsonAsync("locacao/obterlocacoes", req).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<Response<List<Locacao>>>().Result;
                return result;
            }
            else return new Response<List<Locacao>> { Sucesso = false };
        }

        internal static Response<Locacao> CancelarLocacao(Request<int> req)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = client.PostAsJsonAsync("locacao/cancelarlocacao", req).Result;
            if (response.IsSuccessStatusCode)
            {
                var result = response.Content.ReadAsAsync<Response<Locacao>>().Result;
                return result;
            }
            else return new Response<Locacao> { Sucesso = false };
        }
    }
}
