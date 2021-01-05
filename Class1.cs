using System;
using System.Numerics;

namespace FFTlib
{
    public class complex
    {
        public double real;
        public double imag;

        public complex()
        {
            double real = 0.0;
            double imag = 0.0;
        }

        public complex(double real)
        {
            this.real = real;
            this.imag = 0.0;
        }

        public complex(double real, double imag)
        {
            this.real = real;
            this.imag = imag;
        }

        public static complex frompolar(double r, double theta)
        {
            complex data;
            data = new complex(r * Math.Cos(theta), r * Math.Sin(theta));
            return data;
        }

        public static complex operator +(complex a, complex b)
        {
            complex data = new complex(a.real + b.real, a.imag + b.imag);
            return data;
        }
        public static complex operator -(complex a, complex b)
        {
            complex data = new complex(a.real - b.real, a.imag - b.imag);
            return data;
        }
        public static complex operator *(complex a, complex b)
        {
            complex data = new complex((a.real * b.real) - (a.imag * b.imag),
            (a.real * b.imag) + (a.imag * b.real));
            return data;
        }
        public double Magnitude
        {
            get
            {
                return Math.Sqrt(real * real + imag * imag);
                //return Math.Sqrt(Math.Pow(real, 2) + Math.Pow(imag, 2));
            }
        }
        public double Phase
        {
            get
            {
                return Math.Atan(imag / real);
            }
        }

    }

    /// <summary>
    /// Class dedicated to DFT (Discrete Fourier Transform)
    /// </summary>
    public class DFT    // Discrete Fourier Transform
    {
        /// <summary>
        /// calcule la frequence d'échantillonnage en fonction du nombre d'échantillons et de la durée du signal
        /// sampling frequency of Fe Hz   
        /// </summary>
        /// <param name="Nbechant">Nbechant : nombre de points (échantillons) dans la fenetre</param>
        /// <param name="Freq"> : Frequence du signal (en Herz) </param>
        /// <param name="Duree"> : longueur de la fenetre d'echantillonnage (en secondes) </param>
        /// <returns>  : Fréquence d'echantillonnage  (en Herz)   </returns>
        public static double CalcFreqSamp(int Nbechant, double Freq, double Duree)
        {
            double Te; //pas temporel d'echantillonnage : Te
            double Fe;       // fréquence d'echantillonnage

            Te = Duree / Nbechant;  //sample 1 échantillon toutes les Te secondes
            Fe = 1 / Te;  // frequence d echantillonnage : Fe : 1 échantillon toutes les Fe/nbechant Hz 

            //vérification de la règle de Nyquist 
            if (Fe <= (2*Freq))
            {
                Console.WriteLine("sampling frequency must be >= 2 * (MAx signalfrequency)");
                Console.WriteLine("sampling frequency = {0} Hz", Fe);
                Console.WriteLine("signal MAx frequency = {0} Hz", Freq);
            }

            //Console.WriteLine("Frequence d echantillonnage : Fe = {0}", Fe)
            return Fe;
        }


        /// <summary>
        /// calcul de DFT (discrete Fourier Transform)
        /// version avec argument en entree de " type complex[] "
        /// </summary>
        /// <param name="x"> x[] : array of complex values </param>
        /// <returns>  DFT[] array of complex values  </returns> 
        public static complex[] DFTv1(complex[] x)
        {
            int N = x.Length;
            complex[] X = new complex[N];
            for (int k = 0; k < N; k++)
            {
                X[k] = new complex(0, 0);
                for (int n = 0; n < N; n++)
                {
                    complex temp = complex.frompolar(1, -2 * Math.PI * n * k / N);
                    temp *= x[n];
                    X[k] += temp;
                }
            }
            return X;
        }

