using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Caso_semana7
{
    internal class Program
    {
        static int max = 100;
        static string[] nombres = new string[max];
        static double[] notas = new double[max];
        static int contador = 0;

        static public void Titulo()
        {
            Console.WriteLine("**********************");
            Console.WriteLine("Sistema de notas");
            Console.WriteLine("**********************");
        }

        static public void Registrar_estudiante()
        {
            Console.WriteLine("Registro de estudiante: ");
            if (contador >= 100)
            {
                Console.WriteLine("Alcanzó la Capacidad Máxima");
                return;
            }

            Console.Write("Ingresar nombre: ");
            string nombre = Console.ReadLine();

            double nota;
            while (true)
            {
                Console.Write("Ingresar Nota [0-20]: ");
                if (double.TryParse(Console.ReadLine(), out nota) && nota >= 0 && nota <= 20)
                {
                    break;
                }
                Console.WriteLine("Error, Volver a ingresar la nota [0-20]");
            }

            nombres[contador] = nombre;
            notas[contador] = nota;
            contador++;
            Console.WriteLine("Estudiante registrado correctamente.");
        }

        static public void mostrar()
        {
            Console.WriteLine("******** Listado de estudiantes ********");
            if (contador == 0)
            {
                Console.WriteLine("No hay datos por mostrar");
                return;
            }

            for (int i = 0; i < contador; i++)
            {
                Console.WriteLine((i + 1) + ".- " + nombres[i] + " - Nota: " + notas[i]);
            }
        }

        static public void buscar_estudiante()
        {
            Console.WriteLine("********* BUSCAR ESTUDIANTE *************");
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados");
                return;
            }

            Console.Write("Ingresar nombre a buscar: ");
            string nom_buscar = Console.ReadLine().ToLower();
            bool encontrado = false;

            for (int i = 0; i < contador; i++)
            {
                if (nombres[i].ToLower() == nom_buscar)
                {
                    Console.WriteLine(nombres[i] + " tiene " + notas[i]);
                    encontrado = true;
                    break;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("Estudiante no encontrado");
            }
        }

        static public void modificar_estudiante()
        {
            Console.WriteLine("********************** MODIFICAR ESTUDIANTE ***********************");
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados");
                return;
            }

            Console.Write("Ingresar nombre del estudiante: ");
            string nombre_buscar = Console.ReadLine().ToLower();
            bool encontrado = false;

            for (int i = 0; i < contador; i++)
            {
                if (nombres[i].ToLower() == nombre_buscar)
                {
                    Console.WriteLine(nombres[i] + " tiene " + notas[i]);
                    double nueva_nota;

                    while (true)
                    {
                        Console.Write("Ingresar la nueva nota [0-20]: ");
                        if (double.TryParse(Console.ReadLine(), out nueva_nota) && nueva_nota >= 0 && nueva_nota <= 20)
                        {
                            notas[i] = nueva_nota;
                            Console.WriteLine("Nota modificada correctamente.");
                            encontrado = true;
                            break;
                        }
                        Console.WriteLine("Error, nota no válida [0-20]");
                    }
                    break;
                }
            }

            if (!encontrado)
            {
                Console.WriteLine("Estudiante no encontrado");
            }
        }

    
        static public void Burbuja()
        {
            double temp_notas;
            string temp_nombres;

            for (int i = 0; i < contador - 1; i++)
            {
                for (int j = 0; j < contador - i - 1; j++)
                {
                    if (notas[j] > notas[j + 1])
                    {
                        
                        temp_notas = notas[j];
                        notas[j] = notas[j + 1];
                        notas[j + 1] = temp_notas;

                        
                        temp_nombres = nombres[j];
                        nombres[j] = nombres[j + 1];
                        nombres[j + 1] = temp_nombres;
                    }
                }
            }

            Console.WriteLine("Lista ordenada por Burbuja (ascendente):");
            mostrar();
        }

        
        static public void SeleccionDescendente()
        {
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados");
                return;
            }

            for (int i = 0; i < contador - 1; i++)
            {
                int maxIndex = i; 

                for (int j = i + 1; j < contador; j++)
                {
                    if (notas[j] > notas[maxIndex])
                    {
                        maxIndex = j;
                    }
                }

                
                if (maxIndex != i)
                {
                    
                    double tempNota = notas[i];
                    notas[i] = notas[maxIndex];
                    notas[maxIndex] = tempNota;

                   
                    string tempNombre = nombres[i];
                    nombres[i] = nombres[maxIndex];
                    nombres[maxIndex] = tempNombre;
                }
            }

            Console.WriteLine("Lista ordenada por Selección (DESCENDENTE - de mayor a menor):");
            mostrar();
        }


        static public void PromedioYMaxima()
        {
            if (contador == 0)
            {
                Console.WriteLine("No hay estudiantes registrados");
                return;
            }

            double suma = 0;
            double maxima = notas[0];
            string estudianteMax = nombres[0];

            for (int i = 0; i < contador; i++)
            {
                suma += notas[i];

                if (notas[i] > maxima)
                {
                    maxima = notas[i];
                    estudianteMax = nombres[i];
                }
            }

            double promedio = suma / contador;

            Console.WriteLine("********** REPORTE **********");
            Console.WriteLine("Cantidad de estudiantes: " + contador);
            Console.WriteLine("Promedio general: " + promedio.ToString("F2"));
            Console.WriteLine("Nota máxima: " + maxima + " (Estudiante: " + estudianteMax + ")");
        }

        static void Main(string[] args)
        {
            Titulo();
            int opc = 0;

            while (opc != 8)   
            {
                Console.Clear();
                Console.WriteLine("************ Menu principal ************");
                Console.WriteLine("[1] Registrar estudiantes");
                Console.WriteLine("[2] Buscar estudiantes");
                Console.WriteLine("[3] Modificar nota");
                Console.WriteLine("[4] Mostrar lista sin ordenar");
                Console.WriteLine("[5] Mostrar reporte ordenado por burbuja");
                Console.WriteLine("[6] Mostrar por selección DESC");
                Console.WriteLine("[7] Promedio y nota máxima");
                Console.WriteLine("[8] Salir");
                Console.Write("Ingresar opción: ");

                if (!int.TryParse(Console.ReadLine(), out opc))
                {
                    Console.WriteLine("Error, ingresa un valor numérico");
                    Console.ReadKey();
                    continue;
                }

                switch (opc)
                {
                    case 1:
                        Registrar_estudiante();
                        break;
                    case 2:
                        buscar_estudiante();
                        break;
                    case 3:
                        modificar_estudiante();
                        break;
                    case 4:
                        mostrar();
                        break;
                    case 5:
                        Burbuja();
                        break;
                    case 6:
                        SeleccionDescendente();   
                        break;
                    case 7:
                        PromedioYMaxima();        
                        break;
                    case 8:
                        Console.WriteLine("Gracias por usar el sistema");
                        break;
                    default:
                        Console.WriteLine("Opción incorrecta..!");
                        break;
                }

                if (opc != 8)
                {
                    Console.WriteLine("\nPresione una tecla para continuar...");
                    Console.ReadKey();
                }
            }
        }
    }
}
