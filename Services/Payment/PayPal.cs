using ProvaPub.PaymentStrategies;

namespace ProvaPub.Services.Payment
{
    public class PayPal : IPaymentMethod
    {
        /// <summary>
        /// Classe que implementa a estratégia de pagamento via PayPal.
        /// </summary>
        public async Task Pay(decimal paymentValue, int customerId)
        {
            //Faz pagamento...
            await Task.CompletedTask;
        }
    }

}
