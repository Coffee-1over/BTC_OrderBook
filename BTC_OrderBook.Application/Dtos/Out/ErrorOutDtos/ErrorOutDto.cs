using BTC_OrderBook.Domain.Constants;

namespace BTC_OrderBook.Application.Dto.Out.ErrorOutDtos;

/// <summary>
/// Error out dto
/// </summary>
public class ErrorOutDto
{
    /// <summary>
    /// Error message
    /// </summary>
    public string Message { get; set; } = null!;

    /// <summary>
    /// Techincal error
    /// </summary>
    public TechincalErrorOutDto? TechincalError { get; set; }

    /// <summary>
    /// Static basic error ot dto object
    /// </summary>
    public static ErrorOutDto ERROR_OUT_DTO = new ErrorOutDto { Message = ErrorConstants.MESSAGE };
}
