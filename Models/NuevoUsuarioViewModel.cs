﻿namespace ProfeTours.Server.Models
{
    public class NuevoUsuarioViewModel
    {
        public int IdTipoDocumento { get; set; }
        public string NumeroDocumento { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
    }

}
