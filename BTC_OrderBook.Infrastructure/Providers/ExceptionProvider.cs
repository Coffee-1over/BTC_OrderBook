
using BTC_OrderBook.Application.Dto.Out.Abstract;
using BTC_OrderBook.Application.Dto.Out.ErrorOutDtos;
using BTC_OrderBook.Domain.Constants;
using BTC_OrderBook.Domain.Exceptions;
using Microsoft.Extensions.Logging;

namespace BTC_OrderBook.Infrastructure.Providers
{
    public class ExceptionProvider
    {
        private readonly ILogger<ExceptionProvider> _logger;
        public ExceptionProvider(ILogger<ExceptionProvider> logger)
        {
            _logger = logger;
        }

        public BaseOut<bool?> GenerateBaseOutDtoWithError(Exception ex)
        {
            var errorOutDto = GenerateErrorOutDto(ex);
            return new BaseOut<bool?>(errorOutDto);
        }

        public BaseOut<bool?> GenerateBaseOutDtoWithError(OrderBookBadRequestException ex)
        {
            var errorOutDto = GenerateErrorOutDto(ex, ex.AuxiliaryData);
            return new BaseOut<bool?>(errorOutDto);
        }

        public ErrorOutDto GenerateErrorOutDto(Exception ex, IList<string>? auxiliaryData = null)
        {
            var exceptionType = ex.GetType();
            var providerName = nameof(ExceptionProvider);

            _logger.LogError("{ProviderName} {ExceptionType}: {Message}", providerName, exceptionType, ex.Message);

            string? message = null;


            if (!string.IsNullOrEmpty(message) && auxiliaryData != null && auxiliaryData.Count != 0)
                message = string.Format(message, auxiliaryData.ToArray());

            return new ErrorOutDto
            {
                Message = message ?? ErrorConstants.MESSAGE,
                TechincalError = GenerateTechincalErrorOutDto(ex),
            };
        }

        public TechincalErrorOutDto? GenerateTechincalErrorOutDto(Exception ex)
        {
            var innerException = ex;

            if (innerException == null)
                return null;

            var innerExceptions = new List<string>();
            var stackTraces = new List<string?> { ex.StackTrace };

            for (int i = 0; i < ErrorConstants.COUNT_INNER_EXCEPTION && innerException != null; i++)
            {
                innerExceptions.Add(innerException.Message);
                stackTraces.Add(innerException.StackTrace);
                innerException = ex.InnerException;
            }


            return new TechincalErrorOutDto
            {
                StackTraces = stackTraces,
                ExceptionMessage = ex.Message,
                ExceptionType = ex.GetType().Name,
                InnerExceptions = innerExceptions,
            };
        }
    }
}
