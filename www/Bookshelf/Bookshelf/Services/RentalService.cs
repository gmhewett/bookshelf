namespace Bookshelf.Services
{
    using System;
    using Bookshelf.Models;

    public class RentalService : ServiceBase<Rental>, IRentalService
    {
        public RentalService(BookshelfDbContext dbContext) : base(dbContext)
        {
            if (dbContext == null)
            {
                throw new ArgumentNullException(nameof(dbContext));
            }
        }
    }
}
