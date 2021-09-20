using System;
using System.Collections.Generic;

#nullable disable

namespace Project1.Models
{
    public partial class Player
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int Dni { get; set; }
        public int? TeamId { get; set; }
    }
}
