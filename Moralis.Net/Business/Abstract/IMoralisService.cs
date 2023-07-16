using Moralis.Net.Business.Abstract.Web3;

namespace Moralis.Net.Business.Abstract
{
    public interface IMoralisService
    {
        public IWeb3Api Web3Api { get; set; }
        //public IStreamsApi StreamsApi { get; set; }
        //public IAuthenticationApi AuthenticationApi { get; set; }
    }
}
