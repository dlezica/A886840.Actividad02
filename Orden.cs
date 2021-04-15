using System;
using System.Collections.Generic;
using System.Text;

namespace Actividad_2
{
    class Orden
    {
        public string Descrip { get; private set; }
        public string ID { get; set; }
        public Operador Operador { get; set; }


        public Orden(string laDesc, string elIDOR)
        {
            Descrip = laDesc;
            ID = elIDOR;

        }

        public void AsignarOp(Operador OP)
        {
            this.Operador = OP;

        }
    }
}
