using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using AuthenticationService.Managers;
using TaskApi.Security;
using ServiceLayer.ServiceCategoria;

namespace TaskApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;


        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        // GET: api/<ProductController>
        [HttpGet(nameof(GetAll))]
        public IActionResult GetAll()
        {
            try
            {
                var categoria = _categoriaService.GetAll();

                if (categoria == null)
                {
                    return NotFound("No hay categorias para mostrar");
                }
                return Ok(categoria);
            }
            catch (System.Exception)
            {

                throw;
            }

            
            //string token = "1234sdfg";
            //if (GetJWTContainerModel.ValidateToken(token)) {
            //    var categoria = _categoriaService.GetAll();

            //    if (categoria == null)
            //    {
            //        return NotFound("No hay categorias para mostrar");
            //    }
            //    return Ok(categoria);
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
                    return BadRequest("No se envio el Id de la categoria a obtener");
                }

                var categoria = _categoriaService.GetCategoria(id);

                if (categoria == null)
                {
                    return NotFound("No se encontraron registros para el Id de categoria consultado");
                }
                return Ok(categoria);

            }
            catch (System.Exception)
            {
                throw;
            }
            
        }

        [HttpPost]
        public void Add([FromBody] Categoria categoria)
        {
            try
            {
                _categoriaService.Insert(categoria);
            }
            catch (System.Exception)
            {

                throw;
            }
            
        }

        [HttpPut("")]
        public void Put([FromBody] Categoria categoria)
        {
            try
            {
                _categoriaService.Update(categoria);
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
                _categoriaService.Remove(id);
            }
            catch (System.Exception)
            {

                throw;
            }
            
        }

    }
}
