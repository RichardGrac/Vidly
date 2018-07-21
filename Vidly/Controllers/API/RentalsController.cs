using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.DTOS;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class RentalsController : ApiController
    {
        ApplicationDbContext db = new ApplicationDbContext();


        [HttpGet]
        public IHttpActionResult GetRentals()
        {
            var rentals = db.Rental.ToList().Select(Mapper.Map<Rental, RentalDTO>);
            return Ok(rentals);
        }

        [HttpPost]
        public IHttpActionResult CreateRental(RentalDTO rentalDto)
        {
            if(!ModelState.IsValid)
                return BadRequest("Model is not valid");

            var customer = db.Customers.SingleOrDefault
                (c => c.Id == rentalDto.CustomerId);

            if (customer == null)
                return BadRequest("CustomerId is not valid");

            if(rentalDto.MovieIds == null || rentalDto.MovieIds.Count == 0)
                return BadRequest("No MoviesIds have been given.");

            // SELECT * FROM Movies WHERE Id IN (1,2,3):
            var movies = db.Movies.Where
                (m => rentalDto.MovieIds.Contains(m.Id)).ToList();

            if (movies.Count != rentalDto.MovieIds.Count)
                return BadRequest("One or more MovieIds are invalid.");
            
            foreach (var movie in movies)
            {
                if (movie.NumberAvailable == 0)
                    return BadRequest("'" + movie.Name + "' is not Available");
                movie.NumberAvailable--;
                var rental = new Rental
                {
                    Customer = customer,
                    Movie = movie,
                    DateRented = DateTime.Now
                };

                db.Rental.Add(rental);
            }

            db.SaveChanges();
            return Created("Rental(s) created successfully","");
        }
    }
}
