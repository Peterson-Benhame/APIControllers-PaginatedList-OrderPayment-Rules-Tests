using ProvaPub.PaymentStrategies;
using ProvaPub.Repository;

namespace ProvaPub.Services.Payment
{
    public class CreditCard : IPaymentMethod
    {
        /// <summary>
        /// Classe que implementa a estratégia de pagamento via cartão de crédito.
        /// </summary>

        public async Task Pay(decimal paymentValue, int customerId)
        {
            //Faz pagamento...
            await Task.CompletedTask;
        }
    }
}
