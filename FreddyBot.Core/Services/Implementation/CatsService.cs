#if cats
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Globalization;
using System.Net.Http;
using System.Runtime;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace FreddyBot.Discord.Services.Implementation;

public class CatsService
{

}
/*
#pragma warning disable 108 // Disable "CS0108 '{derivedDto}.ToJson()' hides inherited member '{dtoBase}.ToJson()'. Use the new keyword if hiding was intended."
#pragma warning disable 114 // Disable "CS0114 '{derivedDto}.RaisePropertyChanged(String)' hides inherited member 'dtoBase.RaisePropertyChanged(String)'. To make the current member override that implementation, add the override keyword. Otherwise add the new keyword."
#pragma warning disable 472 // Disable "CS0472 The result of the expression is always 'false' since a value of type 'Int32' is never equal to 'null' of type 'Int32?'
#pragma warning disable 612 // Disable "CS0612 '...' is obsolete"
#pragma warning disable 1573 // Disable "CS1573 Parameter '...' has no matching param tag in the XML comment for ...
#pragma warning disable 1591 // Disable "CS1591 Missing XML comment for publicly visible type or member ..."
#pragma warning disable 8073 // Disable "CS8073 The result of the expression is always 'false' since a value of type 'T' is never equal to 'null' of type 'T?'"
#pragma warning disable 3016 // Disable "CS3016 Arrays as attribute arguments is not CLS-compliant"
#pragma warning disable 8603 // Disable "CS8603 Possible null reference return"
#pragma warning disable 8604 // Disable "CS8604 Possible null reference argument for parameter"
*/

public abstract class CatsServiceClientBase : IDisposable
{

    protected const string BaseUrl = "https://cataas.com";
    protected readonly System.Net.Http.HttpClient httpClient;
    protected readonly JsonSerializerOptions JsonSerializerSettings = new()
    {
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
    };
    private bool isDisposed;

    public CatsServiceClientBase(System.Net.Http.HttpClient httpClient)
    {
        this.httpClient = httpClient;
    }

    protected virtual void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, string url) { }
    protected virtual void PrepareRequest(System.Net.Http.HttpClient client, System.Net.Http.HttpRequestMessage request, System.Text.StringBuilder urlBuilder) { }
    protected virtual void ProcessResponse(System.Net.Http.HttpClient client, System.Net.Http.HttpResponseMessage response) { }


    protected struct ObjectResponseResult<T>
    {
        public ObjectResponseResult(T? responseObject, string responseText)
        {
            this.Object = responseObject;
            this.Text = responseText;
        }

        public T? Object { get; }

        public string Text { get; }
    }

    public bool ReadResponseAsString { get; set; }

    protected virtual async Task<ObjectResponseResult<T>> ReadObjectResponseAsync<T>(System.Net.Http.HttpResponseMessage response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, CancellationToken cancellationToken)
    {
        if (response == null || response.Content == null)
        {
            return new ObjectResponseResult<T>(default(T), string.Empty);
        }

        if (ReadResponseAsString)
        {
            var responseText = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            try
            {
                var typedBody = JsonSerializer.Deserialize<T>(responseText, JsonSerializerSettings);
                return new ObjectResponseResult<T>(typedBody, responseText);
            }
            catch (JsonException exception)
            {
                var message = "Could not deserialize the response body string as " + typeof(T).FullName + ".";
                throw new ApiException(message, (int)response.StatusCode, responseText, headers, exception);
            }
        }
        else
        {
            try
            {
                using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);
                T? typedBody = await JsonSerializer.DeserializeAsync<T>(responseStream);
                return new ObjectResponseResult<T>(typedBody, string.Empty);
            }
            catch (JsonException exception)
            {
                var message = "Could not deserialize the response body stream as " + typeof(T).FullName + ".";
                throw new ApiException(message, (int)response.StatusCode, string.Empty, headers, exception);
            }
        }
    }

    protected string ConvertToString(bool value)
    {
        return System.Convert.ToString(value, CultureInfo.InvariantCulture).ToLowerInvariant();
    }

    protected virtual void Dispose(bool disposing)
    {
        if (!isDisposed)
        {
            if (disposing)
            {
                // dispose managed state (managed objects)
                httpClient.Dispose();
            }

            // TODO: free unmanaged resources (unmanaged objects) and override finalizer
            // TODO: set large fields to null
            isDisposed = true;
        }
    }

    // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
    // ~CatsServiceClientBase()
    // {
    //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
    //     Dispose(disposing: false);
    // }

    public void Dispose()
    {
        // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }
}
public partial class CatsServiceClient : CatsServiceClientBase
{
    public CatsServiceClient(System.Net.Http.HttpClient httpClient) : base(httpClient)
    {
    }
 
    /// <remarks>
    /// Get random cat
    /// </remarks>
    /// <returns>Cat returned</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual Task GetSimpleCatAsync(string type, string filter, string width, string height, string he, string h, bool? html, bool? json)
        => GetSimpleCatAsync(type, filter, width, height, html, json, CancellationToken.None);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <remarks>
    /// Get random cat
    /// </remarks>
    /// <returns>Cat returned</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual Task GetSimpleCatAsync(string type, string filter, string width, string height, bool? html, bool? json, CancellationToken cancellationToken)
        => GetCatAsync(IdTag: null, SaysText: null, type, filter, width, height, html, json, cancellationToken);
    
