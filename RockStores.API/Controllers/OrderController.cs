using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DATA;
using DATA.Repository;
using DATA.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NHibernate.Criterion;


namespace RockStores.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IRepoContract<Orders> _repoContract;
        
        public OrderController(IRepoContract<Orders> repoContract)
        {
            _repoContract = repoContract;
        }
        // GET: api/Order
        [HttpGet]
        public IEnumerable<Orders> Get()
        {
            var orders = _repoContract.GetAll();
            return orders;
        }

        // GET: api/Order/5
        [HttpGet("{id}", Name = "GetOneOrder")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Order
        [HttpPost]
        public ActionResult Post([FromBody] Orders order)
        {
            if (!TryValidateModel(order)) return BadRequest();
            _repoContract.InsertOrUpdate(order);
            return Ok(order);

        }

        // PUT: api/Order/5
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
