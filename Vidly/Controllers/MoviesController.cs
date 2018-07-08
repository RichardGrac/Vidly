using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;
using Vidly.Views.ViewModels;
using String = System.String;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        List<Movie> movies = new List<Movie>
        {
            new Movie() {Id = 1, Name = "Batman Begins"},
            new Movie() {Id = 2, Name = "Batman The Dark Knight"},
            new Movie() {Id = 3, Name = "Batman The Dark Knight Rises"}
        };

        public ActionResult Index()
        {
            return View(movies);
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