using Bitstamp.Client.Websocket;
using Bitstamp.Client.Websocket.Communicator;
using BTC_OrderBook.Application.Profiles;
using BTC_OrderBook.Infrastructure.Clients;
using BTC_OrderBook.Infrastructure.Providers;
using BTC_OrderBook.Middlewares;
using BTC_OrderBook.Domain.Configs.Bitstamp;
using System.Text.Json;
using System.Text.Json.Serialization;
using BTC_OrderBook.Infrastructure.Clients.OrderBook;
using BTC_OrderBook.Domain.Abstracts.Clients;
using BTC_OrderBook.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using BTC_OrderBook.Domain.Services.Abstract;
using Bitstamp.Client.Websocket.Responses.Books;
using BTC_OrderBook.Application.Services;
using BTC_OrderBook.Domain.Interfaces.Repositories;
using BTC_OrderBook.Infrastructure.Repositories;
using BTC_OrderBook.Extensions;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
     .AddJsonOptions(options =>
     {
         options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
         options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
         options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
     });

builder.Services.AddEndpointsApiExplorer();

builder.AddDb();

builder.Services.Configure<BitstampConfig>(builder.Configuration.GetSection("Bitstamp"));

builder.Services.AddInjections();

builder.Services.AddMapper();
builder.AddHttpContexts();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .WriteTo.Console()
    .Enrich.FromLogContext()
    .Enrich.WithMachineName()
    .CreateLogger();


builder.Services.AddCors();
builder.Services.AddSignalR();

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<ApplicationContext>();
    await context.Database.MigrateAsync();
}

var configuration = app.Services.GetRequiredService<AutoMapper.IConfigurationProvider>();
configuration.AssertConfigurationIsValid();
configuration.CompileMappings();

app.UseDeveloperExceptionPage();
app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseCors(builder => builder
    .SetIsOriginAllowed(_ => true)
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());


app.UseAuthentication();
app.UseRouting();
app.UseAuthorization();

app.MapControllers();


app.Run();