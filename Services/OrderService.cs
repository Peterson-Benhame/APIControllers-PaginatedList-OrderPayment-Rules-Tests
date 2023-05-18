using ProvaPub.Interface;
using ProvaPub.Models;
using ProvaPub.PaymentStrategies;
using ProvaPub.Repository;

namespace ProvaPub.Services
{
    /// <summary>
    /// Classe responsável por processar o pagamento de uma ordem de compra.
    /// </summary>
    public class OrderService : IOrderService
    {
        private readonly IPaymentFactory _paymentFactory;
        protected readonly TestDbContext _ctx;

        public OrderService(IPaymentFactory paymentFactory, TestDbContext ctx)
        {
            _paymentFactory = paymentFactory;
            _ctx = ctx;
        }

        /// <summary>
        /// Faz o pagamento de uma ordem de compra utilizando a estratégia de pagamento definida.
        /// </summary>
        /// <param name="paymentMethod">Forma de pagamento (pix, creditcard ou paypal)</param>
        /// <param name="paymentValue">Valor do pagamento.</param>
        /// <param name="customerId">ID do cliente que está realizando o pagamento.</param>
        /// <returns>Objeto Order que representa a ordem de compra.</returns>
        public async Task<Order> PayOrder(string paymentMethod, decimal paymentValue, int customerId)
        {
            // Obtenha a instância correta da classe de pagamento com base no tipo de pagamento
            var paymentService = _paymentFactory.Create(paymentMethod);

            // Execute o pagamento
            await paymentService.Pay(paymentValue, customerId);

            // Crie uma nova ordem
            var order = await Task.FromResult(new Order()
            {
                Value = paymentValue,
                CustomerId = customerId,
                MetodyPayment = paymentMethod,
                OrderDate = DateTime.Now
            });

            // Salve a ordem no banco de dados
            await _ctx.Orders.AddAsync(order);
            await _ctx.SaveChangesAsync();

            return order;
        }
    }
}
