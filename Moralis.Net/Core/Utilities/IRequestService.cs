using Moralis.Net.Core.Results.Abstract;

namespace Moralis.Net.Core.Utilities
{
    public interface IRequestService
    {
        Task<IDataResult<T?>> SendRequestAsync<T>(string url, string apiKey, Dictionary<string, string>? parameters = null, string version = "", CancellationToken ct = default);
    }
}
