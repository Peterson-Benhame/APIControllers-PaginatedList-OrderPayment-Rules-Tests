# PETERSON BENHAME

Olá, tudo bem? 

Meu nome é Peterson Benhame e sou um Desenvolvedor Full-Stack com ampla experiência em diversas áreas de desenvolvimento de software, incluindo web, mobile, API e banco de dados. Tenho um vasto conhecimento em linguagens e tecnologias como C#, ASPNET, ASPNET core, .NET, .NET core, Windows Forms, Entities Framework, Flutter, Dart, React.js, Html, Css, Sass, Javascript(ES6+), Jquery, Typescript, Node.js Básico, Styled Components, Bootstrap, Redux, DDD, MCV, Modulos, Banco de dados Mysql, SQL, Versionamento de código com Git e Github, Metodologia Ágil Scrum e Kanban.

Trabalho com uma abordagem holística no desenvolvimento de software, levando em consideração tanto a experiência do usuário quanto a funcionalidade do sistema. Além disso, possuo habilidades de gerenciamento e coordenação de equipes de desenvolvedores, desde a concepção até a implantação de projetos.


# Parte1Controller
Esse código define um serviço que retorna um número aleatório e um controlador que utiliza esse serviço 
para trazer esse número aleatório quando uma requisição é feita na rota definida. 
O número aleatório é gerado a partir de um novo identificador único a cada vez que o serviço é chamado.

# Parte2Controller
Esse código é sobre uma API que retorna informações de uma lista de produtos e de clientes. 
É possível acessar a lista de produtos e a lista de clientes através de uma solicitação GET, que possui como parâmetros o número da página e o tamanho da página.

Para isso, o código contém uma classe de modelo para clientes e outra para produtos. 
Também há uma classe de serviço genérica que pode ser usada para buscar listas paginadas, onde ela retorna uma lista de itens da página e a quantidade total de itens disponíveis. 
Além disso, há uma classe de ajuda que ajuda a gerar uma lista paginada.

# Parte3Controller
 Esse código tem uma classe chamada Parte3Controller, que é um controlador com um método chamado PlaceOrder. 
 Esse método cria um pagamento para uma ordem de compra com uma forma de pagamento específica, 
 como cartão de crédito, PayPal ou Pix. Ele recebe três parâmetros: paymentMethod, que é a forma de pagamento; 
 paymentValue, que é o valor do pagamento; e customerId, que é o ID do cliente que está pagando. 
 Para processar o pagamento, o método chama o serviço OrderService. Esse serviço utiliza o padrão Factory Method 
 para obter a classe correta de pagamento com base no tipo de pagamento escolhido. Há três classes que implementam a interface IPaymentMethod, 
 representando as formas de pagamento disponíveis: CreditCard, PayPal e Pix. 
 Essas classes contêm a lógica para fazer o pagamento usando cada forma de pagamento especificada. 
 O serviço OrderService utiliza a classe de pagamento correta para fazer o pagamento e cria uma nova ordem de compra, salvando-a no banco de dados. 
 Esse código segue o princípio Open-Closed, permitindo a adição de novas formas de pagamento sem modificar o código existente.

# Parte4Controller
Essa API tem uma regra de negócio para permitir que um cliente possa fazer uma compra, 
sendo que um cliente não registrado não pode fazer compras, um cliente registrado não pode fazer mais de uma 
compra por mês e um cliente que nunca fez compras antes só pode fazer uma primeira compra de até R$ 100,00.

# Testes
Para testar o projeto, foi utilizado o framework de testes Xunit. 
Para criar um projeto de testes, clique com o botão direito do mouse no projeto principal e selecione a 
opção "Adicionar" e depois "Novo Projeto". Na janela que se abre, procure por "xunit" e selecione o 
modelo "Projeto de Teste do xUnit". Após criar o projeto, delete a classe padrão que já vem nele e copie a 
classe "CustomerServiceTests" do projeto principal, que está na pasta "Testes". Esta classe contém uma série de 
testes para a classe "BaseService" metodo "CanPurchase". 
Ao rodar estes testes, é possível verificar se a classe "BaseService" está funcionando corretamente e sem erros."# APIControllers-PaginatedList-OrderPayment-Rules-Tests"  
"# APIControllers-PaginatedList-OrderPayment-Rules-Tests"  
