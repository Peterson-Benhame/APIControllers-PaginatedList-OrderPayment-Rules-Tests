using ProvaPub.Interface;
using ProvaPub.PaymentStrategies;

namespace ProvaPub.Services.Payment
{
    public class PaymentFactory : IPaymentFactory
    {
        private readonly IEnumerable<IPaymentMethod> _paymentServices;

        public PaymentFactory(IEnumerable<IPaymentMethod> paymentServices)
        {
            _paymentServices = paymentServices;
        }

        public IPaymentMethod Create(string paymentType)
        {
            // Procura a classe de pagamento correta com base no tipo de pagamento
            var paymentService = _paymentServices.FirstOrDefault(s => s.GetType().Name.ToLower().Equals(paymentType.ToLower(), StringComparison.OrdinalIgnoreCase));

            if (paymentService == null)
            {
                throw new ArgumentException($"Payment type '{paymentType}' not supported.");
            }

            return paymentService;
        }
    }
}
