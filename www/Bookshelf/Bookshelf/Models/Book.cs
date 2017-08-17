namespace Bookshelf.Models
{
    using System;
    using System.Collections.Generic;

    public class Book : BookshelfModel
    {
        public string Title { get; set; }

        public IEnumerable<string> Authors { get; set; }

        public string Description { get; set; }

        public string Publisher { get; set; }

        public DateTime PublishedDate { get; set; }

        public string Isbn10 { get; set; }

        public string Isbn13 { get; set; }

        public int PageCount { get; set; }

        public string MainCategory { get; set; }

        public IEnumerable<string> Categories { get; set; }

        public decimal AverageRating { get; set; }

        public int RatingsCount { get; set; }

        public ImageLinks ImageLinks { get; set; }

        public string Language { get; set; }

        public string InfoLink { get; set; }
    }
}