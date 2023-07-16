using Moralis.Net.Core.Converters;
using Moralis.Net.Core.Models;
using System.Text.Json.Serialization;

namespace Moralis.Net.Models.Web3.EvmChain.TransactionApi
{
    public class TransactionByHashModel : MoralisBaseModel, IMoralisModel
    {
        [JsonPropertyName("hash")]
        public string Hash { get; set; } = "";

        [JsonPropertyName("nonce")]
        public string Nonce { get; set; } = "";

        [JsonPropertyName("transaction_index")]
        [JsonConverter(typeof(StringToIntConvertor))]
        public int TransactionIndex { get; set; }

        [JsonPropertyName("from_address")]
        public string FromAddress { get; set; } = "";

        [JsonPropertyName("from_address_label")]
        public object FromAddressLabel { get; set; } = "";

        [JsonPropertyName("to_address")]
        public string ToAddress { get; set; } = "";

        [JsonPropertyName("to_address_label")]
        public object? ToAddressLabel { get; set; }

        [JsonPropertyName("value")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal Value { get; set; }

        [JsonPropertyName("gas")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal Gas { get; set; }

        [JsonPropertyName("gas_price")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal GasPrice { get; set; }

        [JsonPropertyName("input")]
        public string Input { get; set; } = "";

        [JsonPropertyName("receipt_cumulative_gas_used")]
        public string ReceiptCumulativeGasUsed { get; set; } = "";

        [JsonPropertyName("receipt_gas_used")]
        public string ReceiptGasUsed { get; set; } = "";

        [JsonPropertyName("receipt_contract_address")]
        public object? ReceiptContractAddress { get; set; }

        [JsonPropertyName("receipt_root")]
        public object? ReceiptRoot { get; set; }

        [JsonPropertyName("receipt_status")]
        [JsonConverter(typeof(StringToIntConvertor))]
        public int ReceiptStatus { get; set; }

        [JsonPropertyName("block_timestamp")]
        public DateTimeOffset BlockTimestamp { get; set; }

        [JsonPropertyName("block_number")]
        [JsonConverter(typeof(StringToLongConvertor))]
        public long BlockNumber { get; set; }

        [JsonPropertyName("block_hash")]
        public string BlockHash { get; set; } = "";

        [JsonPropertyName("transfer_index")]
        public List<long>? TransferIndex { get; set; }

        [JsonPropertyName("logs")]
        public List<object>? Logs { get; set; }

        [JsonPropertyName("internal_transactions")]
        public List<object>? InternalTransactions { get; set; }
    }
}
