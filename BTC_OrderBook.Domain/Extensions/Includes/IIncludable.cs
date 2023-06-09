namespace BTC_OrderBook.Domain.Extensions.Includes
{
    /// <summary>
    /// Table interface to be included
    /// </summary>
    public interface IIncludable
    {
    }

    public interface IIncludable<out TEntity> : IIncludable
    {
    }

    public interface IIncludable<out TEntity, out TProperty> : IIncludable<TEntity>
    {
    }
}