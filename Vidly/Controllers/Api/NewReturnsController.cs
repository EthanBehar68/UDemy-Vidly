using System;
using System.Linq;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{

    public class NewReturnsController : ApiController
    {

        private ApplicationDbContext _context;

        public NewReturnsController()
        {
            _context = new ApplicationDbContext();
        }

        // We are going with an Optimistic Approach here...
        // What we need to test for is 
        // The rental we retrieved from DB is null
        // Or if for some reason it already contains a returned date which means this return was already processed.
        // Lastly if there was an  input error and given movie is full stocked
        // The OrderBy ThenBy allows multiple returns of the same video
        // While testing customer 'Ethan Behar' rented 'Toy Story 2' 3 times... he must really like it
        // So I wanted to figure out a solution to return all 3 rentals...
        // Even though the business logic probably shouldn't allow that...
        // Then again who am I to judge? You wanna rent 3 toy story 2 videos? Fine by me buddy just make sure you pay me.
        // /shrug
        [HttpPost]
        public IHttpActionResult CreateNewReturn(NewRentalDto newRentalDto)
        {
            var customer = _context.Customers
                .Single(c => c.Id == newRentalDto.CustomerId);

            var movies = _context.Movies
                .Where(m => newRentalDto.MovieIds.Contains(m.Id)).ToList();

            foreach (Movie m in movies)
            {
                var rental = _context.Rentals
                    .OrderBy(r => r.DateReturned)
                    .ThenBy(r=> r.DateRented)
                    .First(r => r.Customer.Id == customer.Id && r.Movie.Id == m.Id);

                if (rental == null || rental.DateReturned.HasValue)
                    return BadRequest();

                if (m.NumberAvailable++ > m.NumberInStock)
                    return BadRequest();

                m.NumberAvailable++;

                rental.DateReturned = DateTime.Now;
            }

            _context.SaveChanges();

            return Ok();
        }
    }
}
