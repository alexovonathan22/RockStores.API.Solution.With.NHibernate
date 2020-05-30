using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DATA.Models;
using DATA.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RockStores.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepoContract<Product> _repoContract;

        public ProductController(IRepoContract<Product> repoContract)
        {
            _repoContract = repoContract;
        }
        // GET: api/Product
        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            return _repoContract.GetAll();

        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "GetOneProd")]
        public string GetOneProd(int id)
        {
            return "alex for value";
        }

        // POST: api/Product
        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            _repoContract.InsertOrUpdate(product);
            return Ok(product);


        }

        // PUT: api/Product/5
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
