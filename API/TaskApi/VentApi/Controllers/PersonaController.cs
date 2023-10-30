using DomainLayer.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.ServicePersona;
using AuthenticationService.Models;
using System.Security.Claims;
using AuthenticationService.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using TaskApi.Security;

namespace TaskApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonaController : ControllerBase
    {
        private readonly IPersonaService _personaService;



        public PersonaController(IPersonaService personaService)
        {
            _personaService = personaService;
        }

        // GET: api/<ProductController>
        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            var personas = _personaService.GetAll();

            if (personas == null)
            {
                return NotFound("No hay Personas para mostrar");
            }
            return Ok(personas);

            //string token = "1234asdf";

            //if (GetJWTContainerModel.ValidateToken(token)) {
            //    var personas = _personaService.GetAll();

            //    if (personas == null)
            //    {
            //        return NotFound("No hay Personas para mostrar");
            //    }
            //    return Ok(personas);
            //}
            //return Forbid();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id = 0)
        {
            if (id.Equals(0))
            {
                return BadRequest("No se envio el Id del Persona a obtener");
            }

            var persona = _personaService.GetPersona(id);

            if (persona == null)
            {
                return NotFound("No se encontro valores pa ra el Id de Persona consultado");
            }
            return Ok(persona);
        }

        [HttpGet("identificacion/{id}")]
        public ActionResult GetByIdentification(string id)
        {
            if (id.Equals(0))
            {
                return BadRequest("No se envio el Id del Persona a obtener");
            }

            var persona = _personaService.GetPersonaByIdentificacion(id);

            if (persona == null)
            {
                return NotFound("No se encontro valores pa ra el Id de Persona consultado");
            }
            return Ok(persona);
        }

        [HttpGet("identificacion/{id}/pass/{password}")]
        public ActionResult Login(string id, string password)
        {
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(password))
            {
                return BadRequest("No se envio completa la informacion de login");
            }

            bool exits = _personaService.Login(id, password);

            return Ok(exits);
        }


        [HttpPost]
        public void Add([FromBody] Persona Persona)
        {
            _personaService.Insert(Persona);
        }

        // PUT api/<ProductController>/5
        [HttpPut("")]
        public void Put([FromBody] Persona Persona)
        {
            _personaService.Update(Persona);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _personaService.Remove(id);
        }

    }
}
