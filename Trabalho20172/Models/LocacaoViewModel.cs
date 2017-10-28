using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public string horaRetirada { get; set; }

        public string horaEntrega { get; set; }

        public CarroViewModel carroSelecionado { get; set; }

        public int idCarroSelecionadoHidden { get; set; }

        public int QtdDiarias { get; set; }

        public double precoTotal { get; set; }

        public double precoDiaria { get; set; }

        public bool finalizada { get; set; }

        public List<CarroViewModel> listaCarrosDisponiveis { get; set; } = new List<CarroViewModel>();

        public List<SelectListItem> ListaDeAgencias { get; set; }

        //Dados do Cliente
        public int idCliente { get; set; }

        public string nomeCliente { get; set; }

        public string rua { get; set; }

        public string Bairro { get; set; }

        public string cidade { get; set; }

        public string estado { get; set; }

        public string telefone { get; set; }

        public string cpf { get; set; }

        public string cpfAcesso { get; set; }

        public int numCartao { get; set; }

        public string senha { get; set; }

        public string senhaAcesso { get; set; }

        //Lista de vôos
        public List<Voo> listaVoos { get; set; } = new List<Voo>();

        //Lista de Itens 
        public List<Item> listaItens { get; set; } = new List<Item>();

        //Campos criados para implementar o filtro
        public string Modo { get; set; }

        public List<int> listIdItensChecadosFiltro { get; set; } = new List<int>();

    }
}