namespace Bookshelf.Services
{
    using System;
    using System.Threading.Tasks;
    using Bookshelf.Clients.GoogleBooksApi;
    using Bookshelf.Models;

    public class BookService : ServiceBase<Book>, IBookService
    {
        private readonly IGoogleBooksApiClient booksApiClient;

        public BookService(IGoogleBooksApiClient booksApiClient, BookshelfDbContext dbContext) : base(dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }

            this.booksApiClient = booksApiClient ?? throw new ArgumentNullException(nameof(booksApiClient));
        }

        public async Task<Book> LookUpAsync(string isbn)
        {
            var googleVolume = await this.booksApiClient.LookUpByIsbnAsync(isbn);

            return googleVolume?.VolumeInfo == null ? null : new Book(googleVolume);
        }
    }
}