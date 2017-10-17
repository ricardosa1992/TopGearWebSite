using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopGear.Api;
using TopGear.Api.DataApi;
using TopGear.Api.Models;

namespace TopGear.Console
{
    static class Program
    {
        static void Main(string[] args)
        {
            //Ficar atento ao tipo de retorno que vc está esperando
            //Se o tipo que vc colocar em TopGearApi<Tipo> for diferente do que ele retorna, dá erro
            //quem manda no tipo de retorno é a string que vc passa
            //só pode ser: carro, categoria, agencia, cliente, ou seja, o nome das classes

            //Nesse exemplo você não passa Id, então ele retorna uma lista
            var carros = TopGearApi<IEnumerable<Carro>>.Get("carro");

            if (carros.Sucesso)
            {
                foreach(var car in carros.Dados)
                {
                    System.Console.WriteLine(car.Modelo + " - " + car.Marca + ": " + car.Placa);
                }
            }

            //Teste da API de voos

            var voos = TopGearApi<List<Voo>>.GetVoos();

            System.Console.ReadLine();
        }
    }
}
