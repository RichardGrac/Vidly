﻿using System;
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

        /* To use the DB */
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
            //getCustomers();
            return View();
        }

        /* Returns the list of Customers from DB */
        private void getCustomers()
        {
            this.customers = _context.Customers.Include(c => c.MembershipType).ToList();
        }


        // GET: localhost:5000/Customers/{id}
        public ActionResult Details(int id)
        {
            return View(id);
        }

        /* It returns a View with a new Customer Form */
        public ActionResult Add()
        {
            var membershipTypes = _context.MembershipTypes.ToList();
            var newCustomer = new CustomerFormView
            {
                Customer = new Customer(),
                MembershipTypes = membershipTypes
            };
            return View("CustomerForm", newCustomer);
        }

        /* To save the Customer into the DB */
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Customer customer)
        {
            // Validation of Inputs
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormView
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };

                return View("CustomerForm", viewModel);
            }

            if (customer.Id == 0)
            {
                // It's a new Customer
                _context.Customers.Add(customer);
            }
            else
            {
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);
                // This way .NET would take 'customer' fields and match them with customerInDb. Not secure:
                //TryUpdateModel(customerInDb, "", new string[] {"Name", "Email"}); 
                customerInDb.Name = customer.Name;
                customerInDb.DateOfBirth = customer.DateOfBirth;
                customerInDb.IsSubscribedToNewsletter = customer.IsSubscribedToNewsletter;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
            }

            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Edit(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            var editingCustomer = new CustomerFormView
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()

            };

            return View("CustomerForm", editingCustomer);

        }

        /* Method to Delete Customers */
        public ActionResult Delete(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return RedirectToAction("Index", "Customers");
        }
    }
}