using Microsoft.EntityFrameworkCore;
using ProvaPub.Helpers;
using ProvaPub.Models;
using ProvaPub.Repository;
using System.Linq;

namespace ProvaPub.Services
{
    public class BaseService<TModel> where TModel : class
    {
        protected readonly TestDbContext _ctx;

        public BaseService(TestDbContext ctx)
        {
            _ctx = ctx;
        }

        public virtual PaginatedList<TModel> List(int pageNumber, int pageSize)
        {
            int skip = (pageNumber - 1) * pageSize;
            var items = _ctx.Set<TModel>().Skip(skip).Take(pageSize).ToList();
            int totalCount = _ctx.Set<TModel>().Count();
            return new PaginatedList<TModel>(items, totalCount, pageNumber, pageSize);
        }

        public async Task<bool> CanPurchase(int customerId, decimal purchaseValue)
        {

            if (customerId <= 0) throw new ArgumentOutOfRangeException(nameof(customerId));

            if (purchaseValue <= 0) throw new ArgumentOutOfRangeException(nameof(purchaseValue));

            //Business Rule: Non registered Customers cannot purchase
            var customer = await _ctx.Customers.FindAsync(customerId);
            if (customer == null) throw new InvalidOperationException($"Customer Id {customerId} does not exists");

            //Business Rule: A customer can purchase only a single time per month
            var baseDate = DateTime.UtcNow.AddMonths(-1);
            var ordersInThisMonth = await _ctx.Orders.CountAsync(s => s.CustomerId == customerId && s.OrderDate >= baseDate);
            if (ordersInThisMonth > 0)
                return false;

            //Business Rule: A customer that never bought before can make a first purchase of maximum 100,00
            var haveBoughtBefore = await _ctx.Customers.CountAsync(s => s.Id == customerId && s.Orders.Any());
            if (haveBoughtBefore == 0 && purchaseValue > 100)
                return false;

            return true;
        }
    }
}
