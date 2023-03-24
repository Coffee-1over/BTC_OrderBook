namespace BTC_OrderBook.Domain.Exceptions
{
    /// <summary>
    /// Traceable exception to return not found http status code
    /// </summary>
    public class OrderBookNotFoundException : OrderBookBadRequestException
    {
        /// <summary>
        /// Constructor
        /// </summary>
        ///  <param name="message">Exception message</param>
        public OrderBookNotFoundException(string message) : base(message)
        {
        }
        /// <summary>
        /// Constructor
        /// </summary>
        ///  <param name="message">Exception message</param>
        /// <param name="auxiliaryData">Auxiliary data</param>
        public OrderBookNotFoundException(string message, params string[] auxiliaryData) : base(message, auxiliaryData)
        {
        }

        /// <summary>
        /// Constructor exception
        /// </summary>
        ///  <param name="message">Exception message</param>
        /// <param name="auxiliaryData">Auxiliary data</param>
        /// <param name="innerException">Other exception</param>
        public OrderBookNotFoundException(string message, Exception innerException, params string[] auxiliaryData)
            : base(message, innerException, auxiliaryData)
        { }
    }
}
