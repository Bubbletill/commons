using Org.BouncyCastle.Asn1.Ocsp;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace BT_COMMONS.Database;

public class APIAccess
{
    private readonly string _apiUrl;
    private string? _token;

    public APIAccess(string apiUrl)
    {
        _apiUrl = apiUrl;
    }

    private HttpClient GetClient()
    {
        HttpClient client = new HttpClient(new HttpClientHandler
        {
            ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) =>
            {
                return true;
            }
        });

        client.BaseAddress = new Uri(_apiUrl);

        if (_token != null)
        {
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _token);
        }

        return client;
    }

    public void UpdateWithToken(string token)
    {
        _token = token;
    }

    public async Task<APIResponse<T>> Get<T>(string url)
    {
        using (HttpResponseMessage response = await GetClient().GetAsync(url))
        {
            try
            {
                var responseData = await response.Content.ReadFromJsonAsync<T>();
                return new APIResponse<T>
                {
                    StatusCode = response.StatusCode,
                    Data = responseData
                };
            }
            catch (Exception ex)
            {
                return new APIResponse<T>
                {
                    StatusCode = response.StatusCode,
                    Data = default
                };
            }
        }
    }

    public async Task<APIResponse<T>> Post<T, U>(string url, U data)
    {
        using (HttpResponseMessage response = await GetClient().PostAsJsonAsync(url, data))
        {
            var responseData = await response.Content.ReadFromJsonAsync<T>();
            return new APIResponse<T>
            {
                StatusCode = response.StatusCode,
                Data = responseData
            };
        }
    }
}
