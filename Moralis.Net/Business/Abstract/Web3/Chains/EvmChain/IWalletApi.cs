using Moralis.Net.Core.Results.Abstract;
using Moralis.Net.Models.Enums;
using Moralis.Net.Models.Web3.EvmChain.WalletApi;

namespace Moralis.Net.Business.Abstract.Web3.Chains.EvmChain
{
    public interface IWalletApi
    {
        /// <summary>
        /// Get the active chains for a wallet address.
        /// </summary>
        /// <param name="apiKey">Moralis API Key</param>
        /// <param name="address">Wallet address</param>
        /// <param name="chains">The chains to query.</param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<IDataResult<ChainActivityModel?>> GetChainActivityByWalletAsync(string apiKey, string address, List<EvmChainEnum>? chains = null, CancellationToken ct = default);

        /// <summary>
        /// Calculate the total net worth of a wallet in USD.
        /// </summary>
        /// <param name="apiKey">Moralis API Key</param>
        /// <param name="address">The wallet address</param>
        /// <param name="chains">The chains to query</param>
        /// <param name="excludeSpam">Exclude spam tokens from the result</param>
        /// <param name="excludeUnverifiedContracts">Exclude unverified contracts from the result</param>
        /// <param name="maxTokenInactivity">Exclude tokens inactive for more than the given amount of days</param>
        /// <param name="minPairSideLiquidityUsd">Exclude tokens with liquidity less than the specified amount in USD on a single side of the pair</param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<IDataResult<NetWorthModel?>> GetWalletNetWorthAsync(string apiKey, string address, List<EvmChainEnum>? chains = null, bool? excludeSpam = null, bool? excludeUnverifiedContracts = null, int? maxTokenInactivity = null, decimal? minPairSideLiquidityUsd = null, CancellationToken ct = default);
    }
}
