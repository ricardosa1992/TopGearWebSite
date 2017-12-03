using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;
using TopGear.Api.DataApi;
using TopGear.Api.Models;

namespace TopGearWebSite.test
{
    [TestClass]
    [Binding]
    public class PassagemIntegracaoTestSteps
    {
        private Voo voo;

        [Given(@"Eu sou um cliente alugando um veiculo")]
        public void GivenEuSouUmClienteAlugandoUmVeiculo()
        {
            
        }
        
        [Given(@"eu selecionei uma passagem e decidi comprar")]
        public void GivenEuSelecioneiUmaPassagemEDecidiComprar()
        {
            voo = PassagemApi.GetTodosVoos().Find(v => v.idVoo > 0);
        }
        
        [When(@"eu clicar em comprar")]
        public void WhenEuClicarEmComprar()
        {
            
        }
        
        [Then(@"a passagem deve ser comprada corretamente")]
        public void ThenAPassagemDeveSerCompradaCorretamente()
        {
            int idCompra = PassagemApi.InserirCompra("3232", "32132132132");

            Assert.IsTrue(idCompra > 0);

            int idTicket = -1;

            int numAcento = (new Random(30)).Next(1, 15);

            if (idCompra != -1)
            {
                idTicket = PassagemApi.InserirTicket(idCompra, voo.idVoo, "Teste", "3232", "32132132132", new DateTime(1990, 01, 01), numAcento);
                Assert.IsTrue(idTicket > 0);
            }
        }

        [TestMethod]
        public void GambiarraProSonarBurro()
        {
            GivenEuSelecioneiUmaPassagemEDecidiComprar();
            ThenAPassagemDeveSerCompradaCorretamente();
        }
    }
}
