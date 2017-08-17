namespace Bookshelf.Services
{
    using System;
    using Bookshelf.Models;

    public class BooksService : ServiceBase<Book>, IBooksService
    {
        public BooksService(BookshelfDbContext dbContext) : base(dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }
        }
    }
}