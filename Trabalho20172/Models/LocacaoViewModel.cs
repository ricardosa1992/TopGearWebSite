using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TopGear.Api.Models;

namespace Trabalho20172.Models
{
    public class LocacaoViewModel
    {

        public int idLocalRetiradaHidden { get; set; }

        public Agencia localRetirada { get; set; }

        public Agencia localEntrega { get; set; }

        public int idLocalEntregaHidden { get; set; }

        public DateTime dataRetirada { get; set; }

        public string dataRetiradaHidden { get; set; }

        public DateTime dataEntrega { get; set; }

        public string dataEntregaHidden { get; set; }

        public Carro carroSelecionado { get; set; }

        public int idCarroSelecionadoHidden { get; set; }

        public int QtdDiarias { get; set; }

        public double precoTotal { get; set; }

        public List<CarroViewModel> listaCarrosDisponiveis { get; set; } = new List<CarroViewModel>();

        public List<SelectListItem> ListaDeAgencias { get; set; }

        //Dados do Cliente

        public string nomeCliente { get; set; }

        public string rua { get; set; }

        public string Bairro { get; set; }

        public string cidade { get; set; }

        public string estado { get; set; }

        public string telefone { get; set; }

        public string cpf { get; set; }

        public int numCartao { get; set; }

    }
}