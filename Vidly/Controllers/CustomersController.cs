using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private List<Customer> customers = new List<Customer>
        {
            new Customer() {Id = 1, Name = "Richard Grac"},
            new Customer() {Id = 2, Name = "Mauricio Romo"},
            new Customer() {Id = 3, Name = "Josue Gonzalez"},
            new Customer() {Id = 4, Name = "Daniel Pedroza"}

        };

        // GET: Customers
        public ActionResult Index()
        {
            return View(customers);
        }

        public ActionResult Details(int id)
        {
            var customer = customers.Find(x => x.Id == id);
            return View(customer);
        }
    }
}