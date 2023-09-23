using Moralis.Net.Core.Converters;
using Moralis.Net.Core.Models;
using System.Numerics;
using System.Text.Json.Serialization;

namespace Moralis.Net.Models.Web3.EvmChain.TransactionApi
{
    public class TransactionsByWalletModel : MoralisBaseModel, IMoralisModel
    {
        [JsonPropertyName("page_size")]
        public long PageSize { get; set; }

        [JsonPropertyName("page")]
        public long Page { get; set; }

        [JsonPropertyName("cursor")]
        public object? Cursor { get; set; }

        [JsonPropertyName("result")]
        public List<WalletTransactionData>? WalletTransactionData { get; set; }
    }

    public partial class WalletTransactionData
    {
        [JsonPropertyName("hash")]
        public string Hash { get; set; } = "";

        [JsonPropertyName("nonce")]
        [JsonConverter(typeof(StringToLongConvertor))]
        public long Nonce { get; set; }

        [JsonPropertyName("transaction_index")]
        [JsonConverter(typeof(StringToLongConvertor))]
        public long TransactionIndex { get; set; }

        [JsonPropertyName("from_address")]
        public string FromAddress { get; set; } = "";

        [JsonPropertyName("from_address_label")]
        public string? FromAddressLabel { get; set; }

        [JsonPropertyName("to_address")]
        public string ToAddress { get; set; } = "";

        [JsonPropertyName("to_address_label")]
        public string? ToAddressLabel { get; set; }

        [JsonPropertyName("value")]
        [JsonConverter(typeof(StringToBigIntegerConvertor))]
        public BigInteger Value { get; set; }

        [JsonPropertyName("gas")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal Gas { get; set; }

        [JsonPropertyName("gas_price")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal GasPrice { get; set; }

        [JsonPropertyName("input")]
        public string Input { get; set; } = "";

        [JsonPropertyName("receipt_cumulative_gas_used")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal ReceiptCumulativeGasUsed { get; set; }

        [JsonPropertyName("receipt_gas_used")]
        [JsonConverter(typeof(StringToDecimalConvertor))]
        public decimal ReceiptGasUsed { get; set; }

        [JsonPropertyName("receipt_contract_address")]
        public string? ReceiptContractAddress { get; set; }

        [JsonPropertyName("receipt_root")]
        public string? ReceiptRoot { get; set; }

        [JsonPropertyName("receipt_status")]
        public string ReceiptStatus { get; set; } = "";

        [JsonPropertyName("block_timestamp")]
        public DateTimeOffset BlockTimestamp { get; set; }

        [JsonPropertyName("block_number")]
        [JsonConverter(typeof(StringToLongConvertor))]
        public long BlockNumber { get; set; }

        [JsonPropertyName("block_hash")]
        public string BlockHash { get; set; } = "";

        [JsonPropertyName("transfer_index")]
        public List<long> TransferIndex { get; set; } = new List<long>();
    }
}
