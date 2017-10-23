Feature: Locacao

Scenario Outline: Efetuar uma locacao 
	Given Eu quero efetuar a locacao de um carro disponivel entre as <dtInicial> e <dtFinal> 
	And selecionei o carro desejado
	When eu submeter os dados
	Then o resultado deve ser uma locacao salva com sucesso

	Examples: 
			| dtInicial    | dtFinal      |
			| '2017-01-01' | '2017-12-30' |


Scenario Outline: Buscar Locacoes do cliente
	Given Eu quero buscar as reservas de um cliente
	And digitei o <idCliente> do cliente
	When eu submeter os dados
	Then o resultado deve ser a lista de reservas do cliente

	Examples: 
			|  idCliente    | 
			|        5      |
