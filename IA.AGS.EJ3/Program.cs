using System;

namespace IA.AGS.EJ1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Ecuacion sphereEcuacion = new(Funciones.Sphere, -5,5);
            Ecuacion schwefelEcuacion = new(Funciones.Schwefel, -500, 500);
            Ecuacion griewankEcuacion = new(Funciones.Griewank, -600, 600);
            int tamañoIndividuo = 30;
            int cantIndividuos = 50;
            int ciclos = 1000000;

            Poblacion objPoblacion = new();
            var bestSphereIndividuo = objPoblacion.Process(sphereEcuacion, tamañoIndividuo, cantIndividuos, ciclos);
            var bestSchwefelIndividuo = objPoblacion.Process(schwefelEcuacion, tamañoIndividuo, cantIndividuos, ciclos);
            var bestGriewankIndividuo = objPoblacion.Process(griewankEcuacion, tamañoIndividuo, cantIndividuos, ciclos);

            Console.WriteLine($"Mínimo global para la función Sphere: {Math.Round(bestSphereIndividuo, 5)}");
            Console.WriteLine($"Mínimo global para la función Schwefel: {Math.Round(bestSchwefelIndividuo, 5)}");
            Console.WriteLine($"Mínimo global para la función Griewank: {Math.Round(bestGriewankIndividuo, 5)}");
            Console.ReadKey();
        }
    }
}
