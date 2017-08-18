namespace Bookshelf.Models
{
    using System.Collections.Generic;

    public class Teacher : BookshelfUser
    {
        public virtual ICollection<Library> Libraries { get; set; }
    }
}