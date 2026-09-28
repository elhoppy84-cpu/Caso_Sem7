using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caso_Sem7
{
    internal class Program
    {
        static int max = 100;
        static string[] nombres = new string[max];
        static double[] notas = new double[max];
        static int contador = 0;
        static public void Titulo ()
        {
            Console.WriteLine("***********************************");
            Console.WriteLine("SISTEMA DE NOTAS");
            Console.WriteLine("***********************************");
        }
        static public void Registrar_estudiante()
        {
            Console.WriteLine("Registro de estudiante nuevo: ");
            if (contador >= max)
            {
                Console.WriteLine("Llegamos a la capacidad máxima");
                return;
            }
            Console.Write("Ingresar nombres: ");
            string nombre = Console.ReadLine();
            double nota;
            while (true)
            {
                Console.Write("Ingresar nota: ");
                nota=double.Parse(Console.ReadLine());
                if (nota>0 && nota <= 20)
                {
                    break; 
                }
                Console.WriteLine("Nota inválida, debe estar entre 0 y 20");
            }
            nombres[contador] = nombre;
            notas[contador] = nota;
            contador ++;
        }
        static public void mostrar()
        {
            Console.WriteLine("**************Listado de Estudiantes**************");
            if (contador == 0)
            {
                Console.WriteLine("No hay datos por mostrar");
                return;
            }
            for (int i = 0; i < contador; i++)
            {
                Console.WriteLine((i + 1) + ".-" + nombres[i]+"-Nota:" + notas[i]);
            }
        }
        static void Main(string[] args)
        {
            Titulo();
            int opc = 0;
            while (opc != 3)
            {
                Console.WriteLine("********MENU PRINCIPAL********");
                Console.WriteLine("1.- Registrar estudiante");
                Console.WriteLine("2.- Buscar estudiantes");
                Console.WriteLine("3.- Modificar nota");
                Console.WriteLine("4.- Mostrar listado de estudiantes");
                Console.WriteLine("5.- Mostrar reporte ordenado por burbuja");
                Console.WriteLine("6.- Salir");
                Console.Write("Ingrese una opción: ");
                if (opc < 1 || opc > 6)
                {
                    Console.WriteLine("Opción inválida, por favor ingrese un número entre 1 y 6: ");
                }
                else
                {
                    switch (opc)
                    {
                        case 1:
                            Registrar_estudiante();
                            break;
                        case 2:
                            // Implementar búsqueda de estudiantes
                            break;
                        case 3:
                            // Implementar modificación de nota
                            break;
                        case 4:
                            mostrar();
                            break;
                        case 5:
                            // Implementar reporte ordenado por burbuja
                            break;
                        case 6:
                            Console.WriteLine("Gracias por usar el sistema.");
                            break;
                        default:
                            Console.WriteLine("Opción incorrecta...!!");
                            break;

                    }
                }
            }
        }
    }
}
