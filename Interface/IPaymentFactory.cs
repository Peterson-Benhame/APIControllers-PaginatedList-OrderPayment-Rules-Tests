using ProvaPub.PaymentStrategies;

namespace ProvaPub.Interface
{
    public interface IPaymentFactory
    {
        IPaymentMethod Create(string paymentType);
    }
}
