using Moralis.Net.Core.Converters;
using Moralis.Net.Core.Models;
using System.Text.Json.Serialization;

namespace Moralis.Net.Models.Web3.EvmChain.TokenApi
{
    public class TokenBalanceByWalletModel : MoralisBaseModel, IMoralisModel
    {
        [JsonPropertyName("token_address")]
        public string TokenAddress { get; set; } = "";

        [JsonPropertyName("name")]
        public string Name { get; set; } = "";

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = "";

        [JsonPropertyName("logo")]
        public Uri? Logo { get; set; }

        [JsonPropertyName("thumbnail")]
        public Uri? Thumbnail { get; set; }

        [JsonPropertyName("decimals")]
        [JsonConverter(typeof(StringToIntConvertor))]
        public int Decimals { get; set; }

        [JsonPropertyName("balance")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal Balance { get; set; }

        [JsonPropertyName("possible_spam")]
        public bool PossibleSpam { get; set; }
    }
}
