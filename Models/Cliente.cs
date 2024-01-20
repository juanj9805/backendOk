using ProfeTours.Server.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Cliente
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int IdCliente { get; set; }
    public int IdTipoDocumento { get; set; }
    public string NombreCompleto { get; set; }
    public string DireccionDomicilio { get; set; }
    public string NumeroTelefono { get; set; }
    public string CorreoElectronico { get; set; }

    public Tipodocumento Tipodocumento { get; set; }
}
