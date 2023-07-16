using Moralis.Net.Core.Results.Abstract;
using Moralis.Net.Models.Enums;
using Moralis.Net.Models.Web3.EvmChain.BalanceApi;

namespace Moralis.Net.Business.Abstract.Web3.Chains.EvmChain
{
    public interface IBalanceApi
    {
        /// <summary>
        /// Get native balance for a specific address.
        /// </summary>
        /// <param name="apiKey">Moralis API Key</param>
        /// <param name="address">The address for which the native balance will be checked</param>
        /// <param name="chain">The chain to query</param>
        /// <param name="toBlock">The block number on which the balances should be checked</param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<IDataResult<NativeBalanceModel?>> GetNativeBalanceByWalletAsync(string apiKey, string address, EvmChainEnum chain = EvmChainEnum.ETHEREUM, long? toBlock = null, CancellationToken ct = default);

        /// <summary>
        /// Get the native balances for a set of specific addresses
        /// </summary>
        /// <param name="apiKey">Moralis API Key</param>
        /// <param name="walletAddresses">The addresses to get metadata for</param>
        /// <param name="chain">The chain to query</param>
        /// <param name="toBlock">The block number on which the balances should be checked</param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<IDataResult<List<NativeBalanceMultiWalletModel>?>> GetNativeBalanceForMultipleWalletAsync(string apiKey, List<string> walletAddresses, EvmChainEnum chain = EvmChainEnum.ETHEREUM, long? toBlock = null, CancellationToken ct = default);
    }
}
