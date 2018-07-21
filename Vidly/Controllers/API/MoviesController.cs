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
    public class MoviesController : ApiController
    {
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        //GET: /api/movies
        //[HttpGet]
        //public IHttpActionResult getMovies()
        //{
        //    return Ok(_context.Movies.ToList().Select(Mapper.Map<Movie, MovieDTO>));
        //}

        [HttpGet]
        public IHttpActionResult GetMovies(string query = null)
        {
            var moviesQuery = _context.Movies
                .Include(m => m.Genre)
                .Where(m => m.NumberAvailable > 0);

            if (!String.IsNullOrWhiteSpace(query))
                moviesQuery = moviesQuery.Where(c => c.Name.Contains(query));

            var movieDtos = moviesQuery
                .ToList()
                .Select(Mapper.Map<Movie, MovieDTO>);

            return Ok(movieDtos);
        }

        [HttpGet]
        public IHttpActionResult GetMovie(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);

            if (movie == null)
                return NotFound();

            return Ok(Mapper.Map<Movie, MovieDTO>(movie));
        }

        [HttpPost]
        [Authorize(Roles = RoleName.CanManageMoviesRole)]
        public IHttpActionResult PostMovie(MovieDTO movieDto)
        {
            /* Es de suponerse que ya viene  */
            movieDto.DateAdded = DateTime.Now;

            if (!ModelState.IsValid)
                return BadRequest("Movie format invalid");

            var movieInDb = 
                _context.Movies.Add(Mapper.Map<MovieDTO, Movie>(movieDto));
            _context.SaveChanges();

            movieDto.Id = movieInDb.Id;

            return Created(new Uri(Request.RequestUri + "/" + movieDto.Id), movieDto);
        }

        [HttpPut]
        [Authorize(Roles = RoleName.CanManageMoviesRole)]
        public IHttpActionResult UpdateMovie(int id, MovieDTO movieDto)
        {
            if (!ModelState.IsValid)
                return BadRequest("Movie format invalid");

            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                return NotFound();

            movieInDb.Id = id;

            Mapper.Map<MovieDTO, Movie>(movieDto, movieInDb);
            _context.SaveChanges();

            return Ok("Customer updated!");
        }

        [HttpDelete]
        [Authorize(Roles = RoleName.CanManageMoviesRole)]
        public IHttpActionResult DeleteMovie(int id)
        {
            var movieInDb = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movieInDb == null)
                return NotFound();

            _context.Movies.Remove(movieInDb);
            _context.SaveChanges();

            return Ok("Movie deleted successfully");
        }
    }
}
