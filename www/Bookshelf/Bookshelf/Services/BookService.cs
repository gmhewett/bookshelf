namespace Bookshelf.Services
{
    using System;
    using System.Threading.Tasks;
    using Bookshelf.Models;

    public class BookService : ServiceBase<Book>, IBookService
    {
        public BookService(BookshelfDbContext dbContext) : base(dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }
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