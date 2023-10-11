using Moralis.Net.Core.Converters;
using Moralis.Net.Core.Models;
using System.Text.Json.Serialization;

namespace Moralis.Net.Models.Web3.EvmChain.NftApi
{
    public class ContractNftModel : MoralisBaseModel, IMoralisModel
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
        public string Cursor { get; set; } = "";

        [JsonPropertyName("result")]
        public List<ContractNftData>? Result { get; set; }
    }

    public partial class ContractNftData
    {
        [JsonPropertyName("token_hash")]
        public string TokenHash { get; set; } = "";

        [JsonPropertyName("token_address")]
        public string TokenAddress { get; set; } = "";

        [JsonPropertyName("token_id")]
        public string TokenId { get; set; } = "";

        [JsonPropertyName("block_number_minted")]
        [JsonConverter(typeof(StringToLongConvertor))]
        public long BlockNumberMinted { get; set; }

        [JsonPropertyName("amount")]
        [JsonConverter(typeof(StringToLongConvertor))]
        public long Amount { get; set; }

        [JsonPropertyName("contract_type")]
        public string ContractType { get; set; } = "";

        [JsonPropertyName("name")]
        public string Name { get; set; } = "";

        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = "";

        [JsonPropertyName("token_uri")]
        public Uri? TokenUri { get; set; }

        [JsonPropertyName("metadata")]
        public string Metadata { get; set; } = "";

        [JsonPropertyName("last_token_uri_sync")]
        public DateTimeOffset? LastTokenUriSync { get; set; }

        [JsonPropertyName("last_metadata_sync")]
        public DateTimeOffset? LastMetadataSync { get; set; }

        [JsonPropertyName("minter_address")]
        public string MinterAddress { get; set; } = "";

        [JsonPropertyName("possible_spam")]
        public bool PossibleSpam { get; set; }

        [JsonPropertyName("verified_collection")]
        public bool VerifiedCollection { get; set; }

        [JsonPropertyName("updated_at")]
        public object? UpdatedAt { get; set; }
    }
}
