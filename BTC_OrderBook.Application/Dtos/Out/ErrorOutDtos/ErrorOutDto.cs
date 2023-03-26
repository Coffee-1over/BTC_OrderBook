using BTC_OrderBook.Domain.Constants;

namespace BTC_OrderBook.Application.Dto.Out.ErrorOutDtos;

public class ErrorOutDto
{
    public string Message { get; set; }
    public TechincalErrorOutDto? TechincalError { get; set; }
    public IList<ValidationErrorOutDto>? Validation { get; set; }
    public static ErrorOutDto ERROR_OUT_DTO = new ErrorOutDto { Message = ErrorConstants.MESSAGE };
}
