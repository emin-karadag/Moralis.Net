using Moralis.Net.Core.Converters;
using Moralis.Net.Core.Models;
using System.Text.Json.Serialization;

namespace Moralis.Net.Models.Web3.EvmChain.WalletApi
{
    public class ChainActivityModel : MoralisBaseModel, IMoralisModel
    {
        [JsonPropertyName("address")]
        public string Address { get; set; } = "";

        [JsonPropertyName("active_chains")]
        public List<ActiveChain>? ActiveChains { get; set; }
    }

    public partial class ActiveChain
    {
        [JsonPropertyName("chain")]
        public string Chain { get; set; } = "";

        [JsonPropertyName("chain_id")]
        public string ChainId { get; set; } = "";

        [JsonPropertyName("first_transaction")]
        public StTransaction? FirstTransaction { get; set; }

        [JsonPropertyName("last_transaction")]
        public StTransaction? LastTransaction { get; set; }
    }

    public partial class StTransaction
    {
        [JsonPropertyName("block_timestamp")]
        public DateTimeOffset BlockTimestamp { get; set; }

        [JsonPropertyName("block_number")]
        [JsonConverter(typeof(StringToLongConvertor))]
        public long BlockNumber { get; set; }

        [JsonPropertyName("transaction_hash")]
        public string TransactionHash { get; set; } = "";
    }
}
