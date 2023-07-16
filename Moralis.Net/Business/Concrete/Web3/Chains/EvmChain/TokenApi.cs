using Moralis.Net.Business.Abstract.Web3.Chains.EvmChain;
using Moralis.Net.Core.Results.Abstract;
using Moralis.Net.Core.Results.Concrete;
using Moralis.Net.Core.Utilities;
using Moralis.Net.Models.Enums;
using Moralis.Net.Models.Web3.EvmChain.TokenApi;

namespace Moralis.Net.Business.Concrete.Web3.Chains.EvmChain
{
    public class TokenApi : ITokenApi
    {
        public async Task<IDataResult<TokenPriceModel?>> GetTokenPriceAsync(string apiKey, string address, EvmChainEnum chain = EvmChainEnum.ETHEREUM, bool includePercentChange = true, ExchangeEnum exchange = ExchangeEnum.NONE, int? toBlock = null, CancellationToken ct = default)
        {
            try
            {
                var parameters = new Dictionary<string, string>
                {
                    { "chain", chain.GetDisplayName() },
                };

                if (exchange != ExchangeEnum.NONE)
                    parameters.Add("exchange", exchange.GetDisplayName());

                if (includePercentChange)
                    parameters.Add("include", "percent_change");

                if (toBlock.HasValue)
                    parameters.Add("to_block", toBlock.Value.ToString());

                var result = await RequestHelper.SendRequestAsync<TokenPriceModel?>($"/erc20/{address}/price", apiKey, parameters, ct: ct);
                return result;
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<TokenPriceModel?>(ex.Message);
            }
        }

        public async Task<IDataResult<List<TokenBalanceByWalletModel?>?>> GetTokenBalanceByWalletAsync(string apiKey, string address, List<string>? tokenAddresses = null, EvmChainEnum chain = EvmChainEnum.ETHEREUM, int? toBlock = null, CancellationToken ct = default)
        {
            try
            {
                var queryStr = $"chain={chain.GetDisplayName()}";

                if (toBlock.HasValue)
                    queryStr += $"&to_block={toBlock.Value}";

                if (tokenAddresses?.Count > 0)
                    foreach (var tokenAddress in tokenAddresses)
                        queryStr += $"&token_addresses={tokenAddress}";

                var result = await RequestHelper.SendRequestAsync<List<TokenBalanceByWalletModel?>?>($"/{address}/erc20?{queryStr}", apiKey, null, ct: ct);
                return result;
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<TokenBalanceByWalletModel?>?>(ex.Message);
            }
        }
    }
}
