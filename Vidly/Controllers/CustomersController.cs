using System;
using System.Collections.Generic;
using System.Data.Entity;   // Para la carga 'Eager' de MembershipType
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class CustomersController : Controller
    {
        private List<Customer> customers = new List<Customer>();
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: localhost:5000/Customers
        public ActionResult Index()
        {
            getCustomers();
            return View(this.customers);
        }

        /* Returns the list of Customers from DB */
        private void getCustomers()
        {
            this.customers = _context.Customers.Include(c => c.MembershipType).ToList();
        }


        // GET: localhost:5000/Customers/{id}
        public ActionResult Details(int id)
        {
            //var customer = customers.Find(x => x.Id == id);
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
    }
}