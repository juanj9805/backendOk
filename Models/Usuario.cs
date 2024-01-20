using System;
using System.Collections.Generic;

namespace ProfeTours.Server.Models
{
    public partial class Usuario
    {
        public int IdUsuario { get; set; }
        public int? IdTipoDocumento { get; set; }
        public string? NumeroDocumento { get; set; }
        public string? Nombres { get; set; }
        public string? Apellidos { get; set; }
        public string? Correo { get; set; }
        public string? Contrasena { get; set; }
        public int? IdTipoRoles { get; set; }

        public virtual Tipodocumento? oTipodocumento { get; set; }
        public virtual Tiporole? oTiporole { get; set; }
    }
}