        /// <summary>
        /// calcul de DFT (discrete Fourier Transform)
        /// version avec argument en entree de " type float[] "
        /// avec type Complex defini dans System.Numerics
        ///argument en entree : 
        ///      x[] : Tableau des points echantillonés temporellement
        /// argument en sortie : 
        ///      tableau des resultats sous forme de nombres complexes : Tc[N] : Re + i.Im
        /// </summary> 
        /// <param name="x"> x[] : array of (float) values on which DFT has to be performed </param>
        /// <returns>  DFT[] array of (complex) values DFT </returns>  
        public static Complex[] DFTv2(float[] x)    //le type Complex est defini dans System.Numerics
        {
            int N = x.Length;
            Complex[] X = new Complex[N];
            double Re, Im;
            for (int k = 0; k < N; k++)
            {
                X[k] = new Complex(0, 0);
                Complex temp;
                for (int n = 0; n < N; n++)
                {
                    Re = (double)x[n] * Math.Cos((double)-2 * Math.PI * (double)n * ((double)k / (double)N));
                    Im = (double)x[n] * Math.Sin((double)-2 * Math.PI * (double)n * ((double)k / (double)N));
                    temp = new Complex(Re, Im);
                    X[k] += temp;
                }
            }
            return X;
        }

        /// <summary>
        /// calcul de DFT (discrete Fourier Transform) sur N points
        /// version avec argument en entree de " type decimal[] "
        /// avec type Complex defini dans System.Numerics
        ///argument en entree : 
        ///      x[] : Tableau des points echantillonés temporellement
        /// argument en sortie : 
        ///      tableau des resultats sous forme de nombres complexes : Tc[N] : Re + i.Im
        /// </summary>
        /// <param name="x"> x[] : array of (decimal) values on which DFT has to be performed </param>
        /// <returns>  DFT[] array of (complex) values DFT </returns>  
        public static Complex[] DFTv2(decimal[] x)    //le type Complex est defini dans System.Numerics
        {
            int N = x.Length;
            Complex[] Tc = new Complex[N];
            double Re, Im;
            for (int k = 0; k < N; k++)
            {
                Tc[k] = new Complex(0, 0);
                Complex temp;
                for (int n = 0; n < N; n++)
                {
                    Re = (double)x[n] * Math.Cos((double)-2 * Math.PI * (double)n * ((double)k / (double)N));
                    Im = (double)x[n] * Math.Sin((double)-2 * Math.PI * (double)n * ((double)k / (double)N));
                    temp = new Complex(Re, Im);
                    Tc[k] += temp;
                }
                
            }
            return Tc;
        }

        /// <summary>
        /// calcul de DFT (discrete Fourier Transform) sur N points
        /// version avec argument en entree de " type double[] "
        /// avec type Complex defini dans System.Numerics
        ///argument en entree : 
        ///      x[] : Tableau des points echantillonés temporellement
        /// argument en sortie : 
        ///      tableau des resultats sous forme de nombres complexes : Tc[N] : Re + i.Im
        /// </summary>
        /// <param name="x"> x[] : array of (double) values on which DFT has to be performed </param>
        /// <returns>  DFT[] array of (complex) values DFT </returns>   
        public static Complex[] DFTv2(double[] x)    //le type Complex est defini dans System.Numerics
        {
            int N = x.Length;
            Complex[] Tc = new Complex[N];
            double Re, Im;
            for (int k = 0; k < N; k++)
            {
                Tc[k] = new Complex(0, 0);
                Complex temp;
                for (int n = 0; n < N; n++)
                {
                    Re = (double)x[n] * Math.Cos((double)-2 * Math.PI * (double)n * ((double)k / (double)N));
                    Im = (double)x[n] * Math.Sin((double)-2 * Math.PI * (double)n * ((double)k / (double)N));
                    temp = new Complex(Re, Im);
                    Tc[k] = Tc[k] + temp;
                }

            }
            return Tc;
        }

