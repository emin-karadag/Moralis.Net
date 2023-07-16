using Moralis.Net.Business.Abstract.Web3.Chains.EvmChain;

namespace Moralis.Net.Business.Abstract.Web3
{
    public interface IWeb3Api
    {
        public IEvmChain EvmChain { get; set; }
        //public IAptosChain AptosChain { get; set; }
        //public ISolonaChain SolonaChain { get; set; }
    }
}
