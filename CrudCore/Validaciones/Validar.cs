using CrudCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudCore.Validaciones
{
    public class Validar
    {
        public bool comprobar(TbPersonajes tbPersonajes)
        {
            return fechaValida(tbPersonajes.FechaPersonaje) && edadValida(tbPersonajes.EdadPersonaje);
        }

        public bool fechaValida(DateTime fecha)
        {
            DateTime date0 = Convert.ToDateTime("1938-01-01");
            DateTime date1 = Convert.ToDateTime("1959-12-31");

            if (fecha >= date0 && fecha <= date1)
            {
                return true;
            } else
            {
                return false;
            }
        }

        public bool edadValida(int edad)
        {
            if (edad > 0 && edad <= 100)
            {
                return true;
            } else
            {
                return false;
            }
        }
    }
}
