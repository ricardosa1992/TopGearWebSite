Feature: CarroTest
	Preciso buscar os carros disponiveis dentro de un intervalo de data

@mytag
Scenario Outline: Buscar carros disponiveis 
	Given Eu quero buscar os carros disponiveis
	And digitei a <agencia> e a <dtInicial> e <dtFinal>
	When eu filtrar
	Then o resultado deve ser os carros diponiveis

	Examples: 
			| agencia| dtInicial  | dtFinal     |
			|   17   |'2017-10-01'| '2017-10-10'|