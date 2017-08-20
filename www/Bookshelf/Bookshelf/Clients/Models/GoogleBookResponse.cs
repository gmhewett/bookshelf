namespace Bookshelf.Clients.Models
{
    using Bookshelf.Models;

    public class GoogleBookResponse
    {
        public GoogleBookResponse(Book book, GoogleBookError error)
        {
            this.Book = book;
            this.Error = error;
        }

        public Book Book { get; set; }

        public GoogleBookError Error { get; set; }
    }
}