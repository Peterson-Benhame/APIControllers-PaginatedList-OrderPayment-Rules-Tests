# PETERSON BENHAME
Hello, how are you?

My name is Peterson Benhame and I am a Full-Stack Developer with extensive experience in various areas of software development, including web, mobile, API and database. I have a vast knowledge of languages and technologies such as C#, ASPNET, ASPNET core, .NET, .NET core, Windows Forms, Entities Framework, Flutter, Dart, React.js, Html, Css, Sass, Javascript(ES6+), Jquery, Typescript, Basic Node.js, Styled Components, Bootstrap, Redux, DDD, MCV, Modules, Database Mysql, SQL, Code Versioning with Git and Github, Agile Scrum and Kanban methodology.

I work with a holistic approach in software development, taking into consideration both the user experience and the functionality of the system. In addition, I have skills in managing and coordinating teams of developers, from conception to project deployment.

# Part1Controller
This code defines a service that returns a random number and a controller that uses this service
to bring this random number when a request is made on the defined route.
The random number is generated from a new unique identifier each time the service is called.

# Part2Controller
This code is about an API that returns information from a list of products and customers.
You can access the product list and the customer list through a GET request, which has as parameters the page number and the page size.

For this, the code contains a model class for customers and another for products.
There is also a generic service class that can be used to fetch paginated lists, where it returns a list of items from the page and the total amount of available items.
In addition, there is a helper class that helps to generate a paginated list.

# Part3Controller
This code has a class called Part3Controller, which is a controller with a method called PlaceOrder.
This method creates a payment for a purchase order with a specific payment method,
like credit card, PayPal or Pix. It receives three parameters: paymentMethod, which is the payment method;
paymentValue, which is the payment value; and customerId, which is the ID of the customer who is paying.
To process the payment, the method calls the OrderService service. This service uses the Factory Method pattern
to get the correct payment class based on the chosen payment type. There are three classes that implement the IPaymentMethod interface,
representing the available payment methods: CreditCard, PayPal, and Pix.
These classes contain the logic to make the payment using each specified payment form.
The OrderService service uses the correct payment class to make the payment and creates a new purchase order, saving it in the database.
This code follows the Open-Closed principle, allowing the addition of new payment forms without modifying the existing code.

# Part4Controller
This API has a business rule to allow a customer to make a purchase,
where an unregistered customer cannot make purchases, a registered customer cannot make more than one
purchase per month and a customer who has never made purchases before can only make a first purchase of up to R$ 100.00.

# Tests
To test the project, the Xunit test framework was used.
To create a test project, right-click on the main project and select the
option "Add" and then "New Project". In the window that opens, search for "xunit" and select the
"Xunit Test Project" model. After creating the project, delete the standard class that already comes with it and copy the
"CustomerServiceTests" class from the main project, which is in the "Tests" folder. This class contains a series of
tests for the "
