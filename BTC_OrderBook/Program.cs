using BTC_OrderBook.Middlewares;
using BTC_OrderBook.Domain.Configs.Bitstamp;
using System.Text.Json;
using System.Text.Json.Serialization;
using BTC_OrderBook.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using BTC_OrderBook.Extensions;
using BTC_OrderBook.Domain.Configs.Bitstamp.OrderBook.AdditionalInfo;

var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureLogging(opt =>
{
    opt.AddConsole();
});

builder.Services.AddControllers()
     .AddJsonOptions(options =>
     {
         options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter(JsonNamingPolicy.CamelCase));
         options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
         options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
     });

builder.AddDb();

builder.Services.Configure<BitstampConfig>(builder.Configuration.GetSection("Bitstamp"));
builder.Services.Configure<BitstampOrderBookAdditionalInfoConfig>(builder.Configuration.GetSection("Bitstamp:OrderBook:AdditionalInfo"));

builder.Services.AddInjections();

builder.Services.AddMapper();
builder.AddHttpContexts();

builder.Services.AddCors();

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

app.UseRouting();

app.MapControllers();

app.Run();