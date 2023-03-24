namespace BTC_OrderBook.Domain.Exceptions
{
    /// <summary>
    /// BTC_OrderBook.Domain enum bad request exception
    /// </summary>
    public class OrderBookBadRequestException : OrderBookException
    {
        private readonly IList<string> _auxiliaryData;

        /// <summary>
        /// Auxiliary data for format message
        /// </summary>
        public IList<string> AuxiliaryData { get { return _auxiliaryData; } }

        /// <summary>
        /// Constructor exception
        /// </summary>
        ///  <param name="message">Exception message</param>
        public OrderBookBadRequestException(string message) : base(message)
        {
            _auxiliaryData = Array.Empty<string>();
        }

        /// <summary>
        /// Constructor exception
        /// </summary>
        ///  <param name="message">Exception message</param>
        /// <param name="auxiliaryData">Auxiliary data</param>
        public OrderBookBadRequestException(string message, params string[] auxiliaryData) : base(message)
        {
            _auxiliaryData = auxiliaryData.ToList();
        }

        /// <summary>
        /// Constructor exception
        /// </summary>
        ///  <param name="message">Exception message</param>
        /// <param name="auxiliaryData">Auxiliary data</param>
        /// <param name="innerException">Other exception</param>
        public OrderBookBadRequestException(string message, Exception innerException, params string[] auxiliaryData)
            : base(message, innerException)
        {
            _auxiliaryData = auxiliaryData.ToList();
        }

    }
}
