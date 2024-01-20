using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProfeTours.Server.Models;

namespace ProfeTours.Server.Controllers
{
    public class CredencialesUsuario
    {
        public string Correo { get; set; }
        public string Contrasena { get; set; }
    }


    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly SENAContext _sENAContext;
        public UsuariosController(SENAContext context)
        {
            _sENAContext = context;
        }
        [HttpGet]
        [Route("VerUsuario")]
        public async Task<IActionResult> VerUsuario()
        
        {
            List<Usuario> lista = await _sENAContext.Usuarios.ToListAsync();
            //List<Usuario> lista = await _sENAContext.Usuarios.Include(c => c.oTipodocumento).Include(c => c.oTiporole).ToListAsync();
            return StatusCode(StatusCodes.Status200OK, lista);
        }

        [HttpPost]
        [Route("IniciarSesion")]
        public IActionResult IniciarSesion([FromBody] CredencialesUsuario credenciales)

        {
            if (credenciales == null || string.IsNullOrEmpty(credenciales.Correo) || string.IsNullOrEmpty(credenciales.Contrasena))
            {
                return BadRequest("Las credenciales no pueden estar vacías");
            }

            var usuario = _sENAContext.Usuarios
                .SingleOrDefault(u => u.Correo == credenciales.Correo && u.Contrasena == credenciales.Contrasena);

            if (usuario == null)
            {
                return NotFound("Usuario no encontrado");
            }

            // Puedes devolver información adicional del usuario si es necesario
            var usuarioResponse = new
            {
                usuario.IdUsuario,
                usuario.Nombre,
                usuario.Apellido,
                usuario.Correo,
                // Otros campos que quieras devolver
            };

            return Ok(usuarioResponse);
        }
        [HttpPost]
        [Route("GuardarUsuario")]
        public async Task<IActionResult> GuardarUsuario([FromBody] Usuario nuevoUsuario)
        {
            try
            {
                if (nuevoUsuario == null)
                {
                    return BadRequest("El usuario proporcionado no puede ser nulo");
                }

                // Puedes realizar validaciones adicionales antes de guardar el usuario, si es necesario

                _sENAContext.Usuarios.Add(nuevoUsuario);
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
