using BTC_OrderBook.Application.Profiles;
using BTC_OrderBook.Application.Services;
using BTC_OrderBook.Domain.Abstracts.Clients;
using BTC_OrderBook.Domain.Interfaces.Repositories;
using BTC_OrderBook.Domain.Services.Abstract;
using BTC_OrderBook.Infrastructure.Clients.OrderBook;
using BTC_OrderBook.Infrastructure.Contexts;
using BTC_OrderBook.Infrastructure.Providers;
using BTC_OrderBook.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BTC_OrderBook.Extensions
{
    /// <summary>
    /// Dependency container of extensions methods
    /// </summary>
    public static class DependencyContainer
    {
        /// <summary>
        /// Add services in service collection
        /// </summary>
        /// <param name="services"></param>
        public static void AddInjections(this IServiceCollection services)
        {

            services.AddScoped<ExceptionProvider>();

            services.AddScoped<IOrderBookClient, OrderBookClient>();

            services.AddScoped<IOrderBookRepository, OrderBookRepository>();
            services.AddScoped<IOrderBookService, OrderBookService>();
            
        }

        /// <summary>
        /// Add http context
        /// </summary>
        /// <param name="builder">Web application builder</param>
        public static void AddHttpContexts(this WebApplicationBuilder builder)
        {
            builder.Services.AddHttpClient<IOrderBookClient, OrderBookClient>(client =>
            {
                client.BaseAddress = new Uri(builder.Configuration["Bitstamp:ApiUrl"]);
            });
        }

        /// <summary>
        /// Add db context to app
        /// </summary>
        /// <param name="builder">Web application builder</param>
        public static void AddDb(this WebApplicationBuilder builder)
        {

            builder.Services.AddDbContext<ApplicationContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

        }

        /// <summary>
        /// Add automapper to app
        /// </summary>
        /// <param name="services">App service collection</param>
        public static void AddMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<OrderBookProfile>();
                cfg.AllowNullCollections = true;
                cfg.ShouldUseConstructor = ci => !ci.IsPrivate;
            });
        }
    }
}
