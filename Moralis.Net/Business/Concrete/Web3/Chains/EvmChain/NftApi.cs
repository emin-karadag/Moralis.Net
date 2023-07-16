using Moralis.Net.Business.Abstract.Web3.Chains.EvmChain;
using Moralis.Net.Core.Results.Abstract;
using Moralis.Net.Core.Results.Concrete;
using Moralis.Net.Core.Utilities;
using Moralis.Net.Models.Enums;
using Moralis.Net.Models.Web3.EvmChain.NftApi;

namespace Moralis.Net.Business.Concrete.Web3.Chains.EvmChain
{
    public class NftApi : INftApi
    {
        public async Task<IDataResult<WalletNftModel?>> GetNftsByWalletAsync(string apiKey, string address, EvmChainEnum chain = EvmChainEnum.ETHEREUM, List<string>? tokenAddresses = null, FormatEnum format = FormatEnum.DECIMAL, int? limit = null, string? cursor = null, bool? normalizeMetadata = null, bool? mediaItems = null, CancellationToken ct = default)
        {
            try
            {
                var queryStr = $"chain={chain.GetDisplayName()}&format={format.GetDisplayName()}";

                if (tokenAddresses?.Count > 0)
                    foreach (var tokenAddress in tokenAddresses)
                        queryStr += $"&token_addresses={tokenAddress}";

                if (limit.HasValue)
                    queryStr += $"&limit={limit}";

                if (!string.IsNullOrEmpty(cursor))
                    queryStr += $"&cursor={cursor}";

                if (normalizeMetadata.HasValue)
                    queryStr += $"&normalizeMetadata={normalizeMetadata}";

                if (mediaItems.HasValue)
                    queryStr += $"&media_items={mediaItems}";


                var result = await RequestHelper.SendRequestAsync<WalletNftModel?>($"/{address}/nft?{queryStr}", apiKey, null, ct: ct);
                return result;
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<WalletNftModel?>(ex.Message);
            }
        }

        public async Task<IDataResult<ContractNftModel?>> GetNftsByContractAsync(string apiKey, string address, EvmChainEnum chain = EvmChainEnum.ETHEREUM, FormatEnum format = FormatEnum.DECIMAL, int? limit = null, int? totalRanges = null, int? range = null, string? cursor = null, bool? normalizeMetadata = null, bool? mediaItems = null, CancellationToken ct = default)
        {
            try
            {
                var parameters = new Dictionary<string, string>
                {
                    { "chain", chain.GetDisplayName() },
                    { "format", format.GetDisplayName() },
                };

                if (limit.HasValue)
                    parameters.Add("limit", limit.Value.ToString());

                if (totalRanges.HasValue)
                    parameters.Add("totalRanges", totalRanges.Value.ToString());

                if (range.HasValue)
                    parameters.Add("range", range.Value.ToString());

                if (!string.IsNullOrEmpty(cursor))
                    parameters.Add("cursor", cursor.ToString());

                if (normalizeMetadata.HasValue)
                    parameters.Add("normalizeMetadata", normalizeMetadata.Value.ToString());

                if (mediaItems.HasValue)
                    parameters.Add("media_items", mediaItems.Value.ToString());

                var result = await RequestHelper.SendRequestAsync<ContractNftModel?>($"/nft/{address}", apiKey, parameters, ct: ct);
                return result;
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<ContractNftModel?>(ex.Message);
            }
        }

        public async Task<IDataResult<WalletNftCollectionsModel?>> GetNftCollectionsByWalletAsync(string apiKey, string address, EvmChainEnum chain = EvmChainEnum.ETHEREUM, int? limit = null, string? cursor = null, CancellationToken ct = default)
        {
            try
            {
                var parameters = new Dictionary<string, string>
                {
                    { "chain", chain.GetDisplayName() },
                };

                if (limit.HasValue)
                    parameters.Add("limit", limit.Value.ToString());

                if (!string.IsNullOrEmpty(cursor))
                    parameters.Add("cursor", cursor.ToString());

                var result = await RequestHelper.SendRequestAsync<WalletNftCollectionsModel?>($"/{address}/nft/collections", apiKey, parameters, ct: ct);
                return result;
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<WalletNftCollectionsModel>(ex.Message);
            }
        }
    }
}
