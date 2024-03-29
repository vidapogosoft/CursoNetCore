﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

using WebApiDemo1.Interfaces;
using WebApiDemo1.Models;

namespace WebApiDemo1.Controllers
{

    public enum ErrorCodeRegistrado
    {
        RegistroErrorConexionBase,
        TodoItemNameAndNotesRequired,
        TodoItemIDInUse,
        RecordNotFound,
        CouldNotCreateItem,
        CouldNotUpdateItem,
        CouldNotDeleteItem
    }


    [Route("api/[controller]")]
    [ApiController]
    public class RegistradosController : ControllerBase
    {
        private readonly IRegistrados _IRegistrados;
        public List<Registrado> ListRegistrado;

        public RegistradosController(IRegistrados IRegistrados)
        {
            _IRegistrados = IRegistrados;
        }


        // GET: api/<RegistradosController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_IRegistrados.ListRegistrados);
        }

        [HttpGet]
        [Route("Registrados2")]
        public IActionResult Get2()
        {
            return Ok(_IRegistrados.ListRegistrados);
        }

        [HttpGet]
        [Route("RegistradosEmpresa")]
        public IActionResult GetRegistradosEmpresa()
        {
            return Ok(_IRegistrados.ListDatosEmpresaRegistrados);
        }


        // GET api/<RegistradosController>/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        [HttpGet("{Identificacion}", Name = "Get")]
        public IActionResult GetRegistrado(string Identificacion)
        {
            return Ok(_IRegistrados.DatosDeRegistrado(Identificacion));
        }

        [HttpGet("{IdRegistrado}/{Identificacion}", Name = "GetRegistrado")]
        public IActionResult GetInforegistrado(int IdRegistrado, string Identificacion)
        {
            return Ok(_IRegistrados.DatosDeRegistrado2(IdRegistrado, Identificacion));
        }


        [HttpGet("RegistradoDatos/{IdRegistrado}/{Identificacion}", Name = "GetRegistradoDatos")]
        public IActionResult GetInforegistrado2(int IdRegistrado, string Identificacion)
        {
            return Ok(_IRegistrados.DatosDeRegistrado2(IdRegistrado, Identificacion));
        }

        // POST api/<RegistradosController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        [HttpPost]
        public IActionResult Post([FromBody] Registrado NewItem)
        {

            try
            {
                if(NewItem == null || !ModelState.IsValid)
                {

                    return BadRequest(ErrorCodeRegistrado.RegistroErrorConexionBase.ToString());

                }

                _IRegistrados.InsertRegistrado(NewItem);

            }
            catch (Exception)
            {

                return BadRequest(ErrorCodeRegistrado.RegistroErrorConexionBase.ToString());
            }

            return Ok(NewItem);

        }


        // PUT api/<RegistradosController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        [HttpPut]
        public IActionResult Put([FromBody] Registrado Item)
        {
            try
            {
                ListRegistrado = new List<Registrado>();

                if (Item == null || !ModelState.IsValid)
                {
                    return BadRequest(ErrorCodeRegistrado.CouldNotUpdateItem.ToString());
                }

                ListRegistrado = _IRegistrados.ItemExists(Item.IdRegistrado);

                if (ListRegistrado.Count == 0)
                {

                    return NotFound(ErrorCodeRegistrado.RecordNotFound.ToString());

                }

                _IRegistrados.UpdateRegistrado(Item);

            }
            catch (Exception)
            {

                return BadRequest(ErrorCodeRegistrado.RegistroErrorConexionBase.ToString());
            }

            return NoContent();
        }

        // DELETE api/<RegistradosController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        [HttpDelete("{IdRegistrado}")]
        public IActionResult Delete(int IdRegistrado)
        {
            try
            {
                ListRegistrado = new List<Registrado>();

                ListRegistrado = _IRegistrados.ItemExists(IdRegistrado);

                if (ListRegistrado.Count == 0)
                {

                    return NotFound(ErrorCodeRegistrado.RecordNotFound.ToString());

                }

                _IRegistrados.DeleteRegistrado(IdRegistrado);

            }
            catch (Exception)
            {

                return BadRequest(ErrorCodeRegistrado.RegistroErrorConexionBase.ToString());
            }

            return NoContent();
        }

    }
}
