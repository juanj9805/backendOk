namespace ProfeTours.Server.Models
{
    public class UsuarioViewModel
    {
        public int IdTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
    }
}
