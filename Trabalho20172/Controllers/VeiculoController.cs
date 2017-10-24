using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TopGear.Api;
using TopGear.Api.DataAccess;
using TopGear.Api.Models;
using Trabalho20172.Models;

namespace Trabalho20172.Controllers
{
    public class VeiculoController : BaseController
    {
        // GET: Veiculo
        [HttpPost]
        public ActionResult Veiculos(LocacaoViewModel dadosLocacao)
        {
            LocacaoViewModel viewModel = new LocacaoViewModel();

           

            if (dadosLocacao.Modo.Equals("filtro"))
            {
                int idLocalRetirada = dadosLocacao.idLocalRetiradaHidden;
                int idLocalEntrega = dadosLocacao.idLocalEntregaHidden;
                var horaRetirada = dadosLocacao.horaRetirada;
                var horaEntrega = dadosLocacao.horaEntrega;

                string dataRet = dadosLocacao.dataRetiradaHidden.Split(' ')[0];
                string[] dataRetVetor = dataRet.Split('/');
                string strDataRetirada = dataRetVetor[2] + "-" + dataRetVetor[1] + "-" + dataRetVetor[0];

                string dataEnt = dadosLocacao.dataEntregaHidden.Split(' ')[0];
                string[] dataEntVetor = dataEnt.Split('/');
                string strDataEntrega = dataEntVetor[2] + "-" + dataEntVetor[1] + "-" + dataEntVetor[0];

                DateTime dataRetirada = Convert.ToDateTime(strDataRetirada);
                dataRetirada = DateTime.Parse(dataRetirada.ToShortDateString() + " " + horaRetirada);
                DateTime dataEntrega = Convert.ToDateTime(strDataEntrega);
                dataEntrega = DateTime.Parse(dataEntrega.ToShortDateString() + " " + horaEntrega);

                viewModel.dataRetirada = dataRetirada;
                viewModel.dataEntrega = dataEntrega;
                viewModel.horaRetirada = horaRetirada;
                viewModel.horaEntrega = horaEntrega;
                viewModel.QtdDiarias = dadosLocacao.QtdDiarias;
                viewModel.precoDiaria = dadosLocacao.precoDiaria;
                viewModel.precoTotal = dadosLocacao.precoTotal;

                if (dadosLocacao.idCarroSelecionadoHidden != 0)
                {
                    Carro carro = TopGearApiDataAccess<Carro>.Get($"carro/porid/{dadosLocacao.idCarroSelecionadoHidden}");
                    viewModel.carroSelecionado = new CarroViewModel()
                    {
                        Id = carro.Id,
                        Modelo = carro.Modelo,
                        UrlImagem = carro.UrlImagem
                    };
                }
                List<CarroViewModel> listaCarrosFiltro = new List<CarroViewModel>();
               
                //Obtendo a Agencia de retirada
                viewModel.localRetirada = TopGearApiDataAccess<Agencia>.Get($"agencia/porid/{idLocalRetirada}");
                viewModel.localEntrega = (idLocalRetirada == idLocalEntrega || idLocalEntrega == 0) ? viewModel.localRetirada : TopGearApiDataAccess<Agencia>.Get($"agencia/porid/{idLocalEntrega}");


                //  All checked checkboxes are sent via the postback. Save this parameters in a list:
                foreach (string s in Request.Params.Keys)
                {
                    if (s.ToString().IndexOf("chkBox_") == 0)
                    {
                        viewModel.listIdItensChecadosFiltro.Add(Convert.ToInt32(Request.Form[s]));
                 
                        listaCarrosFiltro =  BuscarCarrosDisponiveis(viewModel.dataRetirada, viewModel.dataEntrega, idLocalRetirada, Convert.ToInt32(Request.Form[s]));
                        foreach (var carroFiltro in listaCarrosFiltro)
                        {
                            bool achou = viewModel.listaCarrosDisponiveis.Any(m => m.Id == carroFiltro.Id);
                            if (!achou)
                            {
                                viewModel.listaCarrosDisponiveis.Add(carroFiltro);
                            }
                        }
                    }
                }

                if(viewModel.listIdItensChecadosFiltro.Count == 0)
                {
                    viewModel.listaCarrosDisponiveis = BuscarCarrosDisponiveis(viewModel.dataRetirada, viewModel.dataEntrega, idLocalRetirada, null);
                }

            }
            else
            {

                //Obtendo os parâmetros selecionados para retirada/entrega
                int idLocalRetirada = Convert.ToInt32(Request.Form["listaLocalRetirada"]);
                int idLocalEntrega = Convert.ToInt32(Request.Form["listaLocalEntrega"]);
                var horaRetirada = Request.Form["pick-up-time"];
                var horaEntrega = Request.Form["drop-off-time"];

                string dataRet = Request.Form["pick-up-date"];
                string[] dataRetVetor = dataRet.Split('/');
                string strDataRetirada = dataRetVetor[2] + "-" + dataRetVetor[1] + "-" + dataRetVetor[0];

                string dataEnt = Request.Form["drop-off-date"];
                string[] dataEntVetor = dataEnt.Split('/');
                string strDataEntrega = dataEntVetor[2] + "-" + dataEntVetor[1] + "-" + dataEntVetor[0];

                DateTime dataRetirada = Convert.ToDateTime(strDataRetirada);
                dataRetirada = DateTime.Parse(dataRetirada.ToShortDateString() + " " + horaRetirada);
                DateTime dataEntrega = Convert.ToDateTime(strDataEntrega);
                dataEntrega = DateTime.Parse(dataEntrega.ToShortDateString() + " " + horaEntrega);

                viewModel.dataRetirada = dataRetirada;
                viewModel.dataEntrega = dataEntrega;
                viewModel.horaRetirada = horaRetirada;
                viewModel.horaEntrega = horaEntrega;

                //Obtendo a Agencia de retirada
                viewModel.localRetirada = TopGearApiDataAccess<Agencia>.Get($"agencia/porid/{idLocalRetirada}");
                viewModel.localEntrega = (idLocalRetirada == idLocalEntrega || idLocalEntrega == 0) ? viewModel.localRetirada : TopGearApiDataAccess<Agencia>.Get($"agencia/porid/{idLocalEntrega}");
                
                //Obtendo a quantidade de Diárias
                TimeSpan nod = (dataEntrega - dataRetirada);

                if (nod.TotalDays < 1)
                    viewModel.QtdDiarias = 1;
                else
                    viewModel.QtdDiarias = (nod.TotalHours % 24 == 0) ? (int)nod.TotalDays : ((int)nod.TotalDays) + 1;


                viewModel.listaCarrosDisponiveis = BuscarCarrosDisponiveis(viewModel.dataRetirada, viewModel.dataEntrega, idLocalRetirada, null);
               
            }

            //Obtendo a lista de agencias para a Edição
            viewModel.ListaDeAgencias = ListaDeAgencias();

            //Obtendo a lista de Itens do filtro
            viewModel.listaItens = TopGearApiDataAccess<List<Item>>.Get("item");
            viewModel.Modo = "filtro";

            return View(viewModel);
        }

        public List<CarroViewModel> BuscarCarrosDisponiveis(DateTime dataRetirada, DateTime dataEntrega,int idAgencia,int? idItem)
        {
          
            var listaCarros = CarroApiDataAccess.ObterDisponiveis(dataRetirada,dataEntrega,idAgencia,idItem);

            List<CarroViewModel> listaCarrosDispopniveis = new List<CarroViewModel>();

            foreach (var carro in listaCarros)
            {
                var categoria = TopGearApiDataAccess<Categoria>.Get($"categoria/porid/{carro.CategoriaId}");
                CarroViewModel carroViewModel = new CarroViewModel { Id = carro.Id, Ano = carro.Ano, Marca = carro.Marca, Modelo = carro.Modelo, UrlImagem = carro.UrlImagem, categoria = categoria };
                listaCarrosDispopniveis.Add(carroViewModel);
            }

            return listaCarrosDispopniveis;

        }

        

    }
}