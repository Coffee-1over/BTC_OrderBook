
using BTC_OrderBook.Application.Dto.Out.Abstract;
using BTC_OrderBook.Domain.Exceptions;
using BTC_OrderBook.Infrastructure.Providers;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BTC_OrderBook.Middlewares
{
    /// <summary>
    /// Request error handler
    /// </summary>
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        /// <summary>
        /// Request error handler constructor
        /// </summary>
        /// <param name="logger">Logger</param>
        /// <param name="next">Next handler</param>
        public ExceptionMiddleware(
            ILogger<ExceptionMiddleware> logger,
            RequestDelegate next)
        {
            _logger = logger;
            _next = next;
        }

        /// <summary>
        /// Request handler
        /// </summary>
        /// <param name="httpContext">HttpContext</param>
        /// <param name="exceptionProvider">Exception provider</param>
        public async Task InvokeAsync(HttpContext httpContext, ExceptionProvider exceptionProvider)
        {
            try
            {
                await _next(httpContext);
            }
            catch (OrderBookNotFoundException ex)
            {
                var errorResponse = exceptionProvider.GenerateBaseOutDtoWithError(ex);

                await HandleExceptionAsync(httpContext, HttpStatusCode.NotFound, errorResponse);
            }
            catch (OrderBookBadRequestException ex)
            {
                var errorResponse = exceptionProvider.GenerateBaseOutDtoWithError(ex);

                await HandleExceptionAsync(httpContext, HttpStatusCode.BadRequest, errorResponse);
            }
            catch (OrderBookException ex)
            {
                var errorResponse = exceptionProvider.GenerateBaseOutDtoWithError(ex);

                await HandleExceptionAsync(httpContext, HttpStatusCode.InternalServerError, errorResponse);
            }
            catch (Exception ex)
            {
                var errorResponse = exceptionProvider.GenerateBaseOutDtoWithError(ex);

                await HandleExceptionAsync(httpContext, HttpStatusCode.InternalServerError, errorResponse);
            }
        }



        /// <summary>
        /// Setting values in the request error handler
        /// </summary>
        /// <param name="context">HttpContext</param>
        /// <param name="statusCode">Satatus code</param>
        /// <param name="errorResponse">Error response</param>
        /// <returns><see cref="HttpContext.Response"/></returns>
        private Task HandleExceptionAsync(
                    HttpContext context,
                    HttpStatusCode statusCode,
                    BaseOut<bool?> errorResponse)
        {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var jsonOptions = new JsonSerializerOptions(JsonSerializerDefaults.Web) { DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull, };

            return context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse, jsonOptions));
        }
    }
}
