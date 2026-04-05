using Moralis.Net.Core.Results.Abstract;
using Moralis.Net.Core.Results.Concrete;
using Moralis.Net.Models.Common;
using System.Net;
using System.Net.Http.Json;

namespace Moralis.Net.Core.Utilities
{
    public class RequestService : IRequestService
    {
        private static readonly HttpClient _staticHttpClient = new HttpClient();
        private readonly HttpClient _httpClient;

        public RequestService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public RequestService()
        {
            _httpClient = _staticHttpClient;
        }

        public async Task<IDataResult<T?>> SendRequestAsync<T>(string url, string apiKey, Dictionary<string, string>? parameters = null, string version = "", CancellationToken ct = default)
        {
            try
            {
                var queryString = MoralisHelper.CreateQueryString(parameters);
                var requestUri = MoralisHelper.GetRequestUrl(url, version);
                var uriBuilder = new UriBuilder(requestUri);
                if (parameters?.Count > 0)
                    uriBuilder.Query = queryString;

                using var request = new HttpRequestMessage(HttpMethod.Get, uriBuilder.Uri);
                request.Headers.Add("X-Api-Key", apiKey);

                var response = await _httpClient.SendAsync(request, ct);
                if (response.StatusCode == HttpStatusCode.OK)
                {
#if DEBUG
                    var res = await response.Content.ReadAsStringAsync(ct);
#endif
                    var data = await response.Content.ReadFromJsonAsync<T?>(cancellationToken: ct);
                    return new SuccessDataResult<T?>(data);
                }
                else
                {
                    var data = await response.Content.ReadFromJsonAsync<ErrorModel?>(cancellationToken: ct);
                    return new ErrorDataResult<T?>(data?.Message ?? "");
                }
            }
            catch (HttpRequestException ex)
            {
                // İsteği gönderirken bir hata oluştu
                return new ErrorDataResult<T?>(ex.Message);
            }
            catch (TaskCanceledException ex)
            {
                // İşlem iptal edildi
                return new ErrorDataResult<T?>(ex.Message);
            }
            catch (Exception ex)
            {
                // Diğer hatalar
                return new ErrorDataResult<T?>(ex.Message);
            }
        }
    }
}
