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
    }
}
