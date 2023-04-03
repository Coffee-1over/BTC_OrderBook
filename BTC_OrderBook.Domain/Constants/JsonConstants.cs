using System.Text.Json.Serialization;
using System.Text.Json;

namespace BTC_OrderBook.Domain.Constants
{
    /// <summary>
    /// Json Serializer constnts
    /// </summary>
    public static class JsonConstants
    {
        /// <summary>
        /// Custom Json serializer options
        /// </summary>
        public static JsonSerializerOptions JsonSerializerOptions =>
            new JsonSerializerOptions
            {
                IgnoreReadOnlyProperties = true,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                NumberHandling =
                    JsonNumberHandling.AllowReadingFromString |
                    JsonNumberHandling.WriteAsString,

                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true,
                Converters =
                {
                    new JsonStringEnumConverter(JsonNamingPolicy.CamelCase),
                },
            };
    }
}
