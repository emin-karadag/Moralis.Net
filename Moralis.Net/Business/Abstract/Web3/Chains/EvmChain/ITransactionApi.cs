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
    }
}
