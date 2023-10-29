using SprintPlanning.ExternalServices.Base;
using System.Text;
using System.Text.Json;

namespace SprintPlanning.Common.Extensions;

public static class HttpClientExtensions
{
    public static async Task<TResponse> GetAsync<TResponse>(
        this HttpClient httpClient,
        string url,
        CancellationToken cancellationToken)
    {
        var response = httpClient.GetAsync($"{url}", cancellationToken);

        return await ProcessResponse<TResponse>(response);

    }

    public static async Task<HttpResult<TResponse>> PostAsync<TRequest, TResponse>(
        this HttpClient httpClient,
        TRequest request,
        string url,
        CancellationToken cancellationToken) where TResponse : new()
    {
        HttpContent httpContent = new StringContent(
            JsonSerializer.Serialize(request),
            Encoding.UTF8,
            "application/json");

        HttpResponseMessage response = await httpClient.PostAsync(
            url,
            httpContent,
            cancellationToken);

        if (!response.IsSuccessStatusCode)
        {
            return new HttpResult<TResponse>(
                response.StatusCode);
        }

        return new HttpResult<TResponse>(
            await ResponseDeserialize<TResponse>(response),
            response.StatusCode);
    }

    private static async Task<T> ProcessResponse<T>(
        Task<HttpResponseMessage> responseTask)
    {
        var httpResponse = await responseTask;

        if (!httpResponse.IsSuccessStatusCode)
            throw new HttpRequestException(httpResponse.ToString());

        return await ResponseDeserialize<T?>(httpResponse);
    }

    private static async Task<T> ResponseDeserialize<T>(HttpResponseMessage response)
    {
        var contentString = await response.Content.ReadAsStringAsync();
        if (!string.IsNullOrWhiteSpace(contentString))
        {
            T dataResult = JsonSerializer.Deserialize<T>(contentString);

            return dataResult;
        }
        return default;
    }
}
