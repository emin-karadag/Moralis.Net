﻿using Moralis.Net.Core.Results.Abstract;
using Moralis.Net.Models.Enums;
using Moralis.Net.Models.Web3.EvmChain.NftApi;

namespace Moralis.Net.Business.Abstract.Web3.Chains.EvmChain
{
    public interface INftApi
    {
        /// <summary>
        /// Get NFTs owned by a given address.
        /// </summary>
        /// <param name="apiKey">Moralis API Key</param>
        /// <param name="address">The address of the wallet</param>
        /// <param name="chain">The chain to query</param>
        /// <param name="tokenAddresses">The non-fungible token (NFT) addresses to get balances for</param>
        /// <param name="format">The format of the token ID</param>
        /// <param name="limit">The desired page size of the result.</param>
        /// <param name="cursor">The cursor returned in the previous response (used for getting the next page).</param>
        /// <param name="normalizeMetadata">The option to enable metadata normalization.</param>
        /// <param name="mediaItems">Should preview media data be returned</param>
        /// <returns></returns>
        Task<IDataResult<WalletNftModel?>> GetNftsByWalletAsync(string apiKey, string address, EvmChainEnum chain = EvmChainEnum.ETHEREUM, List<string>? tokenAddresses = null, FormatEnum format = FormatEnum.DECIMAL, int? limit = null, string? cursor = null, bool? normalizeMetadata = null, bool? mediaItems = null, CancellationToken ct = default);

        /// <summary>
        /// Get NFTs for a given contract address, including metadata for all NFTs (where available).
        /// </summary>
        /// <param name="apiKey">Moralis API Key</param>
        /// <param name="address">The address of the NFT contract</param>
        /// <param name="chain">The chain to query</param>
        /// <param name="format">The format of the token ID</param>
        /// <param name="limit">The desired page size of the result.</param>
        /// <param name="totalRanges">The number of subranges to split the results into</param>
        /// <param name="range">The desired subrange to query</param>
        /// <param name="cursor">The cursor returned in the previous response (used for getting the next page)</param>
        /// <param name="normalizeMetadata">The option to enable metadata normalization.</param>
        /// <param name="mediaItems">Should preview media data be returned</param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<IDataResult<ContractNftModel?>> GetNftsByContractAsync(string apiKey, string address, EvmChainEnum chain = EvmChainEnum.ETHEREUM, FormatEnum format = FormatEnum.DECIMAL, int? limit = null, int? totalRanges = null, int? range = null, string? cursor = null, bool? normalizeMetadata = null, bool? mediaItems = null, CancellationToken ct = default);

        /// <summary>
        /// Get NFT collections owned by a given wallet address.
        /// </summary>
        /// <param name="apiKey">Moralis API Key</param>
        /// <param name="address">The wallet address of the owner of NFTs in the collections</param>
        /// <param name="chain">The chain to query</param>
        /// <param name="limit">The desired page size of the result.</param>
        /// <param name="cursor">The cursor returned in the previous response (used for getting the next page).</param>
        /// <param name="ct"></param>
        /// <returns></returns>
        Task<IDataResult<WalletNftCollectionsModel?>> GetNftCollectionsByWalletAsync(string apiKey, string address, EvmChainEnum chain = EvmChainEnum.ETHEREUM, int? limit = null, string? cursor = null, CancellationToken ct = default);
    }
}
