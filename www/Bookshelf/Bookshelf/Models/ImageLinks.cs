namespace Bookshelf.Models
{
    using Bookshelf.Clients.GoogleBooksApi.ApiSchema;

    public class ImageLinks
    {
        public ImageLinks()
        {
        }

        public ImageLinks(GoogleImageLinks googleImageLinks)
        {
            this.SmallThumbnail = googleImageLinks.SmallThumbnail;
            this.Thumbnail = googleImageLinks.Thumbnail;
            this.Small = googleImageLinks.Small;
            this.Medium = googleImageLinks.Medium;
            this.Large = googleImageLinks.Large;
            this.ExtraLarge = googleImageLinks.ExtraLarge;
        }

        public string SmallThumbnail { get; set; }

        public string Thumbnail { get; set; }

        public string Small { get; set; }

        public string Medium { get; set; }

        public string Large { get; set; }

        public string ExtraLarge { get; set; }
    }
}