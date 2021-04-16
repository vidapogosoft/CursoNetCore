using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using Microsoft.AspNetCore.Authorization;
using TokenApi.Repositories;
using TokenApi.DTos;

namespace TokenApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {

        private readonly IRepositoryWrapper _repositories;

        public ProductosController(IRepositoryWrapper repositories)
        {
            _repositories = repositories;
        }

        // GET: api/<ProductosController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductsDto>>> GetProduct()
        {
            var products = await _repositories.Productos.GetAllProductsAsync();

            return Ok(products);

        }

        // GET api/<ProductosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
