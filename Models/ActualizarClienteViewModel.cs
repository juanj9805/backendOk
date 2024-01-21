namespace ProfeTours.Server.Models
{
    public class ActualizarClienteViewModel
    {
        public int Id { get; set; }
        public int IdTipoDocumento { get; set; }
        public string NombreCompleto { get; set; }
        public string DireccionDomicilio { get; set; }
        public string NumeroTelefono { get; set; }
        public string CorreoElectronico { get; set; }
    }
}