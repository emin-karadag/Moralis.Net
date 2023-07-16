using Moralis.Net.Core.Results.Abstract;
using Moralis.Net.Models.Enums;
using Moralis.Net.Models.Web3.EvmChain.TokenApi;

namespace Moralis.Net.Business.Abstract.Web3.Chains.EvmChain
{
    public interface ITokenApi
    {
        /// <summary>
        /// Get the token price denominated in the blockchain's native token and USD.
        /// </summary>
        /// <param name="apiKey">Moralis API Key</param>
        /// <param name="address">The address of the token contract</param>
        /// <param name="chain">The chain to query</param>
        /// <param name="includePercentChange">If the result should contain the 24hr percent change</param>
        /// <param name="exchange">The factory name or address of the token exchange.</param>
        /// <param name="toBlock">The block number from which the token price should be checked</param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<IDataResult<TokenPriceModel?>> GetTokenPriceAsync(string apiKey, string address, EvmChainEnum chain = EvmChainEnum.ETHEREUM, bool includePercentChange = true, ExchangeEnum exchange = ExchangeEnum.NONE, int? toBlock = null, CancellationToken ct = default);

        /// <summary>
        /// Get token balances for a specific wallet address.
        /// </summary>
        /// <param name="apiKey">Moralis API Key</param>
        /// <param name="address">The address from which token balances will be checked</param>
        /// <param name="tokenAddresses">The addresses to get balances for (optional)</param>
        /// <param name="chain">The chain to query</param>
        /// <param name="toBlock">The block number from which the balances should be checked</param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<IDataResult<List<TokenBalanceByWalletModel?>?>> GetTokenBalanceByWalletAsync(string apiKey, string address, List<string>? tokenAddresses = null, EvmChainEnum chain = EvmChainEnum.ETHEREUM, int? toBlock = null, CancellationToken ct = default);
    }
}
