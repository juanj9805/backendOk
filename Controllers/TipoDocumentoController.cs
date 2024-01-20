﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProfeTours.Server.Models;

namespace ProfeTours.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoDocumentoController : ControllerBase
    {
        private readonly SENAContext _sENAContext;
        public TipoDocumentoController(SENAContext context)
        {
            _sENAContext = context;
        }
        [HttpPost]
        [Route("GuardarTipoDocumento")]
        public async Task<IActionResult> GuardarTipoDocumento([FromBody] Tipodocumento nuevoDocumento)
        {
            try
            {
                if (nuevoDocumento == null)
                {
                    return BadRequest("El tipo documento proporcionado no puede ser nulo");
                }

                // Puedes realizar validaciones adicionales antes de guardar el usuario, si es necesario

                _sENAContext.Tipodocumentos.Add(nuevoDocumento);
                await _sENAContext.SaveChangesAsync();

                return StatusCode(StatusCodes.Status201Created, "Usuario creado exitosamente");
            }
            catch (Exception ex)
            {
                // Manejo de errores, puedes personalizar según tus necesidades
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error al guardar el usuario: {ex.Message}");
            }
        }
    }
}
