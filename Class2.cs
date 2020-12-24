using System;
using System.Collections.Generic;
using System.Text;

namespace FFTlib
{


    // routines de Tests . permettant de generer des tableaux de signaux de test
    public class SiTest
    {

        // calcule le nombre de poits a echantillonner en fonction de la frequence d'échantillonnage : Freq et de la durée du signal
        // caculate number of points to parse, sampled at a given frequency: Freq .
        // arguments en entrée :
        //         Freq : Frequence d'echantillonnage  (en Herz)
        //         Creneau : longueur de la fenetre d'echantillonnage (en secondes)
        //argument en sortie : 
        //         Npoints  : nombre de points (échantillons) dans la fenetre
        public static int Nbechant( double Freq, double Creneau)
        {
            int Nbpoints;   // nombre de points a echantillonner 
            double T;          // période d'echantillonnage
            
            T = 1.0 / Freq;
            Nbpoints = (int)(Creneau / T);
            return Nbpoints;
        }

        // Instantiate random number generator using system-supplied value as seed.
        // signal de bruit blanc ( random noise signal)
        public static decimal[] Random(int Nbpoints)
        {
           var rand = new Random();
           decimal[] Rand = new decimal[Nbpoints];
            for (int i = 0; i < Nbpoints; i++)
            {
                Rand[i] = (decimal)rand.Next();
            }
            return Rand;
        }

        // Instantiate random number generator using system-supplied value as seed.
        // signal de bruit blanc ( random noise signal)
        public static double[] RandomD(int Nbpoints)
        {
            var rand = new Random();
            double[] Rand = new double[Nbpoints];
            for (int i = 0; i < Nbpoints; i++)
            {
                Rand[i] = rand.Next();
            }
            return Rand;
        }

        // Instantiate random number generator using system-supplied value as seed.
        // signal de bruit blanc ( random noise signal)
        public static float[] RandomF(int Nbpoints)
        {
            var rand = new Random();
            float[] Rand = new float[Nbpoints];
            for (int i = 0; i < Nbpoints; i++)
            {
                Rand[i] = (float)rand.Next();
            }
            return Rand;
        }

        public static double PI = Math.PI;

        public static decimal[] GenSin(int Nbpoints)
        {
            decimal[] ys = new decimal[Nbpoints];
            for (int i = 0; i < Nbpoints; i++)
                ys[i] = (decimal)Math.Sin(i);
            return ys;
        }

         // generation d'un signal sinusoidal :  A.sin(2.pi.F.x) 
         // argument en entrée : 
         //         : int Nbpoints : nombre de points a echantillonner 
         //         : double Freq  : Frequence du signal
         //         : double Amp   : Amplitude du signal
         // argument en sortie :
         //         : ys  tableau de valeurs contenant le signal sinusoidal
        public static decimal[] GenSin(int Nbpoints,double Freq, double Amp)
        {
            decimal[] ys = new decimal[Nbpoints];
            double a = 0;
            for (int i = 0; i < Nbpoints; i++)
            {
                ys[i] = (decimal)(Amp * Math.Sin(a));
                a = a + ((2.0 * PI * Freq) / Nbpoints);
            }
                
            return ys;
        }

        // generation d'un signal sinusoidal :  A.sin(2.pi.F.x) 
        // argument en entrée : 
        //         : int Nbpoints : nombre de points a echantillonner 
        //         : double Freq  : Frequence du signal
        //         : double Amp   : Amplitude du signal
        // argument en sortie :
        //         : ys  tableau de valeurs contenant le signal sinusoidal
        public static double[] GenSinDou(int Nbpoints, double Freq, double Amp)
        {
                double[] ys = new double[Nbpoints];
                double a = 0;
                for (int i = 0; i < Nbpoints; i++)
                {
                    ys[i] = (Amp * Math.Sin(a));
                    a = a + ((2.0 * PI * Freq) / Nbpoints);
                }
                     
                return ys;
            }

        // generation d'un signal sinusoidal :  A.sin(2.pi.F.x) 
        // argument en entrée : 
        //         : int Nbpoints : nombre de points a echantillonner 
        //         : double Freq  : Frequence du signal
        //         : double Amp   : Amplitude du signal
        // argument en sortie :
        //         : ys  tableau de valeurs contenant le signal sinusoidal
        public static float[] GenSinFlo(int Nbpoints, double Freq, double Amp)
            {
                float[] ys = new float[Nbpoints];
                double a = 0;
                for (int i = 0; i < Nbpoints; i++)
                {
                   ys[i] = (float)(Amp * Math.Sin(a));
                   a = a + ((2.0 * PI * Freq) / Nbpoints);
                }
                      
                return ys;
            }

            public static decimal[] GenSin256m(int mult)
            {
                decimal[] ys = new decimal[256];
                for (int i = 0; i < 256; i++)
                    ys[i] = (decimal)Math.Sin(i) * mult;

                return ys;
            }
            public static decimal[] GenSin512m(int mult)
            {
                decimal[] ys = new decimal[512];
                for (int i = 0; i < 512; i++)
                    ys[i] = (decimal)Math.Sin(i) * mult;
                return ys;
            }
            public static decimal[] GenSin512()
            {
                decimal[] ys = new decimal[512];
                for (int i = 0; i < 512; i++)
                    ys[i] = (decimal)Math.Sin(i);
                return ys;
            }
            public static decimal[] GenCos(int length)
            {
                decimal[] ys = new decimal[length];
                for (int i = 0; i < length; i++)
                    ys[i] = (decimal)Math.Cos(i);
                return ys;
            }
            public static decimal[] GenCos512()
            {
                decimal[] ys = new decimal[512];
                for (int i = 0; i < 512; i++)
                    ys[i] = (decimal)Math.Cos(i);
                return ys;
            }
            public static decimal[] GenTan(int length)
            {
                decimal[] ys = new decimal[length];
                for (int i = 0; i < length; i++)
                    ys[i] = (decimal)Math.Tan(i);
                return ys;
            }

            public static decimal[] Gen(int n)
            {
                //Genere un tableau de n points 
                decimal[] ys = new decimal[n];
                for (int i = 0; i < n; i++)
                {
                    ys[i] = (decimal)i;
                }
                return ys;
            }
        }

            
    
}
