using System;
using System.Collections.Generic;
using System.Text;

namespace Actividad_2
{
    class AppOperador
    {
        public void Iniciar()
        {
            const string opcionIngOP = "A";
            const string opcionIngOR = "B";
            const string opcionConsOP = "C";
            const string opcionConsOR = "D";
            const string asignarOPCION = "E";
            const string OrdenesSinasig = "F";
            const string opcionSal = "G";

            String opcionMenu = "";

            String nombreIngresar = "";
            String idIngresar = "";
            List<Operador> operadores = new List<Operador>();
            String nombreIDOP = "";
            Operador operadorEnc;

            String nombreIngresarOR = "";
            String idIngresarOR = "";
            List<Orden> ordenes = new List<Orden>();
            String DescIDOR = "";
            Orden ordenEnc;


            do
            {
                opcionMenu = ServValidac.PedirStrNoVac("Ingrese una opción:\n"
                        + opcionIngOP + "- Ingresar Operario\n"
                        + opcionIngOR + "- Ingresar Orden de trabajo\n"
                        + opcionConsOP + "-Consulta Operador\n"
                          + opcionConsOR + "-Consulta Ordenes\n"
                          + asignarOPCION + "-Asignar ODT\n"
                          + OrdenesSinasig + "-Consulta Ordenes sin Asignación\n"
                        + opcionSal + "-Salir"
                        );

                switch (opcionMenu)
                {
                    case opcionIngOP:
                        nombreIngresar = ServValidac.PedirStrNoVac("Ingrese el ID del Operario");
                        idIngresar = ServValidac.PedirStrNoVac("Ingrese el nombre Operario");



                        operadores.Add(new Operador(nombreIngresar, idIngresar));
                        break;

                    case opcionIngOR:
                        idIngresarOR  = ServValidac.PedirStrNoVac("Ingrese ID de la Orden de trabajo");
                        nombreIngresarOR = ServValidac.PedirStrNoVac("Ingrese la descripcion de la orden de trabajo");


                        ordenes.Add(new Orden(nombreIngresarOR, idIngresarOR));
                        break;

                    case opcionConsOP:

                        nombreIDOP = ServValidac.PedirStrNoVac("Ingrese el ID del Operario para buscar");

                        operadorEnc = null;

                        operadorEnc = GetOperador(operadores, nombreIDOP);

                        if (operadorEnc == null)
                        {
                            Console.WriteLine("No se registra operador con el ID ingresado");
                        }
                        else
                        {
                            Console.WriteLine("ID: " + operadorEnc.ID);
                            Console.WriteLine("Nombre: " + operadorEnc.Nombre);
                           

                        }
                        break;

                    case opcionConsOR:

                        DescIDOR = ServValidac.PedirStrNoVac("Ingrese el ID de la Orden");

                        ordenEnc = null;

                        ordenEnc = GetOrden(ordenes, DescIDOR);

                        if (ordenEnc == null)
                        {
                            Console.WriteLine("No se registra la orden de trabajo");
                        }
                        else
                        {
                            Console.WriteLine("ID: " + ordenEnc.ID);
                            Console.WriteLine("Descripción: " + ordenEnc.Descrip);
                           

                        }
                        break;


                    case asignarOPCION:

                        nombreIDOP = ServValidac.PedirStrNoVac("Ingrese el ID del Operario para buscar");

                        operadorEnc = null;

                        operadorEnc = GetOperador(operadores, nombreIDOP);

                        if (operadorEnc == null)
                        {
                            Console.WriteLine("No se registra cliente con el nombre ingresado");
                        }
                        else
                        {
                            Orden or = ordenes.Find(
                                        delegate (Orden ord)
                                        {
                                            return ord.Operador == null;
                                        });
                            if (or != null)
                            {


                                or.AsignarOp(operadorEnc);

                                Console.WriteLine("se asigno orden: " + or.Descrip + " al operador: " + or.Operador.Nombre);
                            }
                            else
                                Console.WriteLine("no hay ordenes sin asignar");
                            
                        }
                         break;

                    case OrdenesSinasig:
                        foreach (Orden or in ordenes)
                        {
                            int cant = 0;
                            if (or.Operador == null)
                               cant++;
                              Console.WriteLine("La cantidad de no asignados es " + cant++);
                        }
                        break;

                    case opcionSal:
                        break;
                    default:
                        Console.WriteLine("Opción no válida");
                        break;
                }
            } while (opcionMenu != opcionSal);

        }

        public Operador GetOperador(List<Operador> losOperadores, string nombreOperador)
        {
            //Ejemplo buscador por método find
            return losOperadores.Find
                (
                    delegate (Operador cli)
                    {
                        return cli.Nombre == nombreOperador;
                    }
                );
        }
        public Orden GetOrden(List<Orden> lasOrdenes, string DescripOrden)
        {
            //Ejemplo buscador por método find
            return lasOrdenes.Find
                (
                    delegate (Orden ord)
                    {
                        return ord.Descrip == DescripOrden;
                    }
                );
        }
    }
}
