using Moralis.Net.Core.Converters;
using Moralis.Net.Core.Models;
using System.Text.Json.Serialization;

namespace Moralis.Net.Models.Web3.EvmChain.BalanceApi
{
    public class NativeBalanceMultiWalletModel : MoralisBaseModel, IMoralisModel
    {
        [JsonPropertyName("chain")]
        public string Chain { get; set; } = "";

        [JsonPropertyName("chain_id")]
        public string ChainId { get; set; } = "";

        [JsonPropertyName("block_number")]
        [JsonConverter(typeof(StringToLongConvertor))]
        public long BlockNumber { get; set; }

        [JsonPropertyName("block_timestamp")]
        [JsonConverter(typeof(StringToLongConvertor))]
        public long BlockTimestamp { get; set; }

        [JsonPropertyName("total_balance")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal TotalBalance { get; set; }

        [JsonPropertyName("total_balance_formatted")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal TotalBalanceFormatted { get; set; }

        [JsonPropertyName("wallet_balances")]
        public List<WalletBalance>? WalletBalances { get; set; }
    }

    public partial class WalletBalance
    {
        [JsonPropertyName("address")]
        public string Address { get; set; } = "";

        [JsonPropertyName("balance")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal Balance { get; set; }

        [JsonPropertyName("balance_formatted")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal BalanceFormatted { get; set; }
    }
}
