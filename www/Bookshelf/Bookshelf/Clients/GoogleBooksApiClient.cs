namespace Bookshelf.Clients
{
    using System;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Bookshelf.Clients.Models;
    using Bookshelf.Loggers;
    using Bookshelf.Models;
    using Microsoft.Azure;
    using Newtonsoft.Json;

    public class GoogleBooksApiClient : IGoogleBooksApiClient
    {
        private readonly IBookshelfLogger logger;

        public GoogleBooksApiClient(IBookshelfLogger logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<GoogleBookResponse> LookUpByIsbn(string isbn)
        {
            string rootUrl = CloudConfigurationManager.GetSetting("GoolgeBooksApi.RootUrl");
            string relativeUrlFormatter = CloudConfigurationManager.GetSetting("GoogleBooksApi.IsbnLookupUrlFormatter");
            string requestUrl = rootUrl + string.Format(relativeUrlFormatter, isbn);

            return await this.SendRequest(requestUrl, HttpMethod.Get);
        }

        private async Task<GoogleBookResponse> SendRequest(string url, HttpMethod method)
        {
            using (var client = new HttpClient())
            {
                Uri requestUri;
                try
                {
                    if (!Uri.TryCreate(url, UriKind.Absolute, out requestUri))
                    {
                        this.logger.LogError($"Could not create Google Books API Uri.");
                        return await Task.FromResult(new GoogleBookResponse(null, GoogleBookError.UrlError));
                    }
                }
                catch (UriFormatException e)
                {
                    this.logger.LogError($"Could not create Google Books API Uri. Exception: {e}");
                    return await Task.FromResult(new GoogleBookResponse(null, GoogleBookError.UrlError));
                }

                var request = new HttpRequestMessage(method, requestUri);

                var response = await client.SendAsync(request);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    this.logger.LogError($"Google Books Api Response was not successful. Status code: {response.StatusCode}");
                    return await Task.FromResult(new GoogleBookResponse(null, GoogleBookError.NotSuccess));
                }

                response.EnsureSuccessStatusCode();

                var book = JsonConvert.DeserializeObject<Book>(await response.Content.ReadAsStringAsync());

                if (book == null)
                {
                    this.logger.LogError("Unable to deserialize Goolge Books API Response.");
                    return await Task.FromResult(new GoogleBookResponse(null, GoogleBookError.Deserialize));
                }

                return new GoogleBookResponse(book, GoogleBookError.None);
            }
        }
    }
}