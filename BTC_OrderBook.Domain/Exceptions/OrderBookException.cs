namespace BTC_OrderBook.Domain.Exceptions
{
    /// <summary>
    /// Exception handled on the "Wanda" project
    /// </summary>
    public class OrderBookException : ApplicationException
    {
        /// <summary>
        /// Constructor exception
        /// </summary>
        /// <param name="message">Exception message</param>
        public OrderBookException(string message) : base(message)
        { }

        /// <summary>
        /// Constructor exception
        /// </summary>
        /// <param name="message">Exception message</param>
        /// <param name="innerException">Other exception</param>
        public OrderBookException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}