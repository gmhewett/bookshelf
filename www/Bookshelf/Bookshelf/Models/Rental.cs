namespace Bookshelf.Models
{
    using System;

    public class Rental : BookshelfModel
    {
        public int StudentId { get; set; }

        public int BookId { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime DueDate { get; set; }

        public bool IsReturned { get; set; }

        public virtual Student Student { get; set; }

        public virtual Book Book { get; set; }
    }
}