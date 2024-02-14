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
                    .Select(p => new PaqueteViewModels
                    {
                        IdPaquete = p.IdPaquete,
                        ImagenPaquete = p.ImagenPaquete,
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

        [HttpDelete]
        [Route("EliminarPaquete/{id}")]
        public async Task<IActionResult> EliminarPaquete(int id)
        {
            try
            {
                // Buscar el cliente por su ID
                var paqueteEliminar = await _sENAContext.Paquetes.FindAsync(id);

                // Verificar si el cliente existe
                if (paqueteEliminar == null)
                {
                    return NotFound($"No se encontró un paquete con ID {id}");
                }

                // Eliminar el cliente
                _sENAContext.Paquetes.Remove(paqueteEliminar);
                await _sENAContext.SaveChangesAsync();

                return Ok($"Paquete con ID {id} eliminado exitosamente");
            }
            catch (Exception ex)
            {
                // Manejo de errores, puedes personalizar según tus necesidades
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al eliminar el paquete: {ex.Message}");
            }

        }

        [HttpPut]
        [Route("EditarPaquete/{id}")]
        public async Task<IActionResult> EditarPaquete(int id, [FromBody] PaqueteActualizarViewModel paqueteActualizadoViewModel)
        {
            try
            {
                var paqueteExistente = await _sENAContext.Paquetes.FindAsync(id);

                if (paqueteExistente == null)
                {
                    return NotFound($"No se encontró un paquete con ID {id}");
                }


                paqueteExistente.ImagenPaquete = paqueteActualizadoViewModel.ImagenPaquete;
                paqueteExistente.NombrePaquete = paqueteActualizadoViewModel.NombrePaquete;
                paqueteExistente.DescripcionPaquete = paqueteActualizadoViewModel.DescripcionPaquete;
                paqueteExistente.PrecioPaquete = paqueteActualizadoViewModel.PrecioPaquete;
                paqueteExistente.DestinoPaquete = paqueteActualizadoViewModel.DestinoPaquete;
                paqueteExistente.FechaSalida = paqueteActualizadoViewModel.FechaSalida;
                paqueteExistente.FechaRegreso = paqueteActualizadoViewModel.FechaRegreso;

                await _sENAContext.SaveChangesAsync();

                return Ok(paqueteExistente);
            }
            catch (Exception ex)
            {
                // Manejo de errores, puedes personalizar según tus necesidades
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al editar el paquete: {ex.Message}");
            }
        }
    }
}
