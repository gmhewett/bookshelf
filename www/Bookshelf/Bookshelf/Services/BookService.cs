namespace Bookshelf.Services
{
    using System;
    using System.Threading.Tasks;
    using Bookshelf.Clients;
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

        public Task<Book> LookUp(string isbn)
        {
            throw new NotImplementedException();
        }

        public Task<Book> CheckOutBook(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Book> ReturnBook(int id)
        {
            throw new NotImplementedException();
        }
    }
}