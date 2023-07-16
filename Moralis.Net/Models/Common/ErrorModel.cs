using System.Text.Json.Serialization;

namespace Moralis.Net.Models.Common
{
    public class ErrorModel
    {
        [JsonPropertyName("message")]
        public string Message { get; set; } = "";
    }
}
