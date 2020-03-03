using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using Vidly.Models;

namespace Vidly.Controllers.Api
{
    public class NewRentalsController : ApiController
    {

        private ApplicationDbContext _context;

        public NewRentalsController()
        {
            _context = new ApplicationDbContext();
        }

        // Optimistic approach is better for internal API
        // We can be assured 3 edge cases won't happen since it's internal
        [HttpPost]
        public IHttpActionResult CreateNewRental(NewRentalDto newRentalDto)
        {
            var customer = _context.Customers
                .Single(c => c.Id == newRentalDto.CustomerId);

            var movies = _context.Movies
                .Where(m => newRentalDto.MovieIds.Contains(m.Id)).ToList();

            foreach (Movie m in movies)
            {
                if (m.NumberAvailable == 0)
                    return BadRequest("Movie is not available.");

                m.NumberAvailable--;

                var rental = new Rental
                {
                    Customer = customer,
                    Movie = m,
                    DateRented = DateTime.Now
                };

                _context.Rentals.Add(rental);
            }

            //_context.SaveChanges();

            return Ok();
        }

        // Defensive apporach is better for public APIs
        // All these edge validation checks make the API more stable
        //[HttpPost]
        //public IHttpActionResult DefensiveCreateNewRental(NewRentalDto newRentalDto)
        //{
        //    if (newRentalDto.MovieIds.Count == 0)
        //        return BadRequest("No Movie Ids have been given.");

        //    var customer = _context.Customers
        //        .SingleOrDefault(c => c.Id == newRentalDto.CustomerId);

        //    if (customer == null)
        //        return BadRequest("CustomerId is not valid.");

        //    var movies = _context.Movies
        //        .Where(m => newRentalDto.MovieIds.Contains(m.Id)).ToList();

        //    if (movies.Count != newRentalDto.MovieIds.Count)
        //        return BadRequest("One or more MovieIds are invalid.");

        //    foreach (Movie m in movies)
        //    {
        //        if (m.NumberAvailable == 0)
        //            return BadRequest("Movie is not available.");

        //        m.NumberAvailable -= 1;

        //        var rental = new Rental
        //        {
        //            Customer = customer,
        //            Movie = m,
        //            DateRented = DateTime.Now
        //        };

        //        _context.Rentals.Add(rental);
        //    }

        //    _context.SaveChanges();

        //    return Ok();
        //}
    }
}
