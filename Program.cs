using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CafeteriaReservas
{
    class Program
    {
        const int TURNOS = 2;
        const int MAX_RESERVAS_POR_TURNO = 20;

        static string[,] nombreEstudiante = new string[TURNOS, MAX_RESERVAS_POR_TURNO];
        static int[,] comboSeleccionado = new int[TURNOS, MAX_RESERVAS_POR_TURNO];

        static string[] comboNombres;
        static double[] comboPrecios;
        static string[] nombresTurno = { "Mañana", "Tarde" };

        static void Main(string[] args)
        {
            InicializarCombos();
            InicializarMatrices();

            bool salir = false;
            while (!salir)
            {
                Console.Clear(); // ✅ LIMPIA CADA VEZ QUE VUELVE AL MENÚ
                Console.WriteLine("Mathias Naturalich Ibarra");
                Console.WriteLine(DateTime.Now.AddHours(0));
                Console.WriteLine("=== Sistema de Reservas - Cafetería Universitaria ===");
                Console.WriteLine("1. Mostrar menú de combos");
                Console.WriteLine("2. Registrar reserva");
                Console.WriteLine("3. Cancelar reserva");
                Console.WriteLine("4. Listar reservas por turno");
                Console.WriteLine("5. Reportes de ingresos");
                Console.WriteLine("6. Buscar reserva por nombre del estudiante");
                Console.WriteLine("7. Mostrar capacidad por turno");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();
                Console.Clear(); // ✅ LIMPIA AL ENTRAR A CADA OPCIÓN

                switch (opcion)
                {
                    case "1":
                        Console.WriteLine("Mathias Naturalich Ibarra");
                        Console.WriteLine(DateTime.Now.AddHours(0));
                        MostrarMenuCombos();
                        break;

                    case "2":
                        Console.WriteLine("Mathias Naturalich Ibarra");
                        Console.WriteLine(DateTime.Now.AddHours(0));
                        RegistrarReserva();
                        break;

                    case "3":
                        Console.WriteLine("Mathias Naturalich Ibarra");
                        Console.WriteLine(DateTime.Now.AddHours(0));
                        CancelarReserva();
                        break;

                    case "4":
                        Console.WriteLine("Mathias Naturalich Ibarra");
                        Console.WriteLine(DateTime.Now.AddHours(0));
                        ListarReservasMenu();
                        break;

                    case "5":
                        Console.WriteLine("Mathias Naturalich Ibarra");
                        Console.WriteLine(DateTime.Now.AddHours(0));
                        MostrarReportesIngresos();
                        break;

                    case "6":
                        Console.WriteLine("Mathias Naturalich Ibarra");
                        Console.WriteLine(DateTime.Now.AddHours(0));
                        BuscarReservaPorNombre();
                        break;

                    case "7":
                        Console.WriteLine("Mathias Naturalich Ibarra");
                        Console.WriteLine(DateTime.Now.AddHours(0));
                        MostrarCapacidadPorTurno();
                        break;

                    case "0":
                        salir = true;
                        continue;

                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }

                Pausa(); // ✅ PAUSA
                Console.Clear(); // ✅ LIMPIA DESPUÉS DE CADA OPCIÓN
            }

            Console.WriteLine("Saliendo. ¡Hasta luego!");
        }
    }
}

