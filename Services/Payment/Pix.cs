using ProvaPub.PaymentStrategies;

namespace ProvaPub.Services.Payment
{
    public class Pix : IPaymentMethod
    {
        /// <summary>
        /// Classe que implementa a estratégia de pagamento via Pix.
        /// </summary>
        public async Task Pay(decimal paymentValue, int customerId)
        {
            //Faz pagamento...
            await Task.CompletedTask;
        }
    }
}
