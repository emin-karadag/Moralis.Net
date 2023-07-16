using Moralis.Net.Business.Abstract.Web3.Chains.EvmChain;
using Moralis.Net.Core.Results.Abstract;
using Moralis.Net.Core.Results.Concrete;
using Moralis.Net.Core.Utilities;
using Moralis.Net.Models.Enums;
using Moralis.Net.Models.Web3.EvmChain.TransactionApi;

namespace Moralis.Net.Business.Concrete.Web3.Chains.EvmChain
{
    public class TransactionApi : ITransactionApi
    {
        public async Task<IDataResult<TransactionByHashModel?>> GetTransactionByHashAsync(string apiKey, string transactionHash, EvmChainEnum chain = EvmChainEnum.ETHEREUM, bool includeInternalTransactions = false, CancellationToken ct = default)
        {
            try
            {
                var parameters = new Dictionary<string, string>
                {
                    { "chain", chain.GetDisplayName() }
                };

                if (includeInternalTransactions)
                    parameters.Add("include", "internal_transactions");

                var result = await RequestHelper.SendRequestAsync<TransactionByHashModel?>($"/transaction/{transactionHash}", apiKey, parameters, ct: ct);
                return result;
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<TransactionByHashModel?>(ex.Message);
            }
        }
    }
}
