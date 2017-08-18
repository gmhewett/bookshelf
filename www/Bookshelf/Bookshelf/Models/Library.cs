namespace Bookshelf.Models
{
    using System.Collections.Generic;

    public class Library : BookshelfModel
    {
        public string OwnerId { get; set; }

        public virtual ICollection<Student> Students { get; set; }

        public virtual ICollection<Book> Books { get; set; }

        public virtual Teacher Owner { get; set; }
    }
}