        /// <summary>
        /// calcul de DFT (discrete Fourier Transform) sur N points
        /// version avec argument en entree de " type double[] "
        /// avec type Complex defini dans System.Numerics
        ///argument en entree : 
        ///      double Ti[] : Tableau des points echantillonés temporellement
        /// argument en sortie : 
        ///      tableau des resultats partie Reelle :  double Re[N]    : x
        ///      tableau des resultats partie Imaginaire : double Im[N] : y 
        ///      x + i.y
        /// </summary>
        /// <param name="Ti"> Ti[] : array of (double) values on which DFT has to be performed </param>
        /// <param name="Re"> Re[] : array of (double) returning the Real part of the DFT </param>  
        /// <param name="Im"> Im[] : array of (double) returning the Imaginary part of the DFT </param>  
        public static void DFTvp( double[] Ti, double[] Re, double[] Im)    //le type Complex est defini dans System.Numerics
        {
            double Ree = 0.0;
            double Ima = 0.0;
            double Temp1,Temp2,Calc;

            for (int k = 0; k < Ti.Length; k++)
            {
                Temp1 = 0.000;
                Temp2 = 0.000;
                for (int n = 0; n < Ti.Length; n++)
                {
                    Calc = Math.Cos((double)-2.0 * Math.PI * (double)n * ((double)k / (double)Ti.Length));
                    Ree = Ti[n] * Calc; 
                    
                    Ima = Ti[n] * Math.Sin((double)-2.0 * Math.PI * (double)n * ((double)k / (double)Ti.Length));

                    Temp1 = Temp1 + Ree;
                    Temp2 = Temp2 + Ima;
                                      
                }
                Re[k] = Temp1;
                Im[k] = Temp2;
            }
            return ;
        }

        /// <summary>
        ///Magnitude du signal ( module du signal)
        ///argument en emtree : 
        ///          tableau de valeurs complexes : x + i.y
        /// argument en sortie :
        ///          tableau des modules ( SQRT(x*x + y*y))
        ///          type : double
        /// </summary>
        /// <param name="Cmp"> Cmp[] : array of (Complex) values on which DFT Magnitude has to be calculated </param>
        /// <returns>  Ds[] array of (double) values representing Magnitude of the DFT </returns> 
        public static double[] DspMagnDo (Complex[] Cmp)
        {
            double[] Ds = new double[Cmp.Length];

            //Magnitude du signal : 
            for (int i = 0; i < Cmp.Length; i++)
            {
                Ds[i] = Cmp[i].Magnitude;
            }
            return Ds;
        }

        /// <summary>
        ///Magnitude du signal ( module du signal)
        ///argument en emtree : 
        ///          tableau de valeurs complexes : x + i.y
        ///         type : Complexe
        /// argument en sortie :
        ///          tableau des modules ( SQRT(x*x + y*y))
        ///          type " decimal
        /// </summary>
        /// <param name="Cmp"> Cmp[] : array of (Complex) values on which DFT Magnitude has to be calculated </param>
        /// <returns>  Ds[] array of (decimal) values representing Magnitude of the DFT </returns> 
        public static decimal[] DspMagnDec(Complex[] Cmp)
        {
            decimal[] Ds = new decimal[Cmp.Length];

            //Magnitude du signal : 
            for (int i = 0; i < Cmp.Length; i++)
            {
                Ds[i] = (decimal)Cmp[i].Magnitude;
            }
            return Ds;
        }

        /// <summary>
        ///MAgnitude du signal ( module du signal)
        ///argument en emtree : 
        ///          tableau de valeurs complexes : x + i.y
        ///          type : Complexe
        /// argument en sortie :
        ///          tableau des modules ( SQRT(x*x + y*y))
        ///          type " float
        /// </summary> 
        /// <param name="Cmp"> Cmp[] : array of (Complex) values on which DFT Magnitude has to be calculated </param>
        /// <returns>  Ds[] array of (float) values representing Magnitude of the DFT </returns> 
        public static float[] DspMagnFlot(Complex[] Cmp)
        {
            float[] Ds = new float[Cmp.Length];

            //Magnitude du signal : 
            for (int i = 0; i < Cmp.Length; i++)
            {
                Ds[i] = (float)Cmp[i].Magnitude;
            }
            return Ds;
        }

