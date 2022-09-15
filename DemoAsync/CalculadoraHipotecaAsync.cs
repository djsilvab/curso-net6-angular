using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoAsync
{
    public static class CalculadoraHipotecaAsync
    {
        public static async Task<int> ObtenerAniosVidaLaboral()
        {
            Console.WriteLine("\nObteniendo años de vida laboral...");
            await Task.Delay(5000);//esperamos por 5 segundos
            return new Random().Next(1, 35);//devolvemos un valor random entre 1 y 35
        }

        public static async Task<bool> EsTipoContratoIndefinido()
        {
            Console.WriteLine("\nVerificando si el tipo de contrato es indefinido");
            await Task.Delay(5000);
            return (new Random().Next(1, 10)) % 2 == 0;
        }

        public static async Task<int> ObtenerSueldoNeto()
        {
            Console.WriteLine("\nObteniendo sueldo neto...");
            await Task.Delay(5000);
            return new Random().Next(800, 6000);
        }

        public static async Task<int> ObtenerGastosMensuales()
        {
            Console.WriteLine("\nObteniendo gastos mensuales del usuario ...");
            await Task.Delay(5000);
            return new Random().Next(200, 1000);
        }

        public static bool AnalizarInformacionParaConcederHipoteca(
            int aniosVidaLaboral,
            bool tipoContratoIndefinido,
            int sueldoNeto,
            int gastosMensuales,
            int cantidadSolicitado,
            int aniosPagar)
        {
            Console.WriteLine("\nAnalizando información para conceder hipoteca ...");

            if (aniosVidaLaboral < 2) return false;

            var cuota = (cantidadSolicitado / aniosPagar) / 12;

            if (cuota >= sueldoNeto || cuota > (sueldoNeto / 12)) return false;

            var porcentajeGastosSueldo = (gastosMensuales * 100) / sueldoNeto;

            if (porcentajeGastosSueldo > 30) return false;

            if ((cuota + gastosMensuales) >= sueldoNeto) return false;

            if (!tipoContratoIndefinido)
            {
                if ((cuota + gastosMensuales) > (sueldoNeto / 3)) return false;
                else return true;
            }

            return true;
        }

    }
}
