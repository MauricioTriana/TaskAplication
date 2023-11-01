using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using AuthenticationService.Managers;
using TaskApi.Security;
using ServiceLayer.ServiceTarea;

namespace TaskApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TareaController : ControllerBase
    {
        private readonly ITareaService _tareaService;

        public TareaController(ITareaService tareaService)
        {
            _tareaService = tareaService;
        }

        // GET: api/<ProductController>
        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            try
            {
                var tareas = _tareaService.GetAll();

                if (tareas == null)
                {
                    return NotFound("No hay tareas para mostrar");
                }
                return Ok(tareas);
            }
            catch (System.Exception)
            {

                throw;
            }
            

            //string token = "1234sdfg";
            //if (GetJWTContainerModel.ValidateToken(token)) {
            //    var tareas = _tareaService.GetAll();

            //    if (tareas == null)
            //    {
            //        return NotFound("No hay tareas para mostrar");
            //    }
            //    return Ok(tareas);
            //}
            //return Forbid();
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id = 0)
        {
            try
            {
                if (id.Equals(0))
                {
                    return BadRequest("No se envio el Id de la tarea a obtener");
                }

                var tarea = _tareaService.GetTarea(id);

                if (tarea == null)
                {
                    return NotFound("No se encontraron registros para el Id de tarea consultada");
                }
                return Ok(tarea);
            }
            catch (System.Exception)
            {

                throw;
            }
            
        }

        [HttpPost]
        public void Add([FromBody] Tarea tarea)
        {
            try
            {
                _tareaService.Insert(tarea);
            }
            catch (System.Exception)
            {

                throw;
            }
            
        }

        [HttpPut("")]
        public void Put([FromBody] Tarea tarea)
        {
            try
            {
                _tareaService.Update(tarea);
            }
            catch (System.Exception)
            {

                throw;
            }
            
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            try
            {
                _tareaService.Remove(id);
            }
            catch (System.Exception)
            {

                throw;
            }
            
        }

    }
}
