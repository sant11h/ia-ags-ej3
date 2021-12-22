using System;

namespace IA.AGS.EJ1
{
    internal class Ecuacion
    {
        private double minRange, maxRange;
        public Func<double, double> function;

        public Ecuacion(Func<double, double> function, double min, double max)
        {
            this.function = function;
            this.minRange = min;
            this.maxRange = max;
        }

        // El individuo en binario se convierte a real y
        // retorna el valor que genera la ecuación
        public double ValorY(string individuo)
        {
            double x = ValorX(individuo);
            
            double y = function.Invoke(x);

            return y;
        }

        // Convierte la representación binaria en dato tipo real
        public double ValorX(string individuo)
        {
            double multiplica = (maxRange - minRange);
            multiplica /= (Math.Pow(2, individuo.Length) - 1);
            int numero = Convert.ToInt32(individuo, 2);
            return minRange + numero * multiplica;
        }
    }
}
