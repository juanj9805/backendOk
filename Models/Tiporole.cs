using ProfeTours.Server.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProfeTours.Server.Models
{
    public partial class Tiporole
    {
        public Tiporole()
        {
            Usuarios = new HashSet<Usuario>();
        }


        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int IdTipoRoles { get; set; }
        public string? TipoRoles { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
