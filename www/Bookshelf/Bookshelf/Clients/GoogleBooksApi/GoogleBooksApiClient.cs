namespace Bookshelf.Clients.GoogleBooksApi
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Bookshelf.Clients.GoogleBooksApi.ApiSchema;
    using Bookshelf.Config;
    using Bookshelf.Loggers;
    using Newtonsoft.Json;

    public class GoogleBooksApiClient : IGoogleBooksApiClient
    {
        private readonly IBookshelfConfig config;
        private readonly IBookshelfLogger logger;

        public GoogleBooksApiClient(IBookshelfConfig config, IBookshelfLogger logger)
        {
            this.config = config ?? throw new ArgumentNullException(nameof(config));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<GoogleVolume> LookUpByIsbnAsync(string isbn)
        {
            string rootUrl = this.config.Get<string>("GoolgeBooksApi.RootUrl");
            string relativeUrlFormatter = this.config.Get<string>("GoogleBooksApi.IsbnLookupUrlFormatter");
            string requestUrl = rootUrl + string.Format(relativeUrlFormatter, isbn);

            return await this.SendRequest(requestUrl, HttpMethod.Get);
        }

        private async Task<GoogleVolume> SendRequest(string url, HttpMethod method)
        {
            using (var client = new HttpClient())
            {
                Uri requestUri;
                try
                {
                    if (!Uri.TryCreate(url, UriKind.Absolute, out requestUri))
                    {
                        this.logger.LogError($"Could not create Google Books API Uri.");
                        return null;
                    }
                }
                catch (UriFormatException e)
                {
                    this.logger.LogError($"Could not create Google Books API Uri. Exception: {e}");
                    return null;
                }

                var request = new HttpRequestMessage(method, requestUri);
                var response = await client.SendAsync(request);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    this.logger.LogError($"Google Books Api Response was not successful. Status code: {response.StatusCode}");
                    return null;
                }

                response.EnsureSuccessStatusCode();

                var googleVolumeList = JsonConvert.DeserializeObject<GoogleVolumeList>(await response.Content.ReadAsStringAsync());

                if (googleVolumeList == null || googleVolumeList.TotalItems < 1)
                {
                    this.logger.LogError("Unable to deserialize Goolge Books API Response.");
                    return null;
                }

                if (googleVolumeList.TotalItems > 1)
                {
                    this.logger.LogWarning("More than one book returned from Google Books API.");
                }

                return googleVolumeList.Items.FirstOrDefault();
            }
        }
    }
}