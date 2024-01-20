﻿namespace ProfeTours.Server.Models
{
    public class PaqueteViewModel
    {
        public int IdPaquete { get; set; }
        public string NombrePaquete { get; set; }
        public string DescripcionPaquete { get; set; }
        public decimal PrecioPaquete { get; set; }
        public string DestinoPaquete { get; set; }
        public DateTime FechaSalida { get; set; }
        public DateTime FechaRegreso { get; set; }
    }



}