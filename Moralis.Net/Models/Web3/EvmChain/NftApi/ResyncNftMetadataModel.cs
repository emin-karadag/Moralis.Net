using Moralis.Net.Core.Models;
using System.Text.Json.Serialization;

namespace Moralis.Net.Models.Web3.EvmChain.NftApi
{
    public class ResyncNftMetadataModel : MoralisBaseModel, IMoralisModel
    {
        [JsonPropertyName("status")]
        public string Status { get; set; } = "";
    }
}
