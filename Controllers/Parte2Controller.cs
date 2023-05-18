using Microsoft.AspNetCore.Mvc;
using ProvaPub.Helpers;
using ProvaPub.Models;
using ProvaPub.Services;

namespace ProvaPub.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class Parte2Controller : ControllerBase
    {
        private readonly BaseService<Customer> _customerService;
        private readonly BaseService<Product> _productService;


        public Parte2Controller(BaseService<Customer> customerService, BaseService<Product> productService)
        {
            _productService = productService;
            _customerService = customerService;
        }
        /// <summary>
        /// Busca a lista de produtos
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("products")]
        public PaginatedList<Product> ListProducts(int page, int pageSize)
        {
            return _productService.List(page, pageSize);
        }

        /// <summary>
        /// Busca a lista de clientes
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("customers")]
        public PaginatedList<Customer> ListCustomers(int page, int pageSize)
        {
            return _customerService.List(page, pageSize);
        }
    }
}
