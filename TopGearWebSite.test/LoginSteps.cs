using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using TechTalk.SpecFlow;
using TopGear.Api.DataAccess;
using TopGear.Api.Models;

namespace TopGearWebSite.test
{
    [Binding]
    public class LoginSteps
    {
        Cliente clienteExiste;
        Cliente clienteLogin;

        [Given(@"Eu sou um usuario anonimo")]
        public void GivenEuSouUmUsuarioAnonimo()
        {
            clienteLogin = new Cliente();
        }

        [Given(@"Eu digitei o (.*) e (.*)")]
        public void GivenEuDigiteiOE(string p0, string p1)
        {
            clienteLogin.CPF = p0;
            clienteLogin.Senha = p1;
        }

        [When(@"Eu submter os dados")]
        public void WhenEuSubmterOsDados()
        {
            clienteExiste = ClienteApiDataAccess.Login(clienteLogin.CPF, clienteLogin.Senha);
        }

        [Then(@"O usuario tem que existir")]
        public void ThenOUsuarioTemQueExistir()
        {
            Assert.IsNotNull(clienteExiste);
        }
    }
}
