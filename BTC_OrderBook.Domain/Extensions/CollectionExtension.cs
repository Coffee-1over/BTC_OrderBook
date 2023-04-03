namespace BTC_OrderBook.Domain.Extensions
{
    /// <summary>
    /// Extensions collection class
    /// </summary>
    public static class CollectionExtension
    {
        /// <summary>
        /// Do action with each piece of collection 
        /// </summary>
        public static void ForEach<T>(this IEnumerable<T> source, Action<T> action)
        {
            if (action == null)
                return;

            foreach (var i in source)
                action(i);
        }

        /// <summary>
        /// Возвращает <see cref="bool"/> если колекция пустая , либо <see cref="null"/>.
        /// </summary>
        /// <typeparam name="T">Тип элементов в коллекции.</typeparam>
        /// <param name="source">Коллекция.</param>
        /// <returns></returns>
        public static bool IsNullOrEmpty<T>(this ICollection<T>? source)
        {
            return source == null || !source.Any();
        }

        /// <summary>
        /// Возвращает <see cref="true"/> если значение находится в коллекции.
        /// </summary>
        /// <typeparam name="T">Тип значения.</typeparam>
        /// <param name="value">Значение.</param>
        /// <param name="source">Коллекция.</param>
        /// <returns></returns>
        public static bool IsIn<T>(this T? value, params T[]? source)
        {
            return !source.IsNullOrEmpty() && source!.Contains(value);
        } 
    }
}