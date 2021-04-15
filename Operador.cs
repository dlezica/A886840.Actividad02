using System;
using System.Collections.Generic;
using System.Text;

namespace Actividad_2
{
    class Operador
    {
        public string Nombre { get; set; }
        public string ID { get; set; }

        
        public Operador(string elNombre, string elID)
        {
            Nombre = elNombre;
            ID = elID;
           
        }
    }
}
