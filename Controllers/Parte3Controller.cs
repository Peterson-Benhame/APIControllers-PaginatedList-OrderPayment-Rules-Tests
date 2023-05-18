using Microsoft.AspNetCore.Mvc;
using ProvaPub.Interface;
using ProvaPub.Models;

namespace ProvaPub.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Parte3Controller : ControllerBase
    {
        private readonly IOrderService _orderService;

        public Parte3Controller(IOrderService orderService)
        {
            _orderService = orderService;
        }

        /// <summary>
        /// Cria um pagamento para uma ordem de compra utilizando a forma de pagamento especificada.
        /// </summary>
        /// <param name="paymentMethod">Forma de pagamento (pix, creditcard ou paypal).</param>
        /// <param name="paymentValue">Valor do pagamento.</param>
        /// <param name="customerId">ID do cliente que está realizando o pagamento.</param>
        /// <returns>Objeto Order que representa a ordem de compra.</returns>
        [HttpGet("orders")]
        public async Task<Order> PlaceOrder(string paymentMethod, decimal paymentValue, int customerId)
        {
            return await _orderService.PayOrder(paymentMethod, paymentValue, customerId);
        }
    }
}
