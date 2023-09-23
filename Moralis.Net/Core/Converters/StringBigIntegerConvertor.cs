using System.Numerics;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Moralis.Net.Core.Converters
{
    public class StringBigIntegerConvertor : JsonConverter<BigInteger>
    {
        public override BigInteger Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            if (reader.TokenType == JsonTokenType.String)
            {
                _ = BigInteger.TryParse(reader.GetString(), out BigInteger result);
                return result;
            }
            else if (reader.TokenType == JsonTokenType.Number)
            {
                return reader.GetInt64();
            }
            throw new JsonException();
        }

        public override void Write(Utf8JsonWriter writer, BigInteger value, JsonSerializerOptions options)
        {
            throw new InvalidOperationException($"Unable to parse {value} to BigInteger");
        }
    }
}
