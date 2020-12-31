using System;
using System.Collections.Generic;
using System.Text;


namespace FFTlib
{
    /// <summary>
    /// Fenetres pour DFT ou FFT
    /// </summary>
    public class Fenetre
    {
        
        /// <summary>
        /// Valeur de pi pi = 3.14116...........  
        /// </summary>
        public static double PI = Math.PI;

        /// <summary>
        /// Fenetre de Hamming :  0.54 - 0.46*cos(2.pi.t/T)  
        /// </summary>
        /// <param name="nbechant"> nombre de points de la fenetre  </param>
        /// <returns> Xs[] : tableau des valeurs (type : double) de la fenetre de Hamming </returns>
        public static double[] Hamming (int nbechant)
        {
            double[] Xs = new double[nbechant];
            double a = 0.0;
            for (int i = 0; i < nbechant; i++)
            {
                a = (2.0 * PI * (Double)i) / (double)(nbechant - 1);
                Xs[i] = 0.54 - (0.64 * Math.Cos(a));
            }
            return Xs; 
        }

        /// <summary>
        /// Fenetre de Hamming :  0.54 - 0.46*cos(2.pi.t/T)  
        /// </summary>
        /// <param name="nbechant"> nombre de points de la fenetre  </param>
        /// <returns> Xs[]  : tableau des valeurs (type : decimal) de la fenetre de Hamming </returns>
        public static decimal[] HammingD(int nbechant)
        {
            decimal[] Xs = new decimal[nbechant];
            double a = 0.0;
            for (int i = 0; i < nbechant; i++)
            {
                a = (2.0 * PI * (Double)i) / (double)(nbechant - 1);
                Xs[i] = (decimal)(0.54 - (0.64 * Math.Cos(a)));
            }
            return Xs;
        }

        /// <summary>
        /// Fenetre de Hanning :  0.5  – 0.5 * cos(2.pi.t/T)
        /// </summary>
        /// <param name="nbechant"> nombre de points de la fenetre  </param>
        /// <returns> Xs : tableau des valeurs de la fenetre de Hanning </returns>
        public static double[] Hanning(int nbechant)
        {
            double[] Xs = new double[nbechant];
            double a = 0.0;
            for (int i = 0; i < nbechant; i++)
            {
                a = (2.0 * PI * (Double)i) / (double)(nbechant - 1);
                Xs[i] = 0.5 - (0.5 * Math.Cos(a));
            }
            return Xs;
        }

        /// <summary>
        /// Fenetre de Hanning :  0.5  – 0.5 * cos(2.pi.t/T)
        /// </summary>
        /// <param name="nbechant"> nombre de points de la fenetre  </param>
        /// <returns> Xs[] : tableau des valeurs (type : decimal) de la fenetre de Hanning </returns>
        public static decimal[] HanningD(int nbechant)
        {
            decimal[] Xs = new decimal[nbechant];
            double a = 0.0;
            for (int i = 0; i < nbechant; i++)
            {
                a = (2.0 * PI * (Double)i) / (double)(nbechant - 1);
                Xs[i] = (decimal)(0.5 - (0.5 * Math.Cos(a)));
            }
            return Xs;
        }


        //Fenetre de Blackman
        //w3(t) * 0.42  – 0.5 * cos(2.pi.t/T) + 0.08 * cos(4.pi.t/T)

        /// <summary>
        /// Fenetre de Blackman :  0.42  – 0.5 * cos(2pt/T) + 0.08 * cos(4pt/T)
        /// </summary>
        /// <param name="nbechant"> nombre de points de la fenetre  </param>
        /// <returns> Xs : tableau des valeurs de la fenetre de Blackman </returns>
        public static double[] Blackman(int nbechant)
        {
            double[] Xs = new double[nbechant];
            double a, b = 0.0;
            for (int i = 0; i < nbechant; i++)
            {
                a = (2.0 * PI * (Double)i) / (double)(nbechant - 1);
                b = (4.0 * PI * (Double)i) / (double)(nbechant - 1);
                Xs[i] = 0.42 - (0.5 * Math.Cos(a)) + (0.08 * Math.Cos(b));
            }
            return Xs;
        }

        
        /// <summary>
        /// Fenetre Flattop : 0.281 + 0.521 * cos(2.pi.t/T) + 0.198 *cos(4.pi.t/T)
        /// </summary>
        /// <param name="nbechant"> nombre de points de la fenetre  </param>
        /// <returns> Xs : tableau des valeurs de la fenetre de Flattop </returns>
        public static double[] Flattop(int nbechant)
        {
            double[] Xs = new double[nbechant];
            double a, b = 0.0;
            for (int i = 0; i < nbechant; i++)
            {
                a = (2.0 * PI * (Double)i) / (double)(nbechant - 1);
                b = (4.0 * PI * (Double)i) / (double)(nbechant - 1);
                Xs[i] = 0.281 - (0.521 * Math.Cos(a)) + (0.198 * Math.Cos(b));
            }
            return Xs;
        }




    }
}
