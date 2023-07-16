using Moralis.Net.Business.Abstract.Web3;
using Moralis.Net.Business.Abstract.Web3.Chains.EvmChain;
using Moralis.Net.Business.Concrete.Web3.Chains.EvmChain;

namespace Moralis.Net.Business.Concrete.Web3
{
    public class Web3Api : IWeb3Api
    {
        public Web3Api()
        {
            EvmChain = new EvmChain();
            //AptosChain = new AptosChain();
            //SolonaChain = new SolonaChain();
        }

        public IEvmChain EvmChain { get; set; }
        //public IAptosChain AptosChain { get; set; }
        //public ISolonaChain SolonaChain { get; set; }
    }
}