        /// <summary>
        /// Obtention de DFT (discrete Fourier Transform)
        /// version avec argument en entree de " type float[] "
        /// avec type Complex defini dans System.Numerics
        /// arguments en sortie : 
        ///      tableau des resultats sous forme de nombre complexe : Tc[256] : Re + i.Im
        ///      tableau des parties imaginaires :  Im[256]
        ///      tableau des parties Réelles :  Re[256]
        /// </summary> 
        /// <param name="y">   y[] : array of 256 (float) values on which DFT has to be performed </param>
        /// <param name="Re"> Re[] : array of 256 (decimal) returning the Real part of the DFT </param>  
        /// <param name="Im"> Im[] : array of 256 (decimal) returning the Imaginary part of the DFT </param>  
        /// <returns>  Tc[] array of 256 (complex) values DFT </returns>    
        public static Complex[] DFT256(float[] y, decimal[] Re, decimal[] Im)       //Calcul dune DFT sur un tableau de 256 points 
        {
            //calcul de la DFT sur le tableau entrant y[]
            Complex[] Tc = new Complex[256];
                            
            Tc = DFTv2(y);     // calcul de la DFT sur le tableau y

            //partie réelle : 
            for (int i = 0; i < 256; i++)
            {   Re[i] = (decimal)Tc[i].Real;
            }

            //partie imaginaire : 
            for (int i = 0; i < 256; i++)
            {   Im[i] = (decimal)Tc[i].Imaginary;
            }

            //resultat sortant dans le tableau Tc[]
            return Tc;
        }

        /// <summary>
        /// Obtention de DFT (discrete Fourier Transform)
        /// version avec argument en entree de " type decimal[] "
        /// avec type Complex defini dans System.Numerics
        /// arguments en sortie : 
        ///      tableau des resultats sous forme de nombre complexe : Tc[256] : Re + i.Im
        ///      tableau des parties imaginaires :  Im[256]
        ///      tableau des parties Réelles :  Re[256]
        /// </summary> 
        /// <param name="y">  y[] : array of 256 (decimal) values on which DFT has to be performed </param>
        /// <param name="Re"> Re[] : array of 256 (decimal) returning the Real part of the DFT </param>  
        /// <param name="Im"> Im[] : array of 256 (decimal) returning the Imaginary part of the DFT </param>  
        /// <returns>  Tc[] array of 256 (complex) values DFT </returns>    
        public static Complex[] DFT256(decimal[] y, decimal[] Re, decimal[] Im)       //Calcul dune DFT sur un tableau de 256 points 
        {
            //calcul de la DFT surle tableau entrant y[]
            Complex[] Tc = new Complex[256];

            Tc = DFTv2(y);     // calcul de la DFT sur le tableau y

            //partie réelle : 
            for (int i = 0; i < 256; i++)
            {   Re[i] = (decimal)Tc[i].Real;
            }

            //partie imaginaire : 
            for (int i = 0; i < 256; i++)
            {   Im[i] = (decimal)Tc[i].Imaginary;
            }

            //resultat sous forme d'un tableau de complexes dans Tc[]
            return Tc;
        }

        /// <summary>
        /// Obtention de DFT (discrete Fourier Transform)
        /// version avec argument en entree de " type decimal[] "
        /// avec type Complex defini dans System.Numerics
        /// arguments en sortie : 
        ///      tableau des resultats sous forme de nombre complexe : Tc[N] : Re + i.Im
        ///      tableau des parties imaginaires :  Im[N]
        ///      tableau des parties Réelles :  Re[N]
        /// </summary> 
        /// <param name="y">  y[] : array of (decimal) values on which DFT has to be performed </param>
        /// <param name="Re"> Re[] : array of (decimal) returning the Real part of the DFT </param>  
        /// <param name="Im"> Im[] : array of (decimal) returning the Imaginary part of the DFT </param>  
        /// <returns>  Tc[] array of (complex) values DFT </returns>    
        public static Complex[] DFTN(decimal[] y, decimal[] Re, decimal[] Im)       //Calcul dune DFT sur un tableau de N points 
        {
            //calcul de la DFT surle tableau entrant y[]
            Complex[] Tc = new Complex[y.Length];

            Tc = DFTv2(y);     // calcul de la DFT sur le tableau y

            //partie réelle : 
            for (int i = 0; i < y.Length; i++)
            {  Re[i] = (decimal)Tc[i].Real;
            }

            //partie imaginaire : 
            for (int i = 0; i < y.Length; i++)
            {   Im[i] = (decimal)Tc[i].Imaginary;
            }

            //resultat sous forme d'un tableau de complexes dans Tc[]
            return Tc;
        }

