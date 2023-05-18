using Microsoft.EntityFrameworkCore;
using ProvaPub.Models;
using ProvaPub.Repository;
using ProvaPub.Services;
using Xunit;

namespace ProvaPubTest
{
    // Classe de testes para o serviço CustomerService
    public class CustomerServiceTests
    {
        // Método para criar um contexto de banco de dados em memória para testes
        private static TestDbContext CreateTestDbContext()
        {
            var options = new DbContextOptionsBuilder<TestDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;
            return new TestDbContext(options);
        }

        // Testa se uma exceção ArgumentOutOfRangeException é lançada ao fornecer um customerId inválido
        [Fact]
        public async Task CanPurchase_InvalidCustomerId_ThrowsArgumentOutOfRangeException()
        {
            // Arrange (Preparação)
            int invalidCustomerId = -1;
            decimal purchaseValue = 50m;
            var ctx = CreateTestDbContext();
            var service = new BaseService<Customer>(ctx);

            // Act & Assert (Ação e Validação)
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => service.CanPurchase(invalidCustomerId, purchaseValue));
        }

        // Testa se uma exceção ArgumentOutOfRangeException é lançada ao fornecer um purchaseValue inválido
        [Fact]
        public async Task CanPurchase_InvalidPurchaseValue_ThrowsArgumentOutOfRangeException()
        {
            // Arrange (Preparação)
            int customerId = 1;
            decimal invalidPurchaseValue = -50m;
            var ctx = CreateTestDbContext();
            var service = new BaseService<Customer>(ctx);

            // Act & Assert (Ação e Validação)
            await Assert.ThrowsAsync<ArgumentOutOfRangeException>(() => service.CanPurchase(customerId, invalidPurchaseValue));
        }

        // Testa se uma exceção InvalidOperationException é lançada ao fornecer um customerId não registrado
        [Fact]
        public async Task CanPurchase_CustomerNotRegistered_ThrowsInvalidOperationException()
        {
            // Arrange (Preparação)
            int nonRegisteredCustomerId = 1;
            decimal purchaseValue = 50m;
            var ctx = CreateTestDbContext();
            var service = new BaseService<Customer>(ctx);

            // Act & Assert (Ação e Validação)
            await Assert.ThrowsAsync<InvalidOperationException>(() => service.CanPurchase(nonRegisteredCustomerId, purchaseValue));
        }

        // Testa se o método CanPurchase retorna falso ao tentar fazer múltiplas compras no mesmo mês
        [Fact]
        public async Task CanPurchase_CustomerTriesMultiplePurchasesInSameMonth_ReturnsFalse()
        {
            // Arrange
            int customerId = 1;
            decimal purchaseValue = 50m;

            var ctx = CreateTestDbContext();

            // Add a customer
            var customer = new Customer { Id = customerId, Name = "Test Customer" };
            ctx.Customers.Add(customer);

            // Add an order for the same customer within the past month
            ctx.Orders.Add(new Order { CustomerId = customerId, OrderDate = DateTime.UtcNow.AddDays(-15) });

            await ctx.SaveChangesAsync();

            var service = new BaseService<Customer>(ctx);

            // Act
            bool canPurchase = await service.CanPurchase(customerId, purchaseValue);

            // Assert
            Assert.False(canPurchase);
        }
        // Testa se o método CanPurchase retorna falso quando um novo cliente tenta fazer uma compra acima do valor máximo permitido
        [Fact]
        public async Task CanPurchase_NewCustomerTriesPurchaseAboveMaxAllowed_ReturnsFalse()
        {
            // Arrange
            int newCustomerId = 1;
            decimal purchaseValueAboveMaxAllowed = 150m;

            var ctx = CreateTestDbContext();

            // Add a new customer
            var newCustomer = new Customer { Id = newCustomerId, Name = "New Test Customer" };
            ctx.Customers.Add(newCustomer);

            await ctx.SaveChangesAsync();

            var service = new BaseService<Customer>(ctx);

            // Act
            bool canPurchase = await service.CanPurchase(newCustomerId, purchaseValueAboveMaxAllowed);

            // Assert
            Assert.False(canPurchase);
        }
        // Testa se o método CanPurchase retorna verdadeiro quando um cliente existente faz uma compra válida
        [Fact]
        public async Task CanPurchase_ExistingCustomerValidPurchase_ReturnsTrue()
        {
            // Arrange
            int existingCustomerId = 1;
            decimal validPurchaseValue = 50m;

            var ctx = CreateTestDbContext();

            // Add an existing customer
            var existingCustomer = new Customer { Id = existingCustomerId, Name = "Existing Test Customer" };
            ctx.Customers.Add(existingCustomer);

            // Add an order for the same customer more than one month ago
            ctx.Orders.Add(new Order { CustomerId = existingCustomerId, OrderDate = DateTime.UtcNow.AddMonths(-2) });

            await ctx.SaveChangesAsync();

            var service = new BaseService<Customer>(ctx);

            // Act
            bool canPurchase = await service.CanPurchase(existingCustomerId, validPurchaseValue);

            // Assert
            Assert.True(canPurchase);
        }
    }
}
