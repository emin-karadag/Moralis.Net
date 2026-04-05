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
    }
}