        /// <summary>
        /// Obtention de DFT (discrete Fourier Transform) calculé sur N points
        /// version avec argument en entree de " type float[] "
        /// avec type Complex defini dans System.Numerics
        /// arguments en sortie : 
        ///      tableau des resultats sous forme de nombre complexe : Tc[N] : Re + i.Im
        ///      tableau des parties imaginaires :  Im[N]
        ///      tableau des parties Réelles :  Re[N]
        /// </summary>
        /// <param name="y">  y[] : array of (float) values on which DFT has to be performed </param>
        /// <param name="Re"> Re[] : array of (decimal) returning the Real part of the DFT </param>  
        /// <param name="Im"> Im[] : array of (decimal) returning the Imaginary part of the DFT </param>  
        /// <returns>  Tc[] array of (complex) values DFT </returns>   
        public static Complex[] DFTN(float[] y, decimal[] Re, decimal[] Im)       //Calcul dune DFT sur un tableau de N points 
        {
            //calcul de la DFT surle tableau entrant y[]
            Complex[] Tc = new Complex[y.Length];

            Tc = DFTv2(y);     // calcul de la DFT sur le tableau y

            //partie réelle : 
            for (int i = 0; i < y.Length; i++)
            {
                Re[i] = (decimal)Tc[i].Real;
            }

            //partie imaginaire : 
            for (int i = 0; i < y.Length; i++)
            {
                Im[i] = (decimal)Tc[i].Imaginary;
            }

            //resultat sous forme d'un tableau de complexes dans Tc[]
            return Tc;
        }

        /// <summary>
        /// Obtention de DFT (discrete Fourier Transform) calculé sur N points
        /// version avec argument en entree de " type double[] "
        /// avec type Complex defini dans System.Numerics
        /// arguments en sortie : 
        ///      tableau des resultats sous forme de nombre complexe : Tc[N] : Re + i.Im
        ///      tableau des parties imaginaires :  Im[N]
        ///      tableau des parties Réelles :  Re[N]
        /// </summary>
        /// <param name="y">  y[] : array of (double) values on which DFT has to be performed </param>
        /// <param name="Re"> Re[] : array of (decimal) returning the Real part of the DFT </param>  
        /// <param name="Im"> Im[] : array of (decimal) returning the Imaginary part of the DFT </param>  
        /// <returns>  Tc[] array of (complex) values DFT </returns>   
        public static Complex[] DFTN(double[] y, decimal[] Re, decimal[] Im)       //Calcul dune DFT sur un tableau de N points 
        {
            //calcul de la DFT surle tableau entrant y[]
            Complex[] Tc = new Complex[y.Length];

            Tc = DFTv2(y);     // calcul de la DFT sur le tableau y

            //partie réelle : 
            for (int i = 0; i < y.Length; i++)
            {
                Re[i] = (decimal)Tc[i].Real;
            }

            //partie imaginaire : 
            for (int i = 0; i < y.Length; i++)
            {
                Im[i] = (decimal)Tc[i].Imaginary;
            }

            //resultat sous forme d'un tableau de complexes dans Tc[]
            return Tc;
        }

    }

    /// <summary>
    /// FFT
    /// </summary>
    public class FFT
    {
        //do nothing for now  .... it is for test phase 1
        public static double Multiply(double a, double b)
        { return a * b; }

        /// <summary>
        /// Calcul dune FFT sur un tableau de 256 points 
        /// </summary>
        public static decimal[] FFT256(decimal[] y)
        {
            //calcul de la FFT surle tableau entrant y[]
            decimal[] T = new decimal[256];
            //resultant sortant dans le tableau T[]
            return T;
        }

