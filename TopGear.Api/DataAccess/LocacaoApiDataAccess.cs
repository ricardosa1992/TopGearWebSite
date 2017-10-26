using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopGear.Api.DataApi;
using TopGear.Api.Models;

namespace TopGear.Api.DataAccess
{
    public class LocacaoApiDataAccess : TopGearApiDataAccess<Locacao>
    {
        public static List<Locacao> ObterLocacoes(int idCliente)
        {
            var req = new Request<int>
            {
               Dados = idCliente
            };

            var locacoes = LocacaoApi.ObterLocacoes(req);
            if (locacoes.Sucesso)
            {
                return locacoes.Dados;
            }
            return null;

        }
    }
}
