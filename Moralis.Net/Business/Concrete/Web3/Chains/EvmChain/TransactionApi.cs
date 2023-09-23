using Moralis.Net.Business.Abstract.Web3.Chains.EvmChain;
using Moralis.Net.Core.Results.Abstract;
using Moralis.Net.Core.Results.Concrete;
using Moralis.Net.Core.Utilities;
using Moralis.Net.Models.Enums;
using Moralis.Net.Models.Web3.EvmChain.TransactionApi;

namespace Moralis.Net.Business.Concrete.Web3.Chains.EvmChain
{
    public class TransactionApi : ITransactionApi
    {
        public async Task<IDataResult<TransactionByHashModel?>> GetTransactionByHashAsync(string apiKey, string transactionHash, EvmChainEnum chain = EvmChainEnum.ETHEREUM, bool includeInternalTransactions = false, CancellationToken ct = default)
        {
            try
            {
                var parameters = new Dictionary<string, string>
                {
                    { "chain", chain.GetDisplayName() }
                };

                if (includeInternalTransactions)
                    parameters.Add("include", "internal_transactions");

                var result = await RequestHelper.SendRequestAsync<TransactionByHashModel?>($"/transaction/{transactionHash}", apiKey, parameters, ct: ct);
                return result;
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<TransactionByHashModel?>(ex.Message);
            }
        }

        public async Task<IDataResult<TransactionsByWalletModel?>> GetNativeTransactionsByWalletAsync(string apiKey, string address, EvmChainEnum chain = EvmChainEnum.ETHEREUM, int? fromBlock = null, int? toBlock = null, DateTime? fromDate = null, DateTime? toDate = null, string? cursor = null, bool includeInternalTransactions = false, int? limit = null, CancellationToken ct = default)
        {
            try
            {
                var parameters = new Dictionary<string, string>
                {
                    { "chain", chain.GetDisplayName() }
                };

                if (fromBlock.HasValue)
                    parameters.Add("from_block", fromBlock.Value.ToString());

                if (toBlock.HasValue)
                    parameters.Add("to_block", toBlock.Value.ToString());

                if (fromDate.HasValue)
                    parameters.Add("from_date", fromDate.Value.FormatDateTime("yyyy-MM-ddTHH:mm:ss.fffZ"));

                if (toDate.HasValue)
                    parameters.Add("to_date", toDate.Value.FormatDateTime("yyyy-MM-ddTHH:mm:ss.fffZ"));

                if (!string.IsNullOrEmpty(cursor))
                    parameters.Add("cursor", cursor.ToString());

                if (includeInternalTransactions)
                    parameters.Add("include", "internal_transactions");

                if (limit.HasValue)
                    parameters.Add("limit", limit.Value.ToString());

                var result = await RequestHelper.SendRequestAsync<TransactionsByWalletModel?>($"/{address}", apiKey, parameters, ct: ct);
                return result;
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<TransactionsByWalletModel?>(ex.Message);
            }
        }
    }
}
