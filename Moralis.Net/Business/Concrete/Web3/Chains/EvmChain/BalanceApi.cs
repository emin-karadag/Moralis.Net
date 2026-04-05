using Moralis.Net.Business.Abstract.Web3.Chains.EvmChain;
using Moralis.Net.Core.Results.Abstract;
using Moralis.Net.Core.Results.Concrete;
using Moralis.Net.Core.Utilities;
using Moralis.Net.Models.Enums;
using Moralis.Net.Models.Web3.EvmChain.BalanceApi;

namespace Moralis.Net.Business.Concrete.Web3.Chains.EvmChain
{
    public class BalanceApi : IBalanceApi
    {
        private readonly IRequestService _requestService;

        public BalanceApi(IRequestService requestService)
        {
            _requestService = requestService;
        }

        public BalanceApi()
        {
            _requestService = new RequestService();
        }
        public async Task<IDataResult<NativeBalanceModel?>> GetNativeBalanceByWalletAsync(string apiKey, string address, EvmChainEnum chain = EvmChainEnum.ETHEREUM, long? toBlock = null, CancellationToken ct = default)
        {
            try
            {
                var parameters = new Dictionary<string, string>
                {
                    { "chain", chain.GetDisplayName() }
                };

                if (toBlock.HasValue)
                    parameters.Add("to_block", toBlock.Value.ToString());

                var result = await _requestService.SendRequestAsync<NativeBalanceModel>($"/{address}/balance", apiKey, parameters, ct: ct);
                return result;
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<NativeBalanceModel?>(ex.Message);
            }
        }

        public async Task<IDataResult<List<NativeBalanceMultiWalletModel>?>> GetNativeBalanceForMultipleWalletAsync(string apiKey, List<string> walletAddresses, EvmChainEnum chain = EvmChainEnum.ETHEREUM, long? toBlock = null, CancellationToken ct = default)
        {
            try
            {
                var queryStr = $"chain={chain.GetDisplayName()}";
                if (toBlock.HasValue)
                    queryStr += $"&to_block={toBlock.Value}";

                queryStr += $"&wallet_addresses={string.Join("&wallet_addresses=", walletAddresses.Select(address => address))}";

                var result = await _requestService.SendRequestAsync<List<NativeBalanceMultiWalletModel>?>($"/wallets/balances?{queryStr}", apiKey, null, ct: ct);
                return result;
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<List<NativeBalanceMultiWalletModel>?>(ex.Message);
            }
        }
    }
}
