using System;
using System.Collections.Generic;
using System.Text;
using System.Numerics;

namespace FFTlib
{
    public class DSP
    {
        /// <summary>
        ///classe pour la Densite Spectrale de Puissance (DSP)
        ///Class for power spectral density
        ///---------------------------------------------- 
        /// </summary>

        /// <summary>
        ///Desnsité spectrale de puissance du signal ( module au carré du signal)
        ///argument en entrée : 
        ///          Cmp : tableau des valeurs complexes : x + i.y d'une transformée de Fourier
        ///          Type : complexe
        /// argument en sortie :
        ///          Ts : tableau des modules elevés au carré (x*x + y*y)) de la transformée
        ///          type : double
        /// </summary>
        /// <param name="freq">
        /// </param>
        /// <returns>
        /// </returns>
        public static double[] Dspdoub(Complex[] Cmp)
        {
            double[] Ds = new double[Cmp.Length];
            double[] Ts = new double[Cmp.Length];

            // Ds " contient les magnitudes : sqrt(x*x + y*y))
            Ds = DFT.DspMagnDo(Cmp);

            for (int i = 0; i < Cmp.Length; i++)
            {  Ts[i] = Ds[i] * Ds[i];
            }

            //On divise par la longueur du signal 
            for (int i = 0; i < Cmp.Length; i++)
            {   Ts[i] = Ts[i] / Cmp.Length;
            }

            return Ts;
        }

        //Desnsité spectrale de puissance du signal ( module au carré du signal)
        //argument en entrée : 
        //          Cmp : tableau des valeurs complexes : x + i.y d'une transformée de Fourier
        // argument en sortie :
        //          Ts : tableau des modules elevés au carré (x*x + y*y)) de la transformée
        //          type : float
        public static float[] Dspflot(Complex[] Cmp)
        {
            float[] Ds = new float[Cmp.Length];
            float[] Ts = new float[Cmp.Length];
			
            Ds = DFT.DspMagnFlot(Cmp);
			
            for (int i = 0; i < Cmp.Length; i++)
            {   Ts[i] = Ds[i] * Ds[i];
            }

            //On divise par la longueur du signal 
            for (int i = 0; i < Cmp.Length; i++)
            {
                Ts[i] = Ts[i] / Cmp.Length;
            }

            return Ts;
        }

        //Desnsité spectrale de puissance du signal ( module au carré du signal)
        //argument en entrée : 
        //          Cmp : tableau des valeurs complexes : x + i.y d'une transformée de Fourier
        // argument en sortie :
        //          Ts : tableau des modules elevés au carré (x*x + y*y)) de la transformée
        //          type : decimal
        public static decimal[] Dspdeci(Complex[] Cmp)
        {
            decimal[] Ds = new decimal[Cmp.Length];
            decimal[] Ts = new decimal[Cmp.Length];
			
            Ds = DFT.DspMagnDec(Cmp);
			
            for (int i = 0; i < Cmp.Length; i++)
            {   Ts[i] = Ds[i] * Ds[i];
            }

            //On divise par la longueur du signal 
            for (int i = 0; i < Cmp.Length; i++)
            {    Ts[i] = Ts[i] / Cmp.Length;
            }

            return Ts;
        }

        //Desnsité spectrale de puissance du signal ( module au carré du signal)
        //argument en entrée : 
        //          Cmp : tableau des valeurs complexes : x + i.y d'une transformée de Fourier
        // argument en sortie :
        //          Ts : tableau des modules elevés au carré (x*x + y*y)) de la transformée
        //          type : decimal
        public static void Ds2(Complex[] Cmp, decimal[] Ts)
        {
            decimal[] Ds = new decimal[Cmp.Length];

            Ds = DFT.DspMagnDec(Cmp);

            for (int i = 0; i < Cmp.Length; i++)
            {   Ts[i] = Ds[i] * Ds[i];
            }

            //On divise par la longueur du signal 
            for (int i = 0; i < Cmp.Length; i++)
            {   Ts[i] = Ts[i] / Cmp.Length;
            }

            return;
        }
    }
}
