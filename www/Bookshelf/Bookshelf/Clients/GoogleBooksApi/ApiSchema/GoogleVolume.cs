namespace Bookshelf.Clients.GoogleBooksApi.ApiSchema
{
    public class GoogleVolume
    {
        public string Kind { get; set; }

        public string Id { get; set; }

        public string ETag { get; set; }

        public string SelfLink { get; set; }

        public GoogleVolumeInfo VolumeInfo { get; set; }
    }
}