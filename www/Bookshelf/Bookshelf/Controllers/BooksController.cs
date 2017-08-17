namespace Bookshelf.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Http;
    using System.Web.Http.Description;
    using Bookshelf.Models;
    using Bookshelf.Services;

    public class BooksController : ApiController
    {
        private readonly IBooksService booksService;

        public BooksController(IBooksService booksService)
        {
            this.booksService = booksService ?? throw new ArgumentNullException(nameof(booksService));
        }

        // GET: api/Books
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await this.booksService.GetAsync();
        }

        // GET: api/Books/5
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> GetBook(int id)
        {
            Book book = await this.booksService.GetByIdAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // PUT: api/Books/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBook(int id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.Id)
            {
                return BadRequest();
            }

            try
            {
                await this.booksService.UpdateAsync(book);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Books
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> PostBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await this.booksService.CreateAsync(book);

            return CreatedAtRoute("DefaultApi", new { id = book.Id }, book);
        }

        // DELETE: api/Books/5
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> DeleteBook(int id)
        {
            Book book;
            try
            {
                book = await this.booksService.DeleteAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return Ok(book);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.booksService.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}