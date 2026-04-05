using Moralis.Net.Core.Results.Abstract;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Moralis.Net.Core.Utilities
{
    public interface IRequestService
    {
        Task<IDataResult<T?>> SendRequestAsync<T>(string url, string apiKey, Dictionary<string, string>? parameters = null, string version = "", CancellationToken ct = default);
    }
}
