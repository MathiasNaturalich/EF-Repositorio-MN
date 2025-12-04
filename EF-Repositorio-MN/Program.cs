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

        static void InicializarCombos()
        {
            comboNombres = new string[] {
                "Combo 1: Café + Pan",
                "Combo 2: Jugo + Sándwich",
                "Combo 3: Té + Galletas",
                "Combo 4: Empanada + Bebida"
            };

            comboPrecios = new double[] { 3.50, 4.75, 3.00, 5.00 };
        }

        static void InicializarMatrices()
        {
            for (int i = 0; i < TURNOS; i++)
                for (int j = 0; j < MAX_RESERVAS_POR_TURNO; j++)
                {
                    nombreEstudiante[i, j] = null;
                    comboSeleccionado[i, j] = -1;
                }
        }

        static void MostrarMenuCombos()
        {
            Console.WriteLine("=== Menú de Combos ===");
            for (int i = 0; i < comboNombres.Length; i++)
                Console.WriteLine($"{i + 1}. {comboNombres[i]} - S/. {comboPrecios[i]:0.00}");
        }

        static void RegistrarReserva()
        {
            Console.Write("Nombre del estudiante: ");
            string nombre = Console.ReadLine();

            int turno = PedirTurno();
            if (ContarReservas(turno) >= MAX_RESERVAS_POR_TURNO)
            {
                Console.WriteLine("Turno lleno.");
                return;
            }

            MostrarMenuCombos();
            Console.Write("Seleccione combo: ");
            int combo = int.Parse(Console.ReadLine()) - 1;

            for (int j = 0; j < MAX_RESERVAS_POR_TURNO; j++)
                if (comboSeleccionado[turno, j] == -1)
                {
                    nombreEstudiante[turno, j] = nombre;
                    comboSeleccionado[turno, j] = combo;
                    Console.WriteLine("Reserva registrada correctamente.");
                    return;
                }
        }

        static void CancelarReserva()
        {
            Console.Write("Nombre del estudiante a cancelar: ");
            string nombre = Console.ReadLine();

            for (int i = 0; i < TURNOS; i++)
                for (int j = 0; j < MAX_RESERVAS_POR_TURNO; j++)
                    if (comboSeleccionado[i, j] != -1 && nombreEstudiante[i, j] == nombre)
                    {
                        comboSeleccionado[i, j] = -1;
                        nombreEstudiante[i, j] = null;
                        Console.WriteLine("Reserva cancelada.");
                        return;
                    }

            Console.WriteLine("Reserva no encontrada.");
        }

        static void ListarReservasMenu()
        {
            int turno = PedirTurno();
            Console.WriteLine(nombresTurno[turno]);

            for (int j = 0; j < MAX_RESERVAS_POR_TURNO; j++)
                if (comboSeleccionado[turno, j] != -1)
                    Console.WriteLine($"{nombreEstudiante[turno, j]} - {comboNombres[comboSeleccionado[turno, j]]}");
        }

        static void MostrarReportesIngresos()
        {
            for (int t = 0; t < TURNOS; t++)
            {
                double total = 0;
                for (int j = 0; j < MAX_RESERVAS_POR_TURNO; j++)
                    if (comboSeleccionado[t, j] != -1)
                        total += comboPrecios[comboSeleccionado[t, j]];

                Console.WriteLine($"{nombresTurno[t]}: S/. {total}");
            }
        }

        static void BuscarReservaPorNombre()
        {
            Console.Write("Nombre a buscar: ");
            string nombre = Console.ReadLine();

            for (int i = 0; i < TURNOS; i++)
                for (int j = 0; j < MAX_RESERVAS_POR_TURNO; j++)
                    if (comboSeleccionado[i, j] != -1 && nombreEstudiante[i, j] == nombre)
                        Console.WriteLine($"Encontrado en turno {nombresTurno[i]}");
        }

        static int PedirTurno()
        {
            Console.WriteLine("1. Mañana");
            Console.WriteLine("2. Tarde");
            return int.Parse(Console.ReadLine()) - 1;
        }

        static int ContarReservas(int t)
        {
            int cont = 0;
            for (int j = 0; j < MAX_RESERVAS_POR_TURNO; j++)
                if (comboSeleccionado[t, j] != -1)
                    cont++;
            return cont;
        }

        static void MostrarCapacidadPorTurno()
        {
            for (int i = 0; i < TURNOS; i++)
                Console.WriteLine($"{nombresTurno[i]}: {ContarReservas(i)}/20 reservas");
        }

        static void Pausa()
        {
            Console.WriteLine("\nPresione ENTER para continuar...");
            Console.ReadLine();
        }
    }
}

