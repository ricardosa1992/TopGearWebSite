using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TopGear.Api.DataAccess;
using TopGear.Api.Models;

namespace WebSiteTeste
{
    [Binding]
    public class CarroTestSteps
    {
        IEnumerable<Carro> listaCarros;

        [Given(@"Eu quero buscar os carros disponíveis")]
        public void GivenEuQueroBuscarOsCarrosDisponiveis()
        {
            //ScenarioContext.Current.Pending();
        }
        
        [Given(@"digitei a (.*) e a '(.*)' e '(.*)'")]
        public void GivenDigiteiAEAE(int p0, string p1, string p2)
        {
            listaCarros = CarroApiDataAccess.ObterDisponiveis(Convert.ToDateTime(p0), Convert.ToDateTime(p1), p0);
            //ScenarioContext.Current.Pending();
        }
        
        [When(@"eu filtrar")]
        public void WhenEuFiltrar()
        {
            //ScenarioContext.Current.Pending();
        }
        
        [Then(@"o resultado deve ser os carros diponíveis")]
        public void ThenOResultadoDeveSerOsCarrosDiponiveis()
        {
            Assert.IsNotNull(listaCarros);

        }
    }
}
