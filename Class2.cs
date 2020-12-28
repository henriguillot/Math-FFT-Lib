using System;
using System.Collections.Generic;
using System.Text;

namespace FFTlib
{

    /// <summary>
    /// routines de Tests . permettant de generer des tableaux de signaux de test
    /// </summary>
    public class SiTest
    {
        /// <summary>
        /// calcule le nombre de points a echantillonner en fonction de la frequence d'échantillonnageet de la durée du signal
        /// ------échantillonnage de 1 points toutes les 1/freq secondes
        /// Limitation a 1024 points
        /// </summary>
        /// <param name="Freq">: Frequence d'echantillonnage  (en Herz) </param>
        /// <param name="Creneau"> : longueur de la fenetre d'echantillonnage (en secondes) </param>
        /// <returns> Npoints  : nombre de points (échantillons) dans la fenetre </returns>
        public static int Nbechant( double Freq, double Creneau)
        {
            int Nbpoints;   // nombre de points a echantillonner 
            double T;       // période d'echantillonnage
            
            T = 1.0 / Freq;
            Nbpoints = (int)(Creneau / T);

            return Nbpoints;
        }

        /// <summary>
        /// Instantiate random number generator using system-supplied value as seed.
        /// signal de bruit blanc ( random noise signal)
        /// </summary>
        /// <param name="Nbpoints">Nombre de points a générer </param>
        /// <returns> Rand[] : Tableau de Nbpoints qui constitue le signal aléatoire  </returns>
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

        /// <summary>
        /// Instantiate random number generator using system-supplied value as seed.
        /// signal de bruit blanc ( random noise signal)
        /// </summary>
        /// <param name="Nbpoints">Nombre de points a générer </param>
        /// <returns> Rand[] : Tableau de Nbpoints qui constitue le signal aléatoire  </returns>
        
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

        /// <summary>
        /// Instantiate random number generator using system-supplied value as seed.
        /// signal de bruit blanc ( random noise signal)
        /// </summary>
        /// <param name="Nbpoints">Nombre de points a générer </param>
        /// <returns> Rand[] : Tableau de Nbpoints qui constitue le signal aléatoire  </returns>
         
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

        /// <summary>
        /// Valeur de pi pi = 3.14116...........  
        /// /// </summary>
        public static double PI = Math.PI;


        /// <summary>
        /// generation d'un signal sinusoidal :  A.sin(2.pi.Freq.x) de x=0 a x = Nbpoints avec pas d'échantillonnage = 1/Fe
        /// </summary>
        /// <param name="Nbpoints">Nombre de points a générer </param>
        /// <param name="Freq">: Frequence du signal sinusoidal : A.sin(2.pi.Freq.x) (en Herz) </param>
        /// <param name="Amp">: Amplitude du signal sinusoidal : A.sin(2.pi.Freq.x) </param>
        /// <param name="Fe">: Frequence d'échantillonnage du signal sinusoidal : A.sin(2.pi.Freq.x) </param>
        /// <returns> Ys[] : Tableau de Nbpoints qui constitue le signal : A.sin(2.pi.Freq.x)   </returns>

        public static decimal[] GenSin2piF(int Nbpoints,double Freq, double Amp, double Fe)
        {
            decimal[] ys = new decimal[Nbpoints];
            double x = 0;
            double a = 0;
            double pas = 0;

            // calcul du pas temporel d'Echantillonnage 
            pas = 1 / Fe; 

            x = (2.0 * PI * Freq);

            for (int i = 0; i < Nbpoints; i++)
            {
                ys[i] = (decimal)(Amp * Math.Sin(a * x));
                a = a + pas;
            }
                
            return ys;
        }

        /// <summary>
        /// generation d'un signal sinusoidal :  A.sin(2.pi.F.x) de x=0 a x=Nbpoints/Fe
        /// échantillonné a la fréquence : Fe 
        /// 1 point toutes les 1/Fe secondes  ( Fe en Hz et F en HZ)
        /// </summary>
        /// <param name="Nbpoints">Nombre de points a générer </param>
        /// <param name="Freq">: Frequence du signal sinusoidal : A.sin(2.pi.Freq.x) (en Herz) </param>
        /// <param name="Amp">: Amplitude du signal sinusoidal : A.sin(2.pi.Freq.x) </param>
        /// <param name="Fe">: fréquence d'échantillonnage (exprimée en Hz) </param>
        /// <returns> Ys[] : Tableau de Nbpoints qui constitue le signal : A.sin(2.pi.Freq.x)   </returns>
        public static double[] GenSinDou(int Nbpoints, double Freq, double Amp, double Fe)
        {
                double[] ys = new double[Nbpoints];
                double x = 0;
                double a = 0;
                double pas;
                x = (2.0 * PI * Freq);
                
                // calcul du pas temporel d'Echantillonnage 
                 pas =  1/Fe;

                for (int i = 0; i < Nbpoints; i++)
                {
                    ys[i] = (Amp * Math.Sin(x * a));
                    a = a + pas;
                }
                     
                return ys;
        }

