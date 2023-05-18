using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using ProvaPub.Repository;
using ProvaPub.Services;
using ProvaPub.Models;
using ProvaPub.PaymentStrategies;
using ProvaPub.Services.Payment;
using ProvaPub.Interface;

namespace ProvaPub
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            // EnableRetryOnFailure foi adicionado com um
            // limite máximo de 10 tentativas de reconexão
            // e um atraso máximo de 30 segundos entre as tentativas
            services.AddDbContext<TestDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("ctx"),
                sqlServerOptionsAction: sqlOptions =>
                {
                    sqlOptions.EnableRetryOnFailure(
                        maxRetryCount: 10,
                        maxRetryDelay: TimeSpan.FromSeconds(30),
                        errorNumbersToAdd: null);
                }));

            services.AddSingleton<RandomService>();

            services.AddScoped<BaseService<Customer>>();
            services.AddScoped<BaseService<Product>>();

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IPaymentFactory, PaymentFactory>();

            services.AddScoped<IPaymentMethod, Pix>();
            services.AddScoped<IPaymentMethod, CreditCard>();
            services.AddScoped<IPaymentMethod, PayPal>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();


            app.UseRouting();
            app.UseDeveloperExceptionPage();

            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
