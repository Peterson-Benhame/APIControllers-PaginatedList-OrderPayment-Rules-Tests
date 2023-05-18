using Microsoft.AspNetCore.Mvc;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services;

namespace ProvaPub.Controllers
{
    [ApiController]
	[Route("[controller]")]
	public class Parte4Controller :  ControllerBase
	{
        private readonly BaseService<Customer> _customerService;
        public Parte4Controller(BaseService<Customer> customerService)
        {
            _customerService = customerService;
        }

        /// <summary>
        /// Verifica se um cliente pode fazer uma compra
        /// </summary>
        /// <param name="customerId"></param>
        /// <param name="purchaseValue"></param>
        /// <returns></returns>
        [HttpGet("CanPurchase")]
		public async Task<bool> CanPurchase(int customerId, decimal purchaseValue)
		{
			return await _customerService.CanPurchase(customerId, purchaseValue);
		}
	}
}
