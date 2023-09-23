using Moralis.Net.Core.Results.Abstract;
using Moralis.Net.Models.Enums;
using Moralis.Net.Models.Web3.EvmChain.TransactionApi;

namespace Moralis.Net.Business.Abstract.Web3.Chains.EvmChain
{
    public interface ITransactionApi
    {
        /// <summary>
        /// Get the contents of a transaction by the given transaction hash.
        /// </summary>
        /// <param name="apiKey">Moralis API Key</param>
        /// <param name="transactionHash">The transaction hash</param>
        /// <param name="chain">The chain to query</param>
        /// <param name="includeInternalTransactions">If the result should contain the internal transactions.</param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<IDataResult<TransactionByHashModel?>> GetTransactionByHashAsync(string apiKey, string transactionHash, EvmChainEnum chain = EvmChainEnum.ETHEREUM, bool includeInternalTransactions = false, CancellationToken ct = default);

        /// <summary>
        /// Get native transactions ordered by block number in descending order.
        /// </summary>
        /// <param name="apiKey">Moralis API Key</param>
        /// <param name="address">The address of the wallet</param>
        /// <param name="chain">The chain to query</param>
        /// <param name="fromBlock">The minimum block number from which to get the transactions</param>
        /// <param name="toBlock">The maximum block number from which to get the transactions.</param>
        /// <param name="fromDate">The start date from which to get the transactions</param>
        /// <param name="toDate">Get the transactions up to this date</param>
        /// <param name="cursor">The cursor returned in the previous response (used for getting the next page).</param>
        /// <param name="includeInternalTransactions">If the result should contain the internal transactions.</param>
        /// <param name="limit">The desired page size of the result.</param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<IDataResult<TransactionsByWalletModel?>> GetNativeTransactionsByWalletAsync(string apiKey, string address, EvmChainEnum chain = EvmChainEnum.ETHEREUM, int? fromBlock = null, int? toBlock = null, DateTime? fromDate = null, DateTime? toDate = null, string? cursor = null, bool includeInternalTransactions = false, int? limit = null, CancellationToken ct = default);
    }
}
