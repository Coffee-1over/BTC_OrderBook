namespace BTC_OrderBook.Domain.DB.Entities.Abstract
{
    public interface IArchivable
    {
        bool IsActive { get; set; }
    }
}