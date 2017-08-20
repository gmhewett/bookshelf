namespace Bookshelf.Clients.GoogleBooksApi.ApiSchema
{
    using System.Collections.Generic;

    public class GoogleVolumeInfo
    {
        public string Title { get; set; }

        public string Subtitle { get; set; }

        public IEnumerable<string> Authors { get; set; }

        public string Publisher { get; set; }

        public string PublishedDate { get; set; }

        public string Description { get; set; }

        public IEnumerable<GoogleIndustryIdentifier> IndustryIdentifiers { get; set; }

        public int PageCount { get; set; }

        public GoogleDimensions Dimensions { get; set; }

        public string PrintType { get; set; }

        public string MainCategory { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public decimal AverageRating { get; set; }

        public int RatingsCount { get; set; }

        public string ContentVersion { get; set; }

        public GoogleImageLinks ImageLinks { get; set; }

        public string Language { get; set; }

        public string PreviewLink { get; set; }

        public string InfoLink { get; set; }

        public string CanonicalVolumeLink { get; set; }
    }
}