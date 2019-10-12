using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CrudCore.Models
{
    public partial class TbPersonajes
    {
        public int IdPersonaje { get; set; }
        [Required]
        public string NombrePersonaje { get; set; }
        [Range(typeof(DateTime), "1938-01-01", "1959-12-31",
                    ErrorMessage = "La Fecha debe estar entre el 1 de enero de 1938 hasta el 31 de diciembre del 1951")]
        public DateTime FechaPersonaje { get; set; }
        [Range(1, 100)]
        public int EdadPersonaje { get; set; }
        public string EditorialPersonaje { get; set; }
    }
}
