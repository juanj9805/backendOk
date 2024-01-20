using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfeTours.Server.Models;

namespace ProfeTours.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly SENAContext _sENAContext;
        public ClienteController(SENAContext context)
        {
            _sENAContext = context ;
        }
        [HttpGet]
        [Route("ObtenerClientes")]
        public IActionResult ObtenerClientes()
        {
            try
            {
                var clientes = _sENAContext.Clientes.ToList();
                return Ok(clientes);
            }
            catch (Exception ex)
            {
                // Manejo de errores, puedes personalizar según tus necesidades
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener los  clientes de: {ex.Message}");
            }
        }
        [HttpPost]
        [Route("GuardarCliente")]
        public async Task<IActionResult> GuardarCliente([FromBody] NuevoClienteViewModel nuevoClienteViewModel)
        {
            try
            {
                if (nuevoClienteViewModel == null)
                {
                    return BadRequest("Los datos del cliente proporcionados no pueden ser nulos");
                }

                // Puedes realizar validaciones adicionales antes de guardar el cliente, si es necesario

                // Mapea el ViewModel a la entidad Cliente
                var nuevoCliente = new Cliente
                {
                    IdTipoDocumento = nuevoClienteViewModel.IdTipoDocumento,
                    NombreCompleto = nuevoClienteViewModel.NombreCompleto,
                    DireccionDomicilio = nuevoClienteViewModel.DireccionDomicilio,
                    NumeroTelefono = nuevoClienteViewModel.NumeroTelefono,
                    CorreoElectronico = nuevoClienteViewModel.CorreoElectronico
                };

                _sENAContext.Clientes.Add(nuevoCliente);
                await _sENAContext.SaveChangesAsync();

                return StatusCode(StatusCodes.Status201Created, "Cliente creado exitosamente");
            }
            catch (DbUpdateException ex)
            {
                // Manejo de errores de base de datos, por ejemplo, violación de clave única
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al guardar el cliente: {ex.Message}");
            }
            catch (Exception ex)
            {
                // Manejo de otros errores, puedes personalizar según tus necesidades
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al guardar el cliente: {ex.Message}");
            }
        }

    }


}
