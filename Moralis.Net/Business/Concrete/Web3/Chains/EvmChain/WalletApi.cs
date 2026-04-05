using Moralis.Net.Business.Abstract.Web3.Chains.EvmChain;
using Moralis.Net.Core.Results.Abstract;
using Moralis.Net.Core.Results.Concrete;
using Moralis.Net.Core.Utilities;
using Moralis.Net.Models.Enums;
using Moralis.Net.Models.Web3.EvmChain.WalletApi;

namespace Moralis.Net.Business.Concrete.Web3.Chains.EvmChain
{
    public class WalletApi : IWalletApi
    {
        private readonly IRequestService _requestService;

        public WalletApi(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public WalletApi()
        {
            _requestService = new RequestService();
        }
        public async Task<IDataResult<ChainActivityModel?>> GetChainActivityByWalletAsync(string apiKey, string address, List<EvmChainEnum>? chains = null, CancellationToken ct = default)
        {
            try
            {
                chains ??= [EvmChainEnum.ETHEREUM];
                var chainStr = string.Join("&chains=", chains.Select(chain => chain.GetDisplayName()));
                var result = await _requestService.SendRequestAsync<ChainActivityModel?>($"/wallets/{address}/chains?chains={chainStr}", apiKey, null, ct: ct);
                return result;
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ChainActivityModel?>(ex.Message);
            }
        }

        public async Task<IDataResult<NetWorthModel?>> GetWalletNetWorthAsync(string apiKey, string address, List<EvmChainEnum>? chains = null, bool? excludeSpam = null, bool? excludeUnverifiedContracts = null, int? maxTokenInactivity = null, decimal? minPairSideLiquidityUsd = null, CancellationToken ct = default)
        {
            try
            {
                var queryStr = "";
                if (chains?.Count > 0)
                {
                    queryStr += $"chains={string.Join("&chains=", chains.Select(chain => chain.GetDisplayName()))}";
                }

                if (excludeSpam.HasValue)
                    queryStr += $"{(string.IsNullOrEmpty(queryStr) ? "" : "&")}exclude_spam={excludeSpam.Value.ToString().ToLower()}";

                if (excludeUnverifiedContracts.HasValue)
                    queryStr += $"{(string.IsNullOrEmpty(queryStr) ? "" : "&")}exclude_unverified_contracts={excludeUnverifiedContracts.Value.ToString().ToLower()}";

                if (maxTokenInactivity.HasValue)
                    queryStr += $"{(string.IsNullOrEmpty(queryStr) ? "" : "&")}max_token_inactivity={maxTokenInactivity.Value}";

                if (minPairSideLiquidityUsd.HasValue)
                    queryStr += $"{(string.IsNullOrEmpty(queryStr) ? "" : "&")}min_pair_side_liquidity_usd={minPairSideLiquidityUsd.Value.ToString(System.Globalization.CultureInfo.InvariantCulture)}";

                var url = $"/wallets/{address}/net-worth";
                if (!string.IsNullOrEmpty(queryStr))
                    url += $"?{queryStr}";

                var result = await _requestService.SendRequestAsync<NetWorthModel?>(url, apiKey, null, ct: ct);
                return result;
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<NetWorthModel?>(ex.Message);
            }
        }
    }
}
