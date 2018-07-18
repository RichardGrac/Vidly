using System;
using System.Collections.Generic;
using System.Data.Entity;   // Para la carga 'Eager' de MembershipType
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Models.ViewModels;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private List<Movie> movies = new List<Movie>();
        private ApplicationDbContext _context;

        public MoviesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // localhost:5000/Movies
        public ActionResult Index()
        {
            getMovies();
            if (User.IsInRole(RoleName.CanManageMoviesRole))
                return View("List", movies);

            return View("ReadOnlyList", movies);
        }
        
        /* Gets available Movies from the DB */
        private void getMovies()
        {
            this.movies = _context.Movies.Include(m => m.Genre).ToList();
        }


        /* Gets a Movie Details */
        public ActionResult Details(int id)
        {
            var movieSearched = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (movieSearched == null)
            {
                return HttpNotFound();
            }

            return View(movieSearched);
        }

        /* Method that returns the View with a Model for a New Movie Register */
        [Authorize(Roles = RoleName.CanManageMoviesRole)]
        public ActionResult Add()
        {
            var genres = _context.Genres.ToList();
            var newMovie = new MovieFormView
            {
                Movie = new Movie(),
                Genres = genres
            };
            return View("MovieFormView", newMovie);
        }

        /* Method to Save a Movie (A New or any already created) */
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = RoleName.CanManageMoviesRole)]
        public ActionResult Save(Movie Movie)
        {
            if (Movie.Id == 0)
            {
                Movie.DateAdded = DateTime.Now;
                _context.Movies.Add(Movie);
            }
            else
            {
                var movieInDb = _context.Movies.Single(m => m.Id == Movie.Id);
                movieInDb.Name = Movie.Name;
                movieInDb.ReleaseDate = Movie.ReleaseDate;
                movieInDb.GenreId = Movie.GenreId;
                movieInDb.NumberInStock = Movie.NumberInStock;
            }

            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }

        /* Method to Edit a Movie */
        [Authorize(Roles = RoleName.CanManageMoviesRole)]
        public ActionResult Edit(int id)
        {
            var searchedMovie = _context.Movies.Include(m => m.Genre).SingleOrDefault(m => m.Id == id);
            if (searchedMovie == null)
                return HttpNotFound();

            var movieToEdit = new MovieFormView
            {
                Movie = searchedMovie,
                Genres = _context.Genres.ToList()
            };

            return View("MovieFormView", movieToEdit);
        }

        /* Method to Delete a Movie */
        [Authorize(Roles = RoleName.CanManageMoviesRole)]
        public ActionResult Delete(int id)
        {
            var movie = _context.Movies.SingleOrDefault(m => m.Id == id);
            if (movie == null)
                return HttpNotFound();

            _context.Movies.Remove(movie);
            _context.SaveChanges();
            return RedirectToAction("Index", "Movies");
        }
    }
}