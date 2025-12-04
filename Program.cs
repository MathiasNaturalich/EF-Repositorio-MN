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
    }
}
