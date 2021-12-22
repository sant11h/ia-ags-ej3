using System;
using System.Collections.Generic;

namespace IA.AGS.EJ1
{
    internal class Poblacion
    {
        private readonly List<string> individuos = new();
        private readonly Random random = new();

        public double Process(Ecuacion ecuacion, int tamañoIndividuo, int numIndividuos, int numCiclos)
        {
            // Crea la población con individuos generados al azar
            for (int cont = 1; cont <= numIndividuos; cont++)
            {
                individuos.Add(RandomBoolean(tamañoIndividuo));
            }

            // Proceso de algoritmo genético
            for (int ciclo = 1; ciclo <= numCiclos; ciclo++)
            {
                //Toma dos individuos al azar
                int indivA = random.Next(individuos.Count);
                int indivB = random.Next(individuos.Count);

                // Asegura que sean dos individuos distintos
                while (indivA == indivB)
                {
                    indivB = random.Next(individuos.Count);
                }

                // Evalúa la adaptación de los dos individuos
                double valorIndivA = ecuacion.ValorY(individuos[indivA]);
                double valorIndivB = ecuacion.ValorY(individuos[indivB]);

                // Si individuo A está mejor adaptado que B entonces: Elimina B + Duplica A + Modifica duplicado
                if (valorIndivA < valorIndivB)
                {
                    CopyAndMutate(indivB, indivA);
                }
                else
                { // Caso contrario: Elimina A + Duplica B + Modifica duplicado
                    CopyAndMutate(indivA, indivB);
                }
            }

            // Después del ciclo, busca el mejor individuo adaptado de la población
            int individuoMejor = 0;
            double MenorValorY = double.MaxValue;

            for (int cont = 0; cont < individuos.Count; cont++)
            {
                double valorIndiv = ecuacion.ValorY(individuos[cont]);
                if (valorIndiv < MenorValorY)
                {
                    individuoMejor = cont;
                    MenorValorY = valorIndiv;
                }
            }

            return ecuacion.ValorX(individuos[individuoMejor]);
        }

        // Genera un individuo booleano al azar
        private string RandomBoolean(int size)
        {
            string numero = string.Empty;

            for (int i = 1; i <= size; i++)
            {
                if (random.NextDouble() < 0.5)
                    numero += "1";
                else
                    numero += "0";
            }
            return numero;
        }

        // Copia el ganador sobre el perdedor y modifica la copia
        private void CopyAndMutate(int indPerdedor, int indGanador)
        {
            //Copia el inviduo ganador sobre el perdedor
            individuos[indPerdedor] = individuos[indGanador];

            //Muta la copia
            char[] numeros = individuos[indPerdedor].ToCharArray();
            int pos = random.Next(individuos[indPerdedor].Length);

            if (numeros[pos] == '0') numeros[pos] = '1';
            else numeros[pos] = '0';

            individuos[indPerdedor] = new string(numeros);
        }
    }
}