        /// <summary>
        /// Calcul dune FFT sur un tableau de 512 points Selon l'algorithme de  Cooley–Tukey
        /// </summary>
        /// <param name="Y">  Y[] : array of 512 (double) values on which FFT has to be performed </param>
        /// <returns>  Tc[] array of 512 (complex) values of FFT </returns> 
        public static Complex[] FFT512(double[] Y)
        {
            //calcul de la FFT surle tableau entrant Y[]
            //resultant sortant dans le tableau Tc[]

            int N = Y.Length;
            if (N > 512)
            {
                Console.WriteLine("nombre de points doit etre <= 512");
                Console.WriteLine("FFT sera calcul sur 512 points seulement");
            }

            Complex[] Tc = new Complex[512];    // résultat de la FFT
            Complex[] Ec = new Complex[256];  // Even (pair) 
            Complex[] Oc = new Complex[256];  // Od (impair)

            double[] E = new double[256];
            double[] O = new double[256];
            double Re, Im;

            for (int k = 0; k < 256; k++)
            {
                E[k] = Y[2*k];
                O[k] = Y[(2*k) + 1];
            }
            Ec = DFT.DFTv2(E);    // Ec ( Even - pair) DFT of Even indexed pat of signal          
            Oc = DFT.DFTv2(O);    // Odd ( Odd - impair) DFT of Odd indexed pat of signal 

            for (int k = 0; k < 256; k++)
            {
                Complex temp;
                Re = Math.Cos((double)-2 * Math.PI * ((double)k / (double)1024));
                Im = Math.Sin((double)-2 * Math.PI * ((double)k / (double)1024));
                temp = new Complex(Re, Im);
                Oc[k] = Oc[k] * temp;
            }

            for (int k = 0; k < 256; k++)
            {
                Tc[k] = Ec[k] + Oc[k];            // Tc[k] = Ec[k] + exp(-2.i.pi.k/N).Oc[k]
                Tc[k + (N / 2)] = Ec[k] - Oc[k];    // Tc[k+N/2] = Ec[k] - exp(-2.i.pi.k/N).Oc[k]
            }

            return Tc;
        }

        /// <summary>
        /// Calcul dune FFT sur un tableau de 512 points Selon l'algorithme de  Cooley–Tukey
        /// </summary>
        /// <param name="Y">  Y[] : array of 512 (decimal) values on which FFT has to be performed </param>
        /// <returns>  Tc[] array of 512 (complex) values of FFT </returns> 
        public static Complex[] FFT512(decimal[] Y)
        {
            //calcul de la FFT surle tableau entrant Y[]
            //resultant sortant dans le tableau Tc[]

            int N = Y.Length;
            if (N > 512)
            {
                Console.WriteLine("nombre de points doit etre <= 512");
                Console.WriteLine("FFT sera calcul sur 512 points seulement");
            }

            Complex[] Tc = new Complex[512];    // résultat de la FFT
            Complex[] Ec = new Complex[256];  // Even (pair) 
            Complex[] Oc = new Complex[256];  // Od (impair)

            decimal[] E = new decimal[256];
            decimal[] O = new decimal[256];
            double Re, Im;

            for (int k = 0; k < 256; k++)
            {
                E[k] = Y[2*k];
                O[k] = Y[(2*k) + 1];
            }
            Ec = DFT.DFTv2(E);    // Ec ( Even - pair) DFT of Even indexed pat of signal          
            Oc = DFT.DFTv2(O);    // Odd ( Odd - impair) DFT of Odd indexed pat of signal 

            for (int k = 0; k < 256; k++)
            {
                Complex temp;
                Re = Math.Cos((double)-2 * Math.PI * ((double)k / (double)1024));
                Im = Math.Sin((double)-2 * Math.PI * ((double)k / (double)1024));
                temp = new Complex(Re, Im);
                Oc[k] = Oc[k] * temp;
            }

            for (int k = 0; k < 256; k++)
            {
                Tc[k] = Ec[k] + Oc[k];            // Tc[k] = Ec[k] + exp(-2.i.pi.k/N).Oc[k]
                Tc[k + (N / 2)] = Ec[k] - Oc[k];    // Tc[k+N/2] = Ec[k] - exp(-2.i.pi.k/N).Oc[k]
            }

            return Tc;
        }

