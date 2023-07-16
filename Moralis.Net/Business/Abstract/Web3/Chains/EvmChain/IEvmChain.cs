namespace Moralis.Net.Business.Abstract.Web3.Chains.EvmChain
{
    public interface IEvmChain
    {
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