    protected virtual async Task GetCatAsync(string? IdTag, string? SaysText, string type, string filter, string width, string height, bool? html, bool? json, CancellationToken cancellationToken)
    {
        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl);
        urlBuilder_.Append("/cat");
        if (IdTag != null)
            urlBuilder_.Append('/').Append(System.Uri.EscapeDataString(IdTag));
        if(SaysText != null)
            urlBuilder_.Append("says/").Append(System.Uri.EscapeDataString(SaysText));

        NameValueCollection queryString = System.Web.HttpUtility.ParseQueryString(string.Empty);

        if (type != null)
            queryString.Add("t", System.Uri.EscapeDataString(type));

        if (filter != null)
            queryString.Add("f", System.Uri.EscapeDataString(filter));

        if (width != null)
            queryString.Add("w", System.Uri.EscapeDataString(width));

        if (height != null)
            queryString.Add("h", System.Uri.EscapeDataString(height));
        
        if (html != null)
            queryString.Add("html", System.Uri.EscapeDataString(ConvertToString(html.Value)));
        
        if (json != null)
            queryString.Add("json", System.Uri.EscapeDataString(ConvertToString(json.Value)));

        if(queryString.Count != 0)
        {
            urlBuilder_.Append('?');
            urlBuilder_.Append(queryString.ToString());
        }

        var client_ = httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("GET");

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        return;
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <remarks>
    /// Get cat by id
    /// </remarks>
    /// <returns>Cat returned</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual Task GetCatByIDAsync(string id, string type, string filter, string width, string height, bool? html, bool? json)
        => GetCatByIDAsync(id, type, filter, width, height, html, json, CancellationToken.None);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <remarks>
    /// Get cat by id
    /// </remarks>
    /// <returns>Cat returned</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual Task GetCatByIDAsync(string id, string type, string filter, string width, string height, bool? html, bool? json, CancellationToken cancellationToken)
        => GetCatAsync(id, SaysText: null, type, filter, width, height, html, json, cancellationToken);


    /// <remarks>
    /// Get random cat by tag
    /// </remarks>
    /// <returns>Cat returned</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual Task GetCatByTagAsync(string tag, string type, string filter, string width, string height, bool? html, bool? json)
        => GetCatByTagAsync(tag, type, filter, width, height, html, json, CancellationToken.None);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <remarks>
    /// Get random cat by tag
    /// </remarks>
    /// <returns>Cat returned</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual Task GetCatByTagAsync(string tag, string type, string filter, string width, string height, bool? html, bool? json, CancellationToken cancellationToken)
        => GetCatAsync(tag, SaysText: null, type, filter, width, height, html, json, cancellationToken);

}

public partial class ApiClient : CatsServiceClientBase
{
    public ApiClient(System.Net.Http.HttpClient httpClient) : base(httpClient) { }

