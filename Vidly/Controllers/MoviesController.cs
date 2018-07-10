using System;
using System.Collections.Generic;
using System.Data.Entity;   // Para la carga 'Eager' de MembershipType
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

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
            return View(movies);
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


        // GET: Movies/Random
        //public ActionResult Random()
        //{
        //    var movie = new Movie() {Name = "Shrek"};
        //    return View(movie); // Returna la vista movie
        //return new ViewResult();
        //return Content("Hello World!"); // Texto plano
        //return new EmptyResult(); // Página en blanco
        // Redirección a 'Método/Controlador/Argumentos'
        //return RedirectToAction("Index", "Home", new {page = 1, sortBy = "name"});
        //}

        //public ActionResult Random()
        //{
        //    var movie = new Movie() { Name = "Batman Begins" };
        //    var customers = new List<Customer>
        //    {
        //        new Customer { Name = "Customer 1"},
        //        new Customer { Name = "Customer 2"}
        //    };

        //    var viewModel = new RandomMovieViewModel
        //    {
        //        Movie = movie,
        //        Customers = customers
        //    };
        //    return View(viewModel);
        //}

        //// localhost:65118/Movies/Edit?id=10
        //// localhost:65118/Movies/Edit/10
        //public ActionResult Edit(int id)
        //{
        //    return Content("id = " + id);
        //}

        //public ActionResult Index(int? pageIndex, string sortBy)
        //{
        //    if (!pageIndex.HasValue)
        //    {
        //        pageIndex = 1;
        //    }

        //    if (String.IsNullOrWhiteSpace(sortBy))
        //    {
        //        sortBy = "Name";
        //    }

        //    return Content(String.Format("pageIndex = {0} \n sortBy = {1}", pageIndex, sortBy));
        //}

        //[Route("movies/released/{year}/{month:regex(\\d{2}):range(1,12)}")]
        //public ActionResult ByReleaseDate(int year, int month)
        //{

        //    return Content(year + "/" + month);
        //}

    }
}