Feature: Carro
	Preciso buscar os carros disponíveis dentro de un intervalo de data

@mytag
Scenario Outline: Buscar carros disponíveis 
	Given Eu quero buscar os carros disponíveis
	And digitei a <agencia> e a <dtInicial> e <dtFinal>
	When eu filtrar
	Then o resultado deve ser os carros diponíveis

	Examples: 
			| agencia | dtInicial  | dtFinal     |
			|   17    |'2017-10-01'| '2017-10-10'|