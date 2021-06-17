using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860


using BlazorWA1.Shared.Models;
using BlazorWA1.Server.DataAccess;

namespace BlazorWA1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistradosController : ControllerBase
    {
        // GET: api/<RegistradosController>
        RegistradoDataAccessLayer ObjReg = new RegistradoDataAccessLayer();

        // GET: RegistradosController

        [HttpGet]
        public IEnumerable<Registrados> Index()
        {
            return ObjReg.GetAllRegistrados();
        }

        // GET api/<RegistradosController>/5
        [HttpGet("{id}")]
        public Registrados Details(int id)
        {

            return ObjReg.GetRegData(id);
        }

        // POST api/<RegistradosController>
        [HttpPost]
        public void Create([FromBody] Registrados newitem)
        {
            if (ModelState.IsValid)
                ObjReg.AddRegister(newitem);
        }

        // PUT api/<RegistradosController>/5
        [HttpPut]
        public void Edit([FromBody] Registrados item)
        {
            if (ModelState.IsValid)
                ObjReg.EditRegister(item);
        }

        // DELETE api/<RegistradosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ObjReg.DeleteRegister(id);
        }
    }
}
