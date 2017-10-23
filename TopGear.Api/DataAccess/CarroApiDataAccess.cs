using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopGear.Api.DataApi;
using TopGear.Api.Models;

namespace TopGear.Api.DataAccess
{
    public class CarroApiDataAccess : TopGearApiDataAccess<Carro>
    {
        public static IEnumerable<Carro> ObterDisponiveis(DateTime dtInicial, DateTime dtFinal, int? idAgencia, int? idItem)
        {
            var req = new RequestCarrosDisponiveis
            {
                Inicial = dtInicial,
                Final = dtFinal,
                AgenciaId = idAgencia,
                ItemId = idItem,
                Token = GetToken()
            };

            var listaCarros = CarroApi.ObterDisponiveis(req);
            if (listaCarros.Sucesso)
            {
                return listaCarros.Dados;
            }
            return null;

        }

    }
}
