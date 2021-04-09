using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.Net;

namespace ApiMiddleware.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DemoController : ControllerBase
    {
        [Produces("text/plain")]
        [HttpGet("demo1")]
        public async Task<IActionResult> Demo1()
        {
            try
            {
                var content = "Practica con Middlewares Metodo Get 1";

                return Ok(content);
            }
            catch
            {
                return BadRequest();
            }

        }

        [Produces("text/html")]
        [HttpGet("demo2")]
        public async Task<IActionResult> Demo2()
        {
            try
            {

                var content = "<b><i><u>Practica con Middlewares Metodo Get 2</u></i></b>";

                return new ContentResult
                {
                    Content = content,
                    ContentType = "text/html",
                    StatusCode = (int)HttpStatusCode.OK
                };

            }
            catch
            {
                return BadRequest();
            }
        }

    }
}
