Feature: PassagemIntegracaoTest
	In order to garantir funcionamento da integração com a API de passagens
	As a cliente
	I want to comprar uma passagem aerea

@mytag
Scenario: Comprar Passagem
	Given Eu sou um cliente alugando um veiculo
	And eu selecionei uma passagem e decidi comprar
	When eu clicar em comprar
	Then a passagem deve ser comprada corretamente
