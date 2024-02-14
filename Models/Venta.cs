using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProfeTours.Server.Models
{
    public class Venta
    {
        
    [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdVenta { get; set; }

        [ForeignKey("Cliente")]
        public int IdCliente { get; set; }

        [ForeignKey("Paquete")]
        public int IdPaquete { get; set; }

        public DateTime FechaCompra { get; set; }

        // Puedes agregar más atributos relacionados con la venta, como el monto total, estado de la compra, etc.

        // Propiedades de navegación
        public Cliente Cliente { get; set; }
        public Paquete Paquete { get; set; }
   
}
}
