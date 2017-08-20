namespace Bookshelf.Models
{
    using System.Collections.Generic;
    using System.Linq;
    using Bookshelf.Clients.GoogleBooksApi.ApiSchema;

    public class Book : BookshelfModel
    {
        public Book()
        {
        }

        public Book(GoogleVolume volume)
        {
            this.Title = volume.VolumeInfo.Title;
            this.Authors = volume.VolumeInfo.Authors;
            this.Description = volume.VolumeInfo.Description;
            this.Publisher = volume.VolumeInfo.Publisher;
            this.PublishedDate = volume.VolumeInfo.PublishedDate;
            this.PageCount = volume.VolumeInfo.PageCount;
            this.MainCategory = volume.VolumeInfo.MainCategory;
            this.Categories = volume.VolumeInfo.Categories;
            this.AverageRating = volume.VolumeInfo.AverageRating;
            this.RatingsCount = volume.VolumeInfo.RatingsCount;
            this.Language = volume.VolumeInfo.Language;
            this.InfoLink = volume.VolumeInfo.InfoLink;

            this.ImageLinks = new ImageLinks(volume.VolumeInfo.ImageLinks);

            this.Isbn10 = volume.VolumeInfo.IndustryIdentifiers
                .Where(i => i.Type == "ISBN_10")
                .Select(t => t.Identifier)
                .FirstOrDefault();

            this.Isbn13 = volume.VolumeInfo.IndustryIdentifiers
                .Where(i => i.Type == "ISBN_13")
                .Select(t => t.Identifier)
                .FirstOrDefault();
        }

        public int LibraryId { get; set; }

        public int TotalCopies { get; set; }

        public int AvailableCopies { get; set; }

        public ICollection<Rental> Rentals { get; set; }

        public string Title { get; set; }

        public IEnumerable<string> Authors { get; set; }

        public string Description { get; set; }

        public string Publisher { get; set; }

        public string PublishedDate { get; set; }

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

        public virtual Library Library { get; set; }
    }
}