using Moralis.Net.Core.Results.Abstract;
using Moralis.Net.Core.Results.Concrete;
using Moralis.Net.Models.Common;
using System.Net;
using System.Net.Http.Json;

namespace Moralis.Net.Core.Utilities
{
    public static class RequestHelper
    {
        public static async Task<IDataResult<T?>> SendRequestAsync<T>(string url, string apiKey, Dictionary<string, string>? parameters = null, string version = "", CancellationToken ct = default)
        {
            try
            {
                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Add("X-Api-Key", apiKey);

                var queryString = MoralisHelper.CreateQueryString(parameters);
                var requestUri = MoralisHelper.GetRequestUrl(url, version);
                var uriBuilder = new UriBuilder(requestUri);
                if (parameters?.Count > 0)
                    uriBuilder.Query = queryString;

                var response = await httpClient.GetAsync(uriBuilder.Uri, ct);
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
