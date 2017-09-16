using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TopGear.Api;
using TopGear.Api.Models;

namespace TopGear.Console
{
    class Program
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

            //Aqui passa o id, então retorna um carro só
            var carro = TopGearApi<Carro>.Get(99, "carro");

            if (carro.Sucesso)
            {
                var car2 = carro.Dados;
                System.Console.WriteLine(car2.Modelo + " - " + car2.Marca + ": " + car2.Placa);
            }

            System.Console.ReadLine();
        }
    }
}
