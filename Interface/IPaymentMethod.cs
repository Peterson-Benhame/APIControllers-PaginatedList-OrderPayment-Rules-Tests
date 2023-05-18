namespace ProvaPub.PaymentStrategies
{
    /// <summary>
    /// Interface que define um método comum para todos os métodos de pagamento.
    /// </summary>
    public interface IPaymentMethod
    {
        Task Pay(decimal paymentValue, int customerId);
    }
}
