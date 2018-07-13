using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.DTOS;
using Vidly.Models;

namespace Vidly.Controllers.API
{
    public class CustomersController : ApiController
    {
        private ApplicationDbContext _context;

        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        // GET: /api/customers
        [HttpGet]
        public IEnumerable<CustomerDTO> GetCustomers()
        {
            return _context.Customers.ToList().Select(Mapper.Map<Customer, CustomerDTO>);
        }

        [HttpGet]
        public CustomerDTO GetCustomer(int id)
        {
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            return Mapper.Map<Customer, CustomerDTO>(customer);
        }

        [HttpPost]
        public CustomerDTO PostCustomer(CustomerDTO customerDto)
        {
            if(!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customer = Mapper.Map<CustomerDTO, Customer>(customerDto);
            _context.Customers.Add(customer);
            _context.SaveChanges();

            customerDto.Id = customer.Id;

            // Return with Id already set
            return customerDto;
        }

        [HttpPut]
        public CustomerDTO PutCustomer(int id, CustomerDTO customerDto)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            var customerInDb = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customerInDb == null)
                throw new HttpResponseException(HttpStatusCode.NotFound);

            // Mapper.Map<FroWhat, ToWhat>(SinceWho, ToWho)
            Mapper.Map<CustomerDTO, Customer>(customerDto, customerInDb);

            _context.SaveChanges();
            return customerDto;
        }

        [HttpDelete]
        public HttpResponseMessage DeleteCustomer(int id)
        {
            //HttpResponseMessage response;
            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return Request.CreateResponse
                    (HttpStatusCode.BadRequest, "Customer was not finded");

            _context.Customers.Remove(customer);
            _context.SaveChanges();

            return Request.CreateResponse
                (HttpStatusCode.OK, "Customer removed successfully");
        }
    }
}
