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
            var categoria = _categoriaService.GetAll();

            if (categoria == null)
            {
                return NotFound("No hay categorias para mostrar");
            }
            return Ok(categoria);
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

        [HttpPost]
        public void Add([FromBody] Categoria categoria)
        {
            _categoriaService.Insert(categoria);
        }

        [HttpPut("")]
        public void Put([FromBody] Categoria categoria)
        {
            _categoriaService.Update(categoria);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _categoriaService.Remove(id);
        }

    }
}
