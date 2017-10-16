Feature: CarroTest
	Preciso buscar os carros disponiveis dentro de un 


@mytag
Scenario Outline: Buscar carros por Item
	Given Eu quero buscar os carros por item
	And entrei com um <item>
	When eu filtrar
	Then o resultado deve ser os carros que possuem o item

	Examples: 
			|  item        | 
			| 'Teto Solar' |

@mytag
Scenario Outline: Buscar carros disponiveis 
	Given Eu quero buscar os carros disponiveis
	And digitei a <agencia> e a <dtInicial> e <dtFinal>
	When eu filtrar
	Then o resultado deve ser os carros diponiveis

	Examples: 
			| agencia| dtInicial  | dtFinal     |
			|   17   |'2017-10-01'| '2017-10-10'|