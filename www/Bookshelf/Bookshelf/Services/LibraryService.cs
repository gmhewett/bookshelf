namespace Bookshelf.Services
{
    using System;
    using Bookshelf.Models;

    public class LibraryService : ServiceBase<Library>, ILibraryService
    {
        public LibraryService(BookshelfDbContext dbContext) : base(dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }
        }
    }
}