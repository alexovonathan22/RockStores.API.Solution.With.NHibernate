using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DATA.Models;
using DATA.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ISession = NHibernate.ISession;

namespace RockStores.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IRepoContract<Customer> _repoContract;

        public CustomerController(IRepoContract<Customer> repoContract)
        {
            _repoContract = repoContract;
        }
        // GET: api/Customer
        [HttpGet]
        public IEnumerable<Customer> GetCustomers()
        {
           return _repoContract.GetAll();

        }

        // GET: api/Customer/5
        [HttpGet("{id}", Name = "GetOneCst")]
        public ActionResult GetCst(int id)
        {
            var cst = _repoContract.GetOne(typeof(Customer), id);
            return Ok(cst);
        }

        // POST: api/Customer
        [HttpPost]
        public ActionResult<Customer> Post([FromBody] Customer cst)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            //var s = cst.Orders.ToList().;

            _repoContract.InsertOrUpdate(cst);
            return Ok(cst);


        }

        // PUT: api/Customer/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
