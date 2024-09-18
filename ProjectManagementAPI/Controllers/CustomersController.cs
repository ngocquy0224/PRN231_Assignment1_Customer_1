using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessObjects;
using Repositories;
using DataAccess;

namespace ProjectManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerRepository _repo;
        public CustomersController(ICustomerRepository repo)
        {
            _repo = repo;
        }
        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        => _repo.GetCustomers();

        // POST api/<ProductsController>
        [HttpPost]
        public IActionResult Post(Customer customer)
        {

          var user =   _repo.GetById(customer.fullname);
            if (user != null)
            {
                return BadRequest("User existed");
            }
            var result = _repo.Save(customer);

            return Ok(result);
        }


        // PUT api/<ProductsController>/5
        [HttpPut("{username}")]
        public IActionResult Update(string username, Customer customer)
        {
            var pTmp = _repo.GetById(username);
            if (pTmp != null)
            {
                _repo.Update(customer);
            }
            else
            {
                return NotFound();
            }
            return NoContent();
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("Delete/{username}")]
        public IActionResult Delete(string username)
        {
            var p = _repo.GetById(username);
            if (p != null)
            {
                _repo.Delete(p);
            }
            else
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}