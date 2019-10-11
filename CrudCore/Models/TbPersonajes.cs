using System;
using System.Collections.Generic;

namespace CrudCore.Models
{
    public partial class TbPersonajes
    {
        public int IdPersonaje { get; set; }
        public string NombrePersonaje { get; set; }
        public DateTime FechaPersonaje { get; set; }
        public int EdadPersonaje { get; set; }
        public string EditorialPersonaje { get; set; }
    }
}
