using System.Text.Json.Serialization;
using System.Text.Json;

namespace BTC_OrderBook.Domain.Constants
{
    public static class JsonConstants
    {
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
