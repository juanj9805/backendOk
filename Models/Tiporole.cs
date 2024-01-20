using System;
using System.Collections.Generic;

namespace ProfeTours.Server.Models
{
    public partial class Tiporole
    {
        public Tiporole()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public int IdTipoRoles { get; set; }
        public string? TipoRoles { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
