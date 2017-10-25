Feature: Login

@mytag
Scenario Outline: Login do usuario
	Given Eu sou um usuario anonimo
	And Eu digitei o <login> e <senha>
	When Eu submter os dados
	Then O usuario tem que existir 

	Examples: 
		      |    login          | senha|
			  | 00000000191       | 5678 |