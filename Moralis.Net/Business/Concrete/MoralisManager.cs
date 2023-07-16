using Moralis.Net.Business.Abstract;
using Moralis.Net.Business.Abstract.Web3;
using Moralis.Net.Business.Concrete.Web3;

namespace Moralis.Net.Business.Concrete
{
    public class MoralisManager : IMoralisService
    {
        public MoralisManager()
        {
            Web3Api = new Web3Api();
            //StreamsApi = new StreamsApi();
            //AuthenticationApi = new AuthenticationApi();
        }

        public IWeb3Api Web3Api { get; set; }
        //public IStreamsApi StreamsApi { get; set; }
        //public IAuthenticationApi AuthenticationApi { get; set; }
    }
}
