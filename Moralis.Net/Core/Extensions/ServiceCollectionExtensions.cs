using Microsoft.Extensions.DependencyInjection;
using Moralis.Net.Business.Abstract;
using Moralis.Net.Business.Abstract.Web3;
using Moralis.Net.Business.Abstract.Web3.Chains.EvmChain;
using Moralis.Net.Business.Concrete;
using Moralis.Net.Business.Concrete.Web3;
using Moralis.Net.Business.Concrete.Web3.Chains.EvmChain;
using Moralis.Net.Core.Utilities;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddMoralisNet(this IServiceCollection services)
        {
            // Core HTTP Service
            services.AddHttpClient<IRequestService, RequestService>();

            // Web3 EvmChain APIs
            services.AddTransient<INftApi, NftApi>();
            services.AddTransient<IWalletApi, WalletApi>();
            services.AddTransient<ITokenApi, TokenApi>();
            services.AddTransient<IBalanceApi, BalanceApi>();
            services.AddTransient<ITransactionApi, TransactionApi>();
            
            // Managers
            services.AddTransient<IEvmChain, EvmChain>();
            services.AddTransient<IWeb3Api, Web3Api>();
            services.AddTransient<IMoralisService, MoralisManager>();

            return services;
        }
    }
}
