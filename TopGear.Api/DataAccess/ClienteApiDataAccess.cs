using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopGear.Api.DataApi;
using TopGear.Api.Models;

namespace TopGear.Api.DataAccess
{
    public class ClienteApiDataAccess: TopGearApiDataAccess<Cliente>
    {
        public static Cliente Login(string login, string senha)
        {
            var req = new LoginRequest
            {
               CPF = login,
               Senha = senha,
               Token = GetToken()
            };

            var cliente = ClienteApi.Login(req);
            if (cliente.Sucesso)
            {
                return cliente.Dados;
            }
            return null;

        }

        public static Cliente GetClientePorId(int id)
        {
            var result = TopGearApi<Cliente>.GetAuth(id, "cliente");

            if (result.Sucesso)
            {
                return result.Dados;
            }
            return null;

        }

        public static List<Cliente> GetTodosClientes()
        {
            var result = TopGearApi<List<Cliente>>.GetAuth("cliente");

            if (result.Sucesso)
            {
                return result.Dados;
            }
            return null;

        }


    }
}
