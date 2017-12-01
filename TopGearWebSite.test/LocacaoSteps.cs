using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using TechTalk.SpecFlow;
using TopGear.Api.DataAccess;
using TopGear.Api.DataApi;
using TopGear.Api.Models;

namespace TopGearWebSite.test
{
    [Binding]
    public class LocacaoSteps
    {
        List<Carro> listaCarrosDisponiveis;
        List<Locacao> locacoesDoCliente;
        Cliente clienteReserva;
        Locacao novaLocacao;
        Carro carroSelecionado;
        int idNovaLocacao = 0;
        DateTime dtRetirada;
        DateTime dtEntrega;

        [Given(@"Eu quero efetuar a locacao de um carro disponivel entre as '(.*)' e '(.*)'")]
        public void GivenEuQueroEfetuarALocacaoDeUmCarroDisponivelEntreAsE(string p0, string p1)
        {
            dtRetirada = Convert.ToDateTime(p0);
            dtEntrega = Convert.ToDateTime(p1);
            listaCarrosDisponiveis = (List<Carro>)CarroApiDataAccess.ObterDisponiveis(dtRetirada, dtEntrega, null, null);

        }

        [Given(@"selecionei o carro desejado")]
        public void GivenSelecioneiOCarroDesejado()
        {
            carroSelecionado = listaCarrosDisponiveis[0];
            novaLocacao = new Locacao()
            {
                CarroId = carroSelecionado.Id,
                ClienteId = ClienteApiDataAccess.GetTodosClientes().First().Id,
                Agencia_RetiradaId = TopGearApi<List<Agencia>>.Get("agencia").Dados.First().Id,
                Agencia_EntregaId = TopGearApi<List<Agencia>>.Get("agencia").Dados.First().Id,
                Retirada = dtRetirada,
                Entrega = dtEntrega,
            };
        }
        
        [Given(@"Eu quero buscar as reservas de um cliente")]
        public void GivenEuQueroBuscarAsReservasDeUmCliente()
        {
            clienteReserva = new Cliente();
        }
        
        [Given(@"digitei o (.*) e (.*) do cliente")]
        public void GivenDigiteiOEDoCliente(string p0, string p1)
        {
            clienteReserva.CPF = p0;
            clienteReserva.Senha = p1;
        }
        
        [When(@"eu submeter os dados da locacao")]
        public void WhenEuSubmeterOsDadosDaLocacao()
        {
            idNovaLocacao = LocacaoApiDataAccess.Post(novaLocacao, "locacao");

        }

        [When(@"eu submeter os dados do cliente")]
        public void WhenEuSubmeterOsDadosDoCliente()
        {
            clienteReserva = ClienteApiDataAccess.Login(clienteReserva.CPF, clienteReserva.Senha);
            locacoesDoCliente = LocacaoApiDataAccess.ObterLocacoes(clienteReserva.Id);

        }

        [Then(@"o resultado deve ser uma locacao salva com sucesso")]
        public void ThenOResultadoDeveSerUmaLocacaoSalvaComSucesso()
        {
            Assert.AreNotEqual(0, idNovaLocacao);
            if (idNovaLocacao != 0)
            {
                LocacaoApiDataAccess.Delete(idNovaLocacao, "locacao");
            }
        }
        
        [Then(@"o resultado deve ser a lista de reservas do cliente")]
        public void ThenOResultadoDeveSerAListaDeReservasDoCliente()
        {
            Assert.IsNotNull(locacoesDoCliente);
        }
    }
}
