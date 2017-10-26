Feature: Locacao

Scenario Outline: Efetuar uma locacao 
	Given Eu quero efetuar a locacao de um carro disponivel entre as <dtInicial> e <dtFinal> 
	And selecionei o carro desejado
	When eu submeter os dados da locacao
	Then o resultado deve ser uma locacao salva com sucesso

	Examples: 
			| dtInicial    | dtFinal      |
			| '2017-01-01' | '2017-10-10' |


Scenario Outline: Buscar Locacoes do cliente
	Given Eu quero buscar as reservas de um cliente
	And digitei o <login> e <senha> do cliente
	When eu submeter os dados do cliente
	Then o resultado deve ser a lista de reservas do cliente

	Examples: 
			|  login          |   senha        |
			|  00000000191   |     5678     |
