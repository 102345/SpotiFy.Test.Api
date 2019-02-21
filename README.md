# SpotiFy.Test.Api
Desafio de Loja de Ecommerce com consumo de serviço Spotify

Para testar o projeto siga as seguintes instrução na ordem :

1. Instalar o SDGB Ms SQL Server Express 2012.

2. Rodar os scripts que se encontram na pasta \Script_Database na seguinte ordem: 
a - Create_Database.sql
b - Create_Table_Album.sql
c-  Create_Table_CashBack.sql
d - Create_Table_Venda.sql
e - Create_Table_Preco.sql
f - Popular_Tabela_Cashback.sql

3. Abrir o arquivo Web.Config do projeto BeBlue.Ecommerce.Api2.cspro e localizar a chave connectionStrings 
e mudar o parametro connectionString para sua string de conexao local.

4. Rodar o projeto BeBlue.Ecommerce.Api2

Obs : Para testar o serviço : api/v1/LojaDisco/GravarVendas/ informar no corpo de envio o seguinte formato JSON ( Exemplo ) :

[
								{"id" : 0,
								"IdVenda":0,
								"KeyDisc":"7r7ehULhUrCWhy9VZu5BnV",
								"Quantidade": 1, 
								"ValorVenda": 0, 
								"ValorCashBack":0,
								"ValorVendaTotal": 0,
								"ValorCashBackTotal": 0,
								"DataVenda": "21/02/2019" },
								{"id" : 0,
								"IdVenda":0,
								"KeyDisc":"4IjcmdZGlWtNP83pts9Ktg",
								"Quantidade": 1, 
								"ValorVenda": 0, 
								"ValorCashBack":0,
								"ValorVendaTotal": 0,
								"ValorCashBackTotal": 0,
								"DataVenda": "21/02/2019" }
	]
