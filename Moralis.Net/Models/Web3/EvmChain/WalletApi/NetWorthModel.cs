using Moralis.Net.Core.Models;
using System.Text.Json.Serialization;

namespace Moralis.Net.Models.Web3.EvmChain.WalletApi
{
    public class NetWorthModel : MoralisBaseModel, IMoralisModel
    {
        [JsonPropertyName("total_networth_usd")]
        public string TotalNetworthUsd { get; set; } = "";

        [JsonPropertyName("chains")]
        public List<ChainNetWorth> Chains { get; set; } = new List<ChainNetWorth>();

        [JsonPropertyName("unsupported_chain_ids")]
        public List<string>? UnsupportedChainIds { get; set; }

        [JsonPropertyName("unavailable_chains")]
        public List<UnavailableChainNetWorth>? UnavailableChains { get; set; }
    }

    public class ChainNetWorth
    {
        [JsonPropertyName("chain")]
        public string Chain { get; set; } = "";

        [JsonPropertyName("native_balance")]
        public string NativeBalance { get; set; } = "";

        [JsonPropertyName("native_balance_formatted")]
        public string NativeBalanceFormatted { get; set; } = "";

        [JsonPropertyName("native_balance_usd")]
        public string NativeBalanceUsd { get; set; } = "";

        [JsonPropertyName("token_balance_usd")]
        public string TokenBalanceUsd { get; set; } = "";

        [JsonPropertyName("networth_usd")]
        public string NetworthUsd { get; set; } = "";
    }

    public class UnavailableChainNetWorth
    {
        [JsonPropertyName("chain_id")]
        public string ChainId { get; set; } = "";
    }
}
