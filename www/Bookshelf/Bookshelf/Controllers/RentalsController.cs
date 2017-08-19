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

    public class RentalsController : ApiController
    {
        private readonly IRentalService rentalService;

        public RentalsController(IRentalService rentalService)
        {
            this.rentalService = rentalService ?? throw new ArgumentNullException(nameof(rentalService));
        }

        // GET: api/Rentals
        public async Task<IEnumerable<Rental>> GetRentals()
        {
            return await this.rentalService.GetAsync();
        }

        // GET: api/Rentals/5
        [ResponseType(typeof(Rental))]
        public async Task<IHttpActionResult> GetRental(int id)
        {
            Rental rental = await this.rentalService.GetByIdAsync(id);
            if (rental == null)
            {
                return NotFound();
            }

            return Ok(rental);
        }

        // PUT: api/Rentals/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutRental(int id, Rental rental)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != rental.Id)
            {
                return BadRequest();
            }

            try
            {
                await this.rentalService.UpdateAsync(rental);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Rentals
        [ResponseType(typeof(Rental))]
        public async Task<IHttpActionResult> PostRental(Rental rental)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await this.rentalService.CreateAsync(rental);

            return CreatedAtRoute("DefaultApi", new { id = rental.Id }, rental);
        }

        // DELETE: api/Rentals/5
        [ResponseType(typeof(Rental))]
        public async Task<IHttpActionResult> DeleteRental(int id)
        {
            Rental rental;
            try
            {
                rental = await this.rentalService.DeleteAsync(id);
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }

            return Ok(rental);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.rentalService.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}