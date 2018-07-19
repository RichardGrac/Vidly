using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Vidly.DTOS;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class RentalsController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();

        [HttpPost]
        public IHttpActionResult CreateRental(RentalDTO rentalDto)
        {
            var customer = db.Customers.Single(c => c.Id == rentalDto.CustomerId);
            // SELECT * FROM Movies WHERE Id IN (1,2,3):
            var movies = db.Movies.Where(m => rentalDto.MovieIds.Contains(m.Id));

            foreach (var movie in movies)
            {
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                db.Rental.Add(rental);
            }

            db.SaveChanges();
            return Ok();
        }
    }
}
