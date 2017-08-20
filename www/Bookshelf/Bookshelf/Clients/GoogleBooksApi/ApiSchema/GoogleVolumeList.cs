namespace Bookshelf.Clients.GoogleBooksApi.ApiSchema
{
    using System.Collections.Generic;

    public class GoogleVolumeList
    {
        public string Kind { get; set; }

        public IEnumerable<GoogleVolume> Items { get; set; }

        public int TotalItems { get; set; }
    }
}