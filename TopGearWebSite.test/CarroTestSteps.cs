using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TopGear.Api.DataAccess;
using TopGear.Api.DataApi;
using TopGear.Api.Models;

namespace TopGearWebSite.test
{
    [Binding]
    public class CarroTestSteps
    {
        IEnumerable<Carro> listaCarrosDisponiveis;
        IEnumerable<Carro> listaCarrosDisponiveisPorItem;
        Response<List<Carro>> responseCarrosDisponiveis;
        Response<List<Carro>> responseCarrosDisponiveisPorItem;
        int idAgencia;
        DateTime dtInicial;
        DateTime dtFinal;


        [Given(@"Eu quero buscar os carros por item")]
        public void GivenEuQueroBuscarOsCarrosPorItem()
        {
            //ScenarioContext.Current.Pending();
        }
        
        [Given(@"entrei com o id do (.*)")]
        public void GivenEntreiComOIdDo(int p0)
        {
            responseCarrosDisponiveisPorItem = CarroApi.ObterDisponiveis(new RequestCarrosDisponiveis
                        {
                            Inicial = dtInicial,
                            Final = dtFinal,
                            AgenciaId = idAgencia,
                            ItemId = p0,
                            Token = TopGearApiDataAccess<Carro>.GetToken()
                        });
            listaCarrosDisponiveisPorItem = CarroApiDataAccess.ObterDisponiveis(dtInicial, dtFinal, idAgencia, p0);
        }
        
        [Given(@"Eu quero buscar os carros disponiveis")]
        public void GivenEuQueroBuscarOsCarrosDisponiveis()
        {
            //ScenarioContext.Current.Pending();
        }

        [Given(@"digitei a (.*) e a '(.*)' e '(.*)'")]
        public void GivenDigiteiAEAE(int p0, string p1, string p2)
        {
            dtInicial = Convert.ToDateTime(p1);
            dtFinal = Convert.ToDateTime(p2);
            idAgencia = p0;

            responseCarrosDisponiveis = CarroApi.ObterDisponiveis(new RequestCarrosDisponiveis
            {
                Inicial = dtInicial,
                Final = dtFinal,
                AgenciaId = idAgencia,
                ItemId = null,
                Token = TopGearApiDataAccess<Carro>.GetToken()
            });

            listaCarrosDisponiveis = CarroApiDataAccess.ObterDisponiveis(dtInicial, dtFinal, p0,null);
            //ScenarioContext.Current.Pending();
        }

        [When(@"eu filtrar")]
        public void WhenEuFiltrar()
        {
            //ScenarioContext.Current.Pending();
        }

        [Then(@"o resultado deve ser os carros que possuem o item")]
        public void ThenOResultadoDeveSerOsCarrosQuePossuemOItem()
        {

            Assert.IsFalse(responseCarrosDisponiveisPorItem.Sucesso);
            //Assert.IsNotNull(listaCarrosDisponiveisPorItem);
        }

        [Then(@"o resultado deve ser os carros diponiveis")]
        public void ThenOResultadoDeveSerOsCarrosDiponiveis()
        {
            Assert.IsNotNull(listaCarrosDisponiveis);

        }
    }
}
