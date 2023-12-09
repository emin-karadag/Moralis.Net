using Moralis.Net.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Moralis.Net.Models.Web3.EvmChain.NftApi
{
    public class ResyncNftMetadataModel : MoralisBaseModel, IMoralisModel
    {
        [JsonPropertyName("status")]
        public string Status { get; set; } = "";
    }
}
