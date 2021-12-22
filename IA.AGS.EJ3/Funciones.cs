using System;

namespace IA.AGS.EJ1
{
    internal static class Funciones
    {
        public static double Sphere(double x)
        {
            double sum = 0;

            for (int i = 1; i < 2; i++)
            {
                sum += Math.Pow(x, 2);
            }

            return sum;
        }

        public static double Schwefel(double x)
        {
            double sum = 0;
            double V = 4189.829101;

            for (int i = 1; i < 10; i++)
            {
                sum += -x * Math.Sin(Math.Sqrt(Math.Abs(x)));
            }

            return 10 * V * sum;
        }

        public static double Griewank(double x)
        {
            double sum = 0;
            double productSeq = 1;

            for (int i = 1; i < 10; i++)
            {
                sum += Math.Pow(x, 2) / 4000;
                productSeq *= Math.Cos(x / Math.Sqrt(i));
            }

            return 1 + sum - productSeq;
        }
    }
}
