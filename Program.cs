using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Actividad_2
{
    class Program
    {
        static void Main(string[] args)
        {
            AppOperador miAppCli = new AppOperador();
            miAppCli.Iniciar();
            Console.WriteLine("Presione una tecla para salir");
            Console.ReadKey();
        }
    }
}