    /// <remarks>
    /// Will return all cats
    /// </remarks>
    /// <returns>List of cats</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual Task<System.Collections.Generic.ICollection<Anonymous>> CatsAsync(double? limit, double? skip, string tags)
    {
        return CatsAsync(limit, skip, tags, CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <remarks>
    /// Will return all cats
    /// </remarks>
    /// <returns>List of cats</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async Task<System.Collections.Generic.ICollection<Anonymous>> CatsAsync(double? limit, double? skip, string tags, CancellationToken cancellationToken)
    {
        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl).Append("/api/cats?");
        if (limit.HasValue != null)
        {
            urlBuilder_.Append(System.Uri.EscapeDataString("limit") + "=").Append(limit.Value.ToString()).Append("&");
        }
        if (skip != null)
        {
            urlBuilder_.Append(System.Uri.EscapeDataString("skip") + "=").Append(skip.Value.ToString()).Append("&");
        }
        if (tags != null)
        {
            urlBuilder_.Append(System.Uri.EscapeDataString("tags") + "=").Append(System.Uri.EscapeDataString(ConvertToString(tags, System.Globalization.CultureInfo.InvariantCulture))).Append("&");
        }
        urlBuilder_.Length--;

        var client_ = httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<System.Collections.Generic.ICollection<Anonymous>>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <remarks>
    /// Will return all cats
    /// </remarks>
    /// <returns>List of tags</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual Task<ICollection<string>> TagsAsync()
    {
        return TagsAsync(CancellationToken.None);
    }

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <remarks>
    /// Will return all cats
    /// </remarks>
    /// <returns>List of tags</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async Task<ICollection<string>> TagsAsync(CancellationToken cancellationToken)
    {
        var urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl).Append("/api/tags");

        var client_ = httpClient;
        var disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<System.Collections.Generic.ICollection<string>>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object;
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    /// <remarks>
    /// Count how many cat
    /// </remarks>
    /// <returns>Count of cats</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual Task<int> CountAsync() => CountAsync(CancellationToken.None);

    /// <param name="cancellationToken">A cancellation token that can be used by other objects or threads to receive notice of cancellation.</param>
    /// <remarks>
    /// Count how many cat
    /// </remarks>
    /// <returns>Count of cats</returns>
    /// <exception cref="ApiException">A server side error occurred.</exception>
    public virtual async Task<int> CountAsync(CancellationToken cancellationToken)
    {
        System.Text.StringBuilder urlBuilder_ = new System.Text.StringBuilder();
        urlBuilder_.Append(BaseUrl).Append("/api/count");

        HttpClient client_ = httpClient;
        bool disposeClient_ = false;
        try
        {
            using (var request_ = new System.Net.Http.HttpRequestMessage())
            {
                request_.Method = new System.Net.Http.HttpMethod("GET");
                request_.Headers.Accept.Add(System.Net.Http.Headers.MediaTypeWithQualityHeaderValue.Parse("application/json"));

                PrepareRequest(client_, request_, urlBuilder_);

                var url_ = urlBuilder_.ToString();
                request_.RequestUri = new System.Uri(url_, System.UriKind.RelativeOrAbsolute);

                PrepareRequest(client_, request_, url_);

                var response_ = await client_.SendAsync(request_, System.Net.Http.HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false);
                var disposeResponse_ = true;
                try
                {
                    var headers_ = System.Linq.Enumerable.ToDictionary(response_.Headers, h_ => h_.Key, h_ => h_.Value);
                    if (response_.Content != null && response_.Content.Headers != null)
                    {
                        foreach (var item_ in response_.Content.Headers)
                            headers_[item_.Key] = item_.Value;
                    }

                    ProcessResponse(client_, response_);

                    var status_ = (int)response_.StatusCode;
                    if (status_ == 200)
                    {
                        var objectResponse_ = await ReadObjectResponseAsync<CatCountResponse>(response_, headers_, cancellationToken).ConfigureAwait(false);
                        if (objectResponse_.Object == null)
                        {
                            throw new ApiException("Response was null which was not expected.", status_, objectResponse_.Text, headers_, null);
                        }
                        return objectResponse_.Object.Number;
                    }
                    else
                    {
                        var responseData_ = response_.Content == null ? null : await response_.Content.ReadAsStringAsync().ConfigureAwait(false);
                        throw new ApiException("The HTTP status code of the response was not expected (" + status_ + ").", status_, responseData_, headers_, null);
                    }
                }
                finally
                {
                    if (disposeResponse_)
                        response_.Dispose();
                }
            }
        }
        finally
        {
            if (disposeClient_)
                client_.Dispose();
        }
    }

    protected class CatCountResponse
    {
        [JsonRequired]
        [JsonNumberHandling(JsonNumberHandling.AllowReadingFromString)]
        public int Number { get; set; }
    }
}

public partial class Cat
{
    [JsonPropertyName("_id")]
    [JsonRequired]
    public string _id { get; set; }

    [JsonPropertyName("tags")]
    [JsonRequired]
    public System.Collections.Generic.ICollection<string> Tags { get; set; } = new System.Collections.ObjectModel.Collection<string>();

    [JsonPropertyName("owner")]
    [JsonRequired]
    public string Owner { get; set; }

    [JsonPropertyName("createdAt")]
    [JsonRequired]
    public string CreatedAt { get; set; }

    [JsonRequired]
    [JsonPropertyName("updatedAt")]
    public string UpdatedAtString { get; set; }
}

public partial class CatError
{
    [JsonRequired]
    [JsonPropertyName("message")]
    public string Message { get; set; }

    [JsonRequired]
    [JsonPropertyName("code")]
    public int Code { get; set; }
}

public partial class Anonymous
{
    [JsonRequired]
    [JsonPropertyName("_id")]
    public string _id { get; set; }

    [JsonRequired]
    [JsonPropertyName("tags")]
    public System.Collections.Generic.ICollection<string> Tags { get; set; } = new System.Collections.ObjectModel.Collection<string>();

    [JsonRequired]
    [JsonPropertyName("owner")]
    public string Owner { get; set; }

    [JsonRequired]
    [JsonPropertyName("createdAt")]
    public string CreatedAt { get; set; }

    [JsonRequired]
    [JsonPropertyName("updatedAt")]
    public string UpdatedAt { get; set; }
}

public partial class ApiException : System.Exception
{
    public int StatusCode { get; private set; }

    public string Response { get; private set; }

    public System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> Headers { get; private set; }

    public ApiException(string message, int statusCode, string response, System.Collections.Generic.IReadOnlyDictionary<string, System.Collections.Generic.IEnumerable<string>> headers, System.Exception innerException)
        : base(message + "\n\nStatus: " + statusCode + "\nResponse: \n" + ((response == null) ? "(null)" : response.Substring(0, response.Length >= 512 ? 512 : response.Length)), innerException)
    {
        StatusCode = statusCode;
        Response = response;
        Headers = headers;
    }

    public override string ToString()
    {
        return string.Format("HTTP Response: \n\n{0}\n\n{1}", Response, base.ToString());
    }
}
#endif