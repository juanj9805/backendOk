using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProfeTours.Server.Models;

namespace ProfeTours.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoRoleController : ControllerBase
    {
        private readonly SENAContext _sENAContext;
        public TipoRoleController(SENAContext context)
        {
            _sENAContext = context;
        }
        [HttpPost]
        [Route("GuardarTipoRole")]
        public async Task<IActionResult> GuardarTipoRole([FromBody] Tiporole nuevoRole)
        {
            try
            {
                if (nuevoRole == null)
                {
                    return BadRequest("El tipo documento proporcionado no puede ser nulo");
                }

                // Puedes realizar validaciones adicionales antes de guardar el usuario, si es necesario

                _sENAContext.Tiporoles.Add(nuevoRole);
                await _sENAContext.SaveChangesAsync();

                return StatusCode(StatusCodes.Status201Created, "role creado exitosamente");
            }
            catch (Exception ex)
            {
                // Manejo de errores, puedes personalizar según tus necesidades
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al guardar el role: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("ObtenerRoles")]
        public IActionResult ObtenerRoles()
        {
            try
            {
                var tipoRoless = _sENAContext.Tiporoles.ToList();
                return Ok(tipoRoless);
            }
            catch (Exception ex)
            {
                // Manejo de errores, puedes personalizar según tus necesidades
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener los tipos de documentos: {ex.Message}");
            }
        }
    }
}
