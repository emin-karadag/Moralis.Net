using Moralis.Net.Core.Converters;
using Moralis.Net.Core.Models;
using System.Text.Json.Serialization;

namespace Moralis.Net.Models.Web3.EvmChain.NftApi
{
    public class WalletNftCollectionsModel : MoralisBaseModel, IMoralisModel
    {
        [JsonPropertyName("total")]
        public object? Total { get; set; }

        [JsonPropertyName("page")]
        [JsonConverter(typeof(StringToIntConvertor))]
        public int Page { get; set; }

        [JsonPropertyName("page_size")]
        [JsonConverter(typeof(StringToIntConvertor))]
        public int PageSize { get; set; }

        [JsonPropertyName("cursor")]
        public object? Cursor { get; set; }

        [JsonPropertyName("result")]
        public List<WalletNftCollectionResult>? Result { get; set; }

        [JsonPropertyName("status")]
        public string Status { get; set; } = "";
    }

    public partial class WalletNftCollectionResult
    {
        [JsonPropertyName("token_address")]
        public string TokenAddress { get; set; } = "";

        [JsonPropertyName("contract_type")]
        public string ContractType { get; set; } = "";

        [JsonPropertyName("name")]
        public string Name { get; set; } = "";

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = "";

        [JsonPropertyName("possible_spam")]
        public bool PossibleSpam { get; set; }

        [JsonPropertyName("verified_collection")]
        public bool? VerifiedCollection { get; set; }
    }
}
