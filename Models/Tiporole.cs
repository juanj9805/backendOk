using ProfeTours.Server.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProfeTours.Server.Models
{
    public partial class Tiporole
    {



        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int IdTipoRoles { get; set; }
        public string? TipoRoles { get; set; }

    }
}
