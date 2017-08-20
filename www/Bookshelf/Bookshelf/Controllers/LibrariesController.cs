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

    [Authorize]
    public class LibrariesController : ApiController
    {
        private readonly ILibraryService libraryService;

        public LibrariesController(ILibraryService libraryService)
        {
            this.libraryService = libraryService ?? throw new ArgumentNullException(nameof(libraryService));
        }

        // GET: api/Libraries
        public async Task<IEnumerable<Library>> GetLibraries()
        {
            return await this.libraryService.GetAsync();
        }

        // GET: api/Libraries/5
        [ResponseType(typeof(Library))]
        public async Task<IHttpActionResult> GetLibrary(int id)
        {
            Library library = await this.libraryService.GetByIdAsync(id);
            if (library == null)
            {
                return NotFound();
            }

            return Ok(library);
        }

        // PUT: api/Libraries/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLibrary(int id, Library library)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != library.Id)
            {
                return BadRequest();
            }

            try
            {
                await this.libraryService.UpdateAsync(library);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Libraries
        [ResponseType(typeof(Library))]
        public async Task<IHttpActionResult> PostLibrary(Library library)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await this.libraryService.CreateAsync(library);

            return CreatedAtRoute("DefaultApi", new { id = library.Id }, library);
        }

        // DELETE: api/Libraries/5
        [ResponseType(typeof(Library))]
        public async Task<IHttpActionResult> DeleteLibrary(int id)
        {
            Library library;
            try
            {
                library = await this.libraryService.DeleteAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return Ok(library);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.libraryService.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}