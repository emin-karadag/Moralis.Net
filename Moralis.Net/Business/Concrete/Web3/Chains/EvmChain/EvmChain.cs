using Moralis.Net.Business.Abstract.Web3.Chains.EvmChain;

namespace Moralis.Net.Business.Concrete.Web3.Chains.EvmChain
{
    public class EvmChain : IEvmChain
    {
        public EvmChain()
        {
            //MarketApi = new MarketApi();
            NftApi = new NftApi();
            WalletApi = new WalletApi();
            TokenApi = new TokenApi();
            BalanceApi = new BalanceApi();
            TransactionApi = new TransactionApi();
            //BlockApi = new BlockApi();
            //EventsApi = new EventsApi();
            //DefiApi = new DefiApi();
            //ResolveApi = new ResolveApi();
            //UtilsApi = new UtilsApi();
        }

        //public IMarketApi MarketApi { get; set; }
        public INftApi NftApi { get; set; }
        public IWalletApi WalletApi { get; set; }
        public ITokenApi TokenApi { get; set; }
        public IBalanceApi BalanceApi { get; set; }
        public ITransactionApi TransactionApi { get; set; }
        //public IBlockApi BlockApi { get; set; }
        //public IEventsApi EventsApi { get; set; }
        //public IDefiApi DefiApi { get; set; }
        //public IResolveApi ResolveApi { get; set; }
        //public IUtilsApi UtilsApi { get; set; }
    }
}
