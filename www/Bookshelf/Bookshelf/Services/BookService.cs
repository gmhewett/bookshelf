namespace Bookshelf.Services
{
    using System;
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
    }
}