        /// <summary>
        /// Calcul dune FFT sur un tableau de 1024 points Selon l'algorithme de  Cooley–Tukey 
        /// </summary>
        /// <param name="Y">  Y[] : array of 1024 (double) values on which FFT has to be performed </param>
        /// <returns>  Tc[] array of 1024 (complex) values of FFT </returns> 
        public static Complex[] FFT1024(double[] Y)
        {
            //calcul de la FFT surle tableau entrant Y[]
            //resultant sortant dans le tableau Tc[]

            int N = Y.Length;
            if (N > 1024)
            {
                Console.WriteLine("nombre de points doit etre <= 1024");
                Console.WriteLine("FFT sera calculé sur 1024 points seulement");
            }

            Complex[] Tc = new Complex[1024];    // résultat de la FFT
            Complex[] Ec = new Complex[512];  // Even (pair) 
            Complex[] Oc = new Complex[512];  // Od (impair)

            double[] E = new double[512];
            double[] O = new double[512];
            double Re, Im;

            for (int k = 0; k < 512; k++)
            {
                E[k] = Y[2*k];
                O[k] = Y[(2*k) + 1];
            }
            Ec = DFT.DFTv2(E);    // Ec ( Even - pair) DFT of Even indexed pat of signal          
            Oc = DFT.DFTv2(O);    // Odd ( Odd - impair) DFT of Odd indexed pat of signal 

            for (int k = 0; k < 512; k++)
            {
                Complex temp;
                Re = Math.Cos((double)-2 * Math.PI * ((double)k / (double)1024));
                Im = Math.Sin((double)-2 * Math.PI * ((double)k / (double)1024));
                temp = new Complex(Re, Im);
                Oc[k] = Oc[k] * temp;
            }

            for (int k = 0; k < 512; k++)
            {
                Tc[k] = Ec[k] + Oc[k];            // Tc[k] = Ec[k] + exp(-2.i.pi.k/N).Oc[k]
                Tc[k + (N / 2)] = Ec[k] - Oc[k];    // Tc[k+N/2] = Ec[k] - exp(-2.i.pi.k/N).Oc[k]
            }

            return Tc;
        }


        /// <summary>
        /// Calcul dune FFT sur un tableau de 1024 points Selon l'algorithme de  Cooley–Tukey 
        /// </summary>
        /// <param name="Y">  Y[] : array of 1024 (decimal) values on which FFT has to be performed </param>
        /// <returns>  Tc[] array of 1024 (complex) values of FFT </returns> 
        public static Complex[] FFT1024(decimal[] Y)
        {
            //calcul de la FFT surle tableau entrant Y[]
            //resultant sortant dans le tableau Tc[]

            int N = Y.Length;
            if (N > 1024)
            {   Console.WriteLine("nombre de points doit etre <= 1024");
                Console.WriteLine("FFT sera calculé sur 1024 points seulement");
            }  

            Complex[] Tc = new Complex[1024];    // résultat de la FFT
            Complex[] Ec = new Complex[512];  // Even (pair) 
            Complex[] Oc = new Complex[512];  // Od (impair)

            decimal[] E = new decimal[512];
            decimal[] O = new decimal[512];
            double Re, Im;

            for (int k = 0; k < 512; k++)
            {
                E[k] = Y[2*k];
                O[k] = Y[(2*k) + 1];
            }
            Ec = DFT.DFTv2(E);    // Ec ( Even - pair) DFT of Even indexed pat of signal          
            Oc = DFT.DFTv2(O);    // Odd ( Odd - impair) DFT of Odd indexed pat of signal 

            for (int k = 0; k < 512; k++)
            {
                Complex temp;
                Re = Math.Cos((double)-2 * Math.PI * ((double)k / (double)1024));
                Im = Math.Sin((double)-2 * Math.PI * ((double)k / (double)1024));
                temp = new Complex(Re, Im);
                Oc[k] = Oc[k] * temp;
            }

            for (int k = 0; k < 512; k++)
            {
                Tc[k] = Ec[k] + Oc[k];            // Tc[k] = Ec[k] + exp(-2.i.pi.k/N).Oc[k]
                Tc[k + (N / 2)] = Ec[k] - Oc[k];    // Tc[k+N/2] = Ec[k] - exp(-2.i.pi.k/N).Oc[k]
            }

            return Tc;
        }

