using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TopGear.Api.DataAccess;
using TopGear.Api.Models;

namespace TopGearWebSite.test
{
    [Binding]
    public class LocacaoSteps
    {
        List<Carro> listaCarrosDisponiveis;
        List<Locacao> locacoesDoCliente;
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
            listaCarrosDisponiveis = (List<Carro>)CarroApiDataAccess.ObterDisponiveis(dtRetirada, dtEntrega , null, null);
        }
        
        [Given(@"selecionei o carro desejado")]
        public void GivenSelecioneiOCarroDesejado()
        {
            carroSelecionado = listaCarrosDisponiveis[0];
            novaLocacao = new Locacao()
            {
                CarroId = carroSelecionado.Id,
                Agencia_RetiradaId = carroSelecionado.AgenciaId,
                Agencia_EntregaId = carroSelecionado.AgenciaId,
                Retirada = dtRetirada,
                Entrega = dtEntrega,
            };
        }
        
        [Given(@"Eu quero buscar as reservas de um cliente")]
        public void GivenEuQueroBuscarAsReservasDeUmCliente()
        {
            
        }
        
        [Given(@"digitei o (.*) do cliente")]
        public void GivenDigiteiODoCliente(int p0)
        {
            //ScenarioContext.Current.Pending();
        }
        
        [When(@"eu submeter os dados")]
        public void WhenEuSubmeterOsDados()
        {
            var idNovaLocacao = TopGearApiDataAccess<Locacao>.Post(novaLocacao, "locacao");
        }
        
        [Then(@"o resultado deve ser uma locacao salva com sucesso")]
        public void ThenOResultadoDeveSerUmaLocacaoSalvaComSucesso()
        {
            Assert.AreNotEqual(0, idNovaLocacao);
            if(idNovaLocacao != 0)
            {
                TopGearApiDataAccess<Locacao>.Delete(idNovaLocacao, "locacao");
            }
        }
        
        [Then(@"o resultado deve ser a lista de reservas do cliente")]
        public void ThenOResultadoDeveSerAListaDeReservasDoCliente()
        {
            //ScenarioContext.Current.Pending();
        }
    }
}