        /// <summary>
        ///genere un tableau de points ( peut etre utilisé pour l'axe des X
        /// arguments en entrée
        ///  start : valeur de départ de l'Axe des X
        ///  stop : valeur de fin de l'axe des Y
        /// Nombre de points a ploter
        /// </summary>
        /// <param name="start">valeur de départ de l'Axe des X </param>
        /// <param name="stop">valeur de fin de l'Axe des X </param>
        /// /// <param name="Nbpoints">Nombre de points a générer </param>
        /// <returns> XD[] : Tableau des valeurs a afficher sur l'axe des abcisses </returns>
        public static decimal[] GenTabX(double start, double stop, int Nbpoints)
        {
            decimal[] XD = new decimal[Nbpoints];
            double[] X = new double[Nbpoints];
            double pas; 
            pas = (stop - start) / Nbpoints;
            X[0] = start;

            for (int i = 1; i < Nbpoints; i++)
            { X[i] = pas * i; }

            for (int i = 0; i < Nbpoints; i++)
            { XD[i] = (decimal)X[i]; }

            return XD ;
        }

        /// <summary>
        /// generation d'un simple signal sinusoidal :  sin(2.pi.x) de x = 0 a x = Nbpoints 
        /// </summary>
        /// <param name="Nbpoints">Nombre de points a générer </param>
        /// <returns> Ys[] : Tableau de Nbpoints qui constitue le signal : sin(2.pi.x)   </returns>
        public static double[] GenSin2Pix(int Nbpoints)
        {
                double[] ys = new double[Nbpoints];
                
                for (int i = 0; i < Nbpoints; i++)
                {
                   ys[i] = Math.Sin(2 *PI* i);
                }
                      
                return ys;
        }

        /// <summary>
        /// generation d'un simple signal sinusoidal :  A*sin(x) de x = 0 to x = 256  : [0,256]  
        /// </summary>
        /// <param name="A">Amplitude du signal a générer : A*sin(x) </param>
        /// <returns> Ys[] : Tableau de 256 points qui constitue le signal     </returns>
        public static decimal[] GenSin256m(int A)
        {
                decimal[] ys = new decimal[256];
                for (int i = 0; i < 256; i++)
                    ys[i] = (decimal)Math.Sin(i) * A;

                return ys;
        }

        /// <summary>
        /// generation d'un simple signal sinusoidal :  A*sin(x) de x = 0 to x = 512  : [0,512]  
        /// </summary>
        /// <param name="A">Amplitude du signal a générer : A*sin(x) </param>
        /// <returns> Ys[] : Tableau de 256 points qui constitue le signal     </returns>
        public static decimal[] GenSin512m(int A)
        {
                decimal[] ys = new decimal[512];
                for (int i = 0; i < 512; i++)
                    ys[i] = (decimal)Math.Sin(i) * A;
                return ys;
        }

        /// <summary>
        /// generation d'un simple signal sinusoidal :  A*sin(x) de x = 0 to x = NBpoints  
        /// </summary>
        /// <param name="Nbpoints">Nombre de points a générer </param>
        /// <param name="A">Amplitude du signal a générer : A*sin(x) </param>
        /// <returns> Ys[] : Tableau de Nbpoints points qui constitue le signal     </returns>
        public static decimal[] GenSin(int Nbpoints, decimal A)
        {
            decimal[] ys = new decimal[Nbpoints];
            for (int i = 0; i < Nbpoints; i++)
                ys[i] = (decimal)Math.Sin(i) * A;
            return ys;
        }

        /// <summary>
        /// generation d'un simple signal sinusoidal :  A*cos(x) de x = 0 to x = NBpoints  
        /// </summary>
        /// <param name="Nbpoints">Nombre de points a générer </param>
        /// <param name="A">Amplitude du signal a générer : A*cos(x) </param>
        /// <returns> Ys[] : Tableau de Nbpoints points qui constitue le signal     </returns>
        public static decimal[] GenCos(int Nbpoints , decimal A)
        {
                decimal[] ys = new decimal[Nbpoints];
                for (int i = 0; i < Nbpoints; i++)
                    ys[i] = (decimal)Math.Cos(i) * A;
                return ys;
        }

        /// <summary>
        /// generation d'un simple signal sinusoidal :  A*cos(x) de x = 0 to x = 512  
        /// </summary>
        /// <param name="A">Amplitude du signal a générer : A*cos(x) </param>
        /// <returns> Ys[] : Tableau de Nbpoints points qui constitue le signal     </returns>
        public static decimal[] GenCos512( decimal A)
        {
                decimal[] ys = new decimal[512];
                for (int i = 0; i < 512; i++)
                    ys[i] = (decimal)Math.Cos(i) * A;
                return ys;
        }

        /// <summary>
        /// generation d'un simple signal sinusoidal :  A*tg(x) de x = 0 to x = length  
        /// </summary>
        /// <param name="length">Nombre de points a générer </param>
        /// <param name="A">Amplitude du signal a générer : A*tg(x) </param>
        /// <returns> Ys[] : Tableau de Nbpoints points qui constitue le signal     </returns>
        public static decimal[] GenTan(int length, decimal A)
        {
                decimal[] ys = new decimal[length];
                for (int i = 0; i < length; i++)
                    ys[i] = (decimal)Math.Tan(i) * A;
                return ys;
        }

        /// <summary>
        /// generation d'un simple tableau y[] de n points:  y = x de x = 0 to x = n  
        /// </summary>
        /// <param name="n">Nombre de points a générer </param>
        /// <returns> Ys[] : Tableau de n points qui constitue le signal     </returns>
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
