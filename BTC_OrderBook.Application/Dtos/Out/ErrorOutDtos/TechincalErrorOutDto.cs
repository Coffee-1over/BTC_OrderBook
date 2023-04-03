namespace BTC_OrderBook.Application.Dto.Out.ErrorOutDtos
{

    /// <summary>
    /// Techincal error out dto
    /// </summary>
    public class TechincalErrorOutDto
    {
        /// <summary>
        /// Exception type
        /// </summary>
        public string ExceptionType { get; set; } = null!;

        /// <summary>
        /// Exception message
        /// </summary>
        public string ExceptionMessage { get; set; } = null!;

        /// <summary>
        /// Stack traces
        /// </summary>
        public IList<string?> StackTraces { get; set; } = Array.Empty<string>();

        /// <summary>
        /// Inner exceptions
        /// </summary>
        public IList<string> InnerExceptions { get; set; } = Array.Empty<string>();
    }
}
