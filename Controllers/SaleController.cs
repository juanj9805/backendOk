using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfeTours.Server.Models;
using ProfeTours.Server.Models.ViewModels;

namespace ProfeTours.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : Controller
    {
        private readonly SENAContext _sENAContext;
        public SaleController(SENAContext context)
        {
            _sENAContext = context;
        }
        [HttpGet]
        [Route("ObtenerVentas")]
        public IActionResult ObtenerVentas()
        {
            try
            {
                var ventas = _sENAContext.Ventas.ToList();
                return Ok(ventas);
            }
            catch (Exception ex)
            {
                // Manejo de errores, puedes personalizar según tus necesidades
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al obtener las  ventas de: {ex.Message}");
            }
        }


        [HttpPost]
        [Route("GuardarVenta")]
        public IActionResult GuardarVenta([FromBody] VentaViewModel ventaViewModel)
        {
            try
            {
                var venta = new Venta
                {
                    IdCliente = ventaViewModel.IdCliente,
                    IdPaquete = ventaViewModel.IdPaquete,
                    FechaCompra = ventaViewModel.FechaCompra,
                    Estado = ventaViewModel.Estado
                    // Puedes asignar más propiedades según sea necesario
                };

                _sENAContext.Ventas.Add(venta);
                _sENAContext.SaveChanges();

                return Ok("Venta guardada exitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al guardar la venta: {ex.Message}");
            }
        }



        [HttpPut]
        [Route("EditarVenta/{id}")]
        public IActionResult EditarVenta(int id, [FromBody] VentaViewModel ventaViewModel)
        {
            try
            {
                var ventaExistente = _sENAContext.Ventas.Find(id);

                if (ventaExistente == null)
                {
                    return NotFound($"No se encontró la venta con ID: {id}");
                }

                // Actualiza las propiedades necesarias
                ventaExistente.IdCliente = ventaViewModel.IdCliente;
                ventaExistente.IdPaquete = ventaViewModel.IdPaquete;
                ventaExistente.FechaCompra = ventaViewModel.FechaCompra;
                ventaExistente.Estado = ventaViewModel.Estado;

                // Puedes asignar más propiedades según sea necesario

                _sENAContext.Entry(ventaExistente).State = EntityState.Modified;
                _sENAContext.SaveChanges();

                return Ok($"Venta con ID {id} editada exitosamente");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al editar la venta: {ex.Message}");
            }
        }







    }
}