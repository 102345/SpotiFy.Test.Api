# SpotiFy.Test.Api
Desafio de Loja de Ecommerce com consumo de serviço Spotify

Desafio:
Um e-commerce de discos de vinil resolveu implementar um programa de fidelidade
baseado em cashback* para aumentar o volume de vendas e conquistar novos clientes.
Após algumas reuniões, o time comercial definiu uma tabela de porcentagem de cashback
por gênero musical e dia da semana:
Gênero Domingo Segunda Terça Quarta Quinta Sexta Sábado
POP 25% 7% 6% 2% 10% 15% 20%
MPB 30% 5% 10% 15% 20% 25% 30%
CLASSIC 35% 3% 5% 8% 13% 18% 25%
ROCK 40% 10% 15% 15% 15% 20% 40%
Desenvolva um serviço de back-end que será responsável por efetuar vendas de discos de
vinil e calcular o valor de cashback para o cliente respeitando as regras da tabela acima.

Considerar os seguintes critérios de aceite:
● O serviço deverá disponibilizar uma API REST contendo as seguintes operações:
○ Consultar o catálogo de discos de forma paginada, filtrando por gênero e
ordenando de forma crescente pelo nome do disco;
○ Consultar o disco pelo seu identificador;
○ Consultar todas as vendas efetuadas de forma paginada, filtrando pelo range
de datas (inicial e final) da venda e ordenando de forma decrescente pela
data da venda;
○ Consultar uma venda pelo seu identificador;
○ Registrar uma nova venda de discos calculando o valor total de cashback
considerando a tabela.
● Para alimentar o catálogo de discos, o seu serviço deverá consumir a ​API do Spotify
e retornar os 50 primeiros discos de cada gênero;

Atribua um identificador único e um preço qualquer para cada disco;
● Cada venda poderá ter 1 ou mais discos selecionados, o cashback deverá ser
calculado e armazenado individualmente para cada disco bem como o cashback
total da venda.

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
