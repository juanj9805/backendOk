using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfeTours.Server.Models;

namespace ProfeTours.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaqueteController : ControllerBase
    {
        private readonly SENAContext _sENAContext;

        public PaqueteController(SENAContext context)
        {
            _sENAContext = context;
        }

        [HttpPost]
        [Route("GuardarPaquete")]
        public async Task<IActionResult> GuardarPaquete([FromBody] Paquete nuevoPaquete)
        {
            try
            {
                if (nuevoPaquete == null)
                {
                    return BadRequest("El paquete proporcionado no puede ser nulo");
                }

                // Puedes realizar validaciones adicionales antes de guardar el usuario, si es necesario

                _sENAContext.Paquetes.Add(nuevoPaquete);
                await _sENAContext.SaveChangesAsync();

                return StatusCode(StatusCodes.Status201Created, "Paquete creado exitosamente");
            }
            catch (Exception ex)
            {
                // Manejo de errores, puedes personalizar según tus necesidades
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al guardar el paquete: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("ObtenerPaquetes")]
        public IActionResult ObtenerPaquetes()
        {
            try
            {
                var paquetes = _sENAContext.Paquetes
                    .Select(p => new PaqueteViewModel
                    {
                        IdPaquete = p.IdPaquete,
                        NombrePaquete = p.NombrePaquete,
                        DescripcionPaquete = p.DescripcionPaquete,
                        PrecioPaquete = p.PrecioPaquete,
                        DestinoPaquete = p.DestinoPaquete,
                        FechaSalida = p.FechaSalida,
                        FechaRegreso = p.FechaRegreso
                    })
                    .ToList();

                return Ok(paquetes);
            }
            catch (Exception ex)
            {
                // Manejo de errores, puedes personalizar según tus necesidades
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener los paquetes: {ex.Message}");
            }
        }


    }
}
