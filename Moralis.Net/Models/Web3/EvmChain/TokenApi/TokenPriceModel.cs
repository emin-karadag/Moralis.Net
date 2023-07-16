using Moralis.Net.Core.Converters;
using Moralis.Net.Core.Models;
using System.Text.Json.Serialization;

namespace Moralis.Net.Models.Web3.EvmChain.TokenApi
{
    public class TokenPriceModel : MoralisBaseModel, IMoralisModel
    {
        [JsonPropertyName("tokenName")]
        public string TokenName { get; set; } = "";

        [JsonPropertyName("tokenSymbol")]
        public string TokenSymbol { get; set; } = "";

        [JsonPropertyName("tokenLogo")]
        public Uri? TokenLogo { get; set; }

        [JsonPropertyName("tokenDecimals")]
        [JsonConverter(typeof(StringToIntConvertor))]
        public int TokenDecimals { get; set; }

        [JsonPropertyName("nativePrice")]
        public NativePrice? NativePrice { get; set; }

        [JsonPropertyName("usdPrice")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal UsdPrice { get; set; }

        [JsonPropertyName("usdPriceFormatted")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal UsdPriceFormatted { get; set; }

        [JsonPropertyName("24hrPercentChange")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal The24HrPercentChange { get; set; }

        [JsonPropertyName("exchangeAddress")]
        public string ExchangeAddress { get; set; } = "";

        [JsonPropertyName("exchangeName")]
        public string ExchangeName { get; set; } = "";

        [JsonPropertyName("tokenAddress")]
        public string TokenAddress { get; set; } = "";
    }

    public partial class NativePrice
    {
        [JsonPropertyName("value")]
        [JsonConverter(typeof(StringToLongConvertor))]
        public long Value { get; set; }

        [JsonPropertyName("decimals")]
        [JsonConverter(typeof(StringToLongConvertor))]
        public long Decimals { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; } = "";

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = "";

        [JsonPropertyName("address")]
        public string Address { get; set; } = "";
    }
}
