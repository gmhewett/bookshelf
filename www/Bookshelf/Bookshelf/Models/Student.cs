namespace Bookshelf.Models
{
    using System.Collections.Generic;

    public class Student : BookshelfUser
    {
        public virtual ICollection<Library> Libraries { get; set; }

        public virtual ICollection<Rental> Rentals { get; set; }
    }
}