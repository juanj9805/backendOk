namespace ProfeTours.Server.Models
{
    public class NuevoClienteViewModel
    {
        public int IdTipoDocumento { get; set; }
        public string NombreCompleto { get; set; }
        public string DireccionDomicilio { get; set; }
        public string NumeroTelefono { get; set; }
        public string CorreoElectronico { get; set; }
    }
}