        /// <summary>
        /// Calcul dune FFT sur un tableau de N points Selon l'algorithme de  Cooley–Tukey 
        /// </summary>
        /// <param name="Y">  y[] : array of (double) values on which FFT has to be performed </param>
        /// <returns>  Tc[] array of (complex) values of FFT </returns> 
        public static Complex[] FFTN(double[] Y)
        {
            //calcul de la FFT surle tableau entrant y[]
            //resultant sortant dans le tableau Tc[]
            
            int N = Y.Length;

            Complex[] Tc = new Complex[N];    // résultat de la FFT
            Complex[] Ec = new Complex[N/2];  // Even (pair) 
            Complex[] Oc = new Complex[N/2];  // Od (impair)

            double[] E = new double[N/2];
            double[] O = new double[N/2];
            double Re, Im;

            for (int k = 0; k < N/2; k++)
            {
                E[k] = Y[2 * k];
                O[k] = Y[(2 * k) + 1];
            }
            Ec = DFT.DFTv2(E);    // Ec ( Even - pair) DFT of Even indexed pat of signal          
            Oc = DFT.DFTv2(O);    // Odd ( Odd - impair) DFT of Odd indexed pat of signal 

            for (int k = 0; k < N/2; k++)
            {
                Complex temp;
                Re = Math.Cos((double)-2 * Math.PI * ((double)k / (double)N));
                Im = Math.Sin((double)-2 * Math.PI * ((double)k / (double)N));
                temp = new Complex(Re, Im);
                Oc[k] = Oc[k] * temp;
            }

            for (int k = 0; k < N/2; k++)
            {
                Tc[k] = Ec[k] + Oc[k];            // Tc[k] = Ec[k] + exp(-2.i.pi.k/N).Oc[k]
                Tc[k + (N/2)] = Ec[k] - Oc[k];    // Tc[k+N/2] = Ec[k] - exp(-2.i.pi.k/N).Oc[k]
            }

            return Tc;
        }

        /// <summary>
        /// Calcul dune FFT sur un tableau de N points Selon l'algorithme de  Cooley–Tukey 
        /// </summary>
        /// <param name="Y">  y[] : array of (decimal) values on which FFT has to be performed </param>
        /// <returns>  Tc[] array of (complex) values of FFT </returns> 
        public static Complex[] FFTN(decimal[] Y)
        {
            //calcul de la FFT surle tableau entrant y[]
            //resultant sortant dans le tableau Tc[]

            int N = Y.Length;

            Complex[] Tc = new Complex[N];    // résultat de la FFT
            Complex[] Ec = new Complex[N/2];  // Even (pair) 
            Complex[] Oc = new Complex[N/2];  // Od (impair)

            decimal[] E = new decimal[N/2];
            decimal[] O = new decimal[N/2];
            double Re, Im;

            for (int k = 0; k < N/2; k++)
            {
                E[k] = Y[2 * k];
                O[k] = Y[(2 * k) + 1];
            }
            Ec = DFT.DFTv2(E);    // Ec ( Even - pair) DFT of Even indexed pat of signal          
            Oc = DFT.DFTv2(O);    // Odd ( Odd - impair) DFT of Odd indexed pat of signal 

            for (int k = 0; k < N / 2; k++)
            {
                Complex temp;
                Re = Math.Cos((double)-2 * Math.PI * ((double)k / (double)N));
                Im = Math.Sin((double)-2 * Math.PI * ((double)k / (double)N));
                temp = new Complex(Re, Im);
                Oc[k] = Oc[k] * temp;
            }

            for (int k = 0; k < N / 2; k++)
            {
                Tc[k] = Ec[k] + Oc[k];            // Tc[k] = Ec[k] + exp(-2.i.pi.k/N).Oc[k]
                Tc[k + (N / 2)] = Ec[k] - Oc[k];    // Tc[k+N/2] = Ec[k] - exp(-2.i.pi.k/N).Oc[k]
            }

            return Tc;
        }

    }
    
} 



