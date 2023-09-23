using Moralis.Net.Core.Converters;
using Moralis.Net.Core.Models;
using System.Text.Json.Serialization;

namespace Moralis.Net.Models.Web3.EvmChain.BalanceApi
{
    public class NativeBalanceModel : MoralisBaseModel, IMoralisModel
    {
        [JsonPropertyName("balance")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal Balance { get; set; }
    }
}
