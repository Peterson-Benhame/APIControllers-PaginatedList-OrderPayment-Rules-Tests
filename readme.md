# PETERSON BENHAME

Ol�, tudo bem? 

Meu nome � Peterson Benhame e sou um Desenvolvedor Full-Stack com ampla experi�ncia em diversas �reas de desenvolvimento de software, incluindo web, mobile, API e banco de dados. Tenho um vasto conhecimento em linguagens e tecnologias como C#, ASPNET, ASPNET core, .NET, .NET core, Windows Forms, Entities Framework, Flutter, Dart, React.js, Html, Css, Sass, Javascript(ES6+), Jquery, Typescript, Node.js B�sico, Styled Components, Bootstrap, Redux, DDD, MCV, Modulos, Banco de dados Mysql, SQL, Versionamento de c�digo com Git e Github, Metodologia �gil Scrum e Kanban.

Trabalho com uma abordagem hol�stica no desenvolvimento de software, levando em considera��o tanto a experi�ncia do usu�rio quanto a funcionalidade do sistema. Al�m disso, possuo habilidades de gerenciamento e coordena��o de equipes de desenvolvedores, desde a concep��o at� a implanta��o de projetos.


# Parte1Controller
Esse c�digo define um servi�o que retorna um n�mero aleat�rio e um controlador que utiliza esse servi�o 
para trazer esse n�mero aleat�rio quando uma requisi��o � feita na rota definida. 
O n�mero aleat�rio � gerado a partir de um novo identificador �nico a cada vez que o servi�o � chamado.

# Parte2Controller
Esse c�digo � sobre uma API que retorna informa��es de uma lista de produtos e de clientes. 
� poss�vel acessar a lista de produtos e a lista de clientes atrav�s de uma solicita��o GET, que possui como par�metros o n�mero da p�gina e o tamanho da p�gina.

Para isso, o c�digo cont�m uma classe de modelo para clientes e outra para produtos. 
Tamb�m h� uma classe de servi�o gen�rica que pode ser usada para buscar listas paginadas, onde ela retorna uma lista de itens da p�gina e a quantidade total de itens dispon�veis. 
Al�m disso, h� uma classe de ajuda que ajuda a gerar uma lista paginada.

# Parte3Controller
 Esse c�digo tem uma classe chamada Parte3Controller, que � um controlador com um m�todo chamado PlaceOrder. 
 Esse m�todo cria um pagamento para uma ordem de compra com uma forma de pagamento espec�fica, 
 como cart�o de cr�dito, PayPal ou Pix. Ele recebe tr�s par�metros: paymentMethod, que � a forma de pagamento; 
 paymentValue, que � o valor do pagamento; e customerId, que � o ID do cliente que est� pagando. 
 Para processar o pagamento, o m�todo chama o servi�o OrderService. Esse servi�o utiliza o padr�o Factory Method 
 para obter a classe correta de pagamento com base no tipo de pagamento escolhido. H� tr�s classes que implementam a interface IPaymentMethod, 
 representando as formas de pagamento dispon�veis: CreditCard, PayPal e Pix. 
 Essas classes cont�m a l�gica para fazer o pagamento usando cada forma de pagamento especificada. 
 O servi�o OrderService utiliza a classe de pagamento correta para fazer o pagamento e cria uma nova ordem de compra, salvando-a no banco de dados. 
 Esse c�digo segue o princ�pio Open-Closed, permitindo a adi��o de novas formas de pagamento sem modificar o c�digo existente.

# Parte4Controller
Essa API tem uma regra de neg�cio para permitir que um cliente possa fazer uma compra, 
sendo que um cliente n�o registrado n�o pode fazer compras, um cliente registrado n�o pode fazer mais de uma 
compra por m�s e um cliente que nunca fez compras antes s� pode fazer uma primeira compra de at� R$ 100,00.

# Testes
Para testar o projeto, foi utilizado o framework de testes Xunit. 
Para criar um projeto de testes, clique com o bot�o direito do mouse no projeto principal e selecione a 
op��o "Adicionar" e depois "Novo Projeto". Na janela que se abre, procure por "xunit" e selecione o 
modelo "Projeto de Teste do xUnit". Ap�s criar o projeto, delete a classe padr�o que j� vem nele e copie a 
classe "CustomerServiceTests" do projeto principal, que est� na pasta "Testes". Esta classe cont�m uma s�rie de 
testes para a classe "BaseService" metodo "CanPurchase". 
Ao rodar estes testes, � poss�vel verificar se a classe "BaseService" est� funcionando corretamente e sem erros."# APIControllers-PaginatedList-OrderPayment-Rules-Tests"  
"# APIControllers-PaginatedList-OrderPayment-Rules-Tests"  
