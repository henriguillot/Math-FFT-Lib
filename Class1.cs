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

    public class DFT    // Discrete Fourier Transform
    {
        // calcul de DFT (discrete Fourier Transform)
        // version avec argument en entree de " type complex[] "
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

        // calcul de DFT (discrete Fourier Transform)
        // version avec argument en entree de " type float[] "
        // avec type Complex defini dans System.Numerics
        //argument en entree : 
        //      x[] : Tableau des points echantillonés temporellement
        // argument en sortie : 
        //      tableau des resultats sous forme de nombres complexes : Tc[N] : Re + i.Im
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

        // calcul de DFT (discrete Fourier Transform) sur N points
        // version avec argument en entree de " type decimal[] "
        // avec type Complex defini dans System.Numerics
        //argument en entree : 
        //      x[] : Tableau des points echantillonés temporellement
        // argument en sortie : 
        //      tableau des resultats sous forme de nombres complexes : Tc[N] : Re + i.Im
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

        // calcul de DFT (discrete Fourier Transform) sur N points
        // version avec argument en entree de " type double[] "
        // avec type Complex defini dans System.Numerics
        //argument en entree : 
        //      x[] : Tableau des points echantillonés temporellement
        // argument en sortie : 
        //      tableau des resultats sous forme de nombres complexes : Tc[N] : Re + i.Im
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

        // calcul de DFT (discrete Fourier Transform) sur N points
        // version avec argument en entree de " type double[] "
        // avec type Complex defini dans System.Numerics
        //argument en entree : 
        //      double Ti[] : Tableau des points echantillonés temporellement
        // argument en sortie : 
        //      tableau des resultats partie Reelle :  double Re[N]    : x
        //      tableau des resultats partie Imaginaire : double Im[N] : y 
        //      x + i.y
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

        //Magnitude du signal ( module du signal)
        //argument en emtree : 
        //          tableau de valeurs complexes : x + i.y
        // argument en sortie :
        //          tableau des modules ( SQRT(x*x + y*y))
        //          type : double
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

        //Magnitude du signal ( module du signal)
        //argument en emtree : 
        //          tableau de valeurs complexes : x + i.y
        //          type : Complexe
        // argument en sortie :
        //          tableau des modules ( SQRT(x*x + y*y))
        //          type " decimal
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

        //MAgnitude du signal ( module du signal)
        //argument en emtree : 
        //          tableau de valeurs complexes : x + i.y
        //          type : Complexe
        // argument en sortie :
        //          tableau des modules ( SQRT(x*x + y*y))
        //          type " float
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

        // Obtention de DFT (discrete Fourier Transform)
        // version avec argument en entree de " type float[] "
        // avec type Complex defini dans System.Numerics
        // arguments en sortie : 
        //      tableau des resultats sous forme de nombre complexe : Tc[256] : Re + i.Im
        //      tableau des parties imaginaires :  Im[256]
        //      tableau des parties Réelles :  Re[256]
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

        // Obtention de DFT (discrete Fourier Transform)
        // version avec argument en entree de " type decimal[] "
        // avec type Complex defini dans System.Numerics
        // arguments en sortie : 
        //      tableau des resultats sous forme de nombre complexe : Tc[256] : Re + i.Im
        //      tableau des parties imaginaires :  Im[256]
        //      tableau des parties Réelles :  Re[256]
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

        // Obtention de DFT (discrete Fourier Transform)
        // version avec argument en entree de " type decimal[] "
        // avec type Complex defini dans System.Numerics
        // arguments en sortie : 
        //      tableau des resultats sous forme de nombre complexe : Tc[N] : Re + i.Im
        //      tableau des parties imaginaires :  Im[N]
        //      tableau des parties Réelles :  Re[N]
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

        // Obtention de DFT (discrete Fourier Transform) calculé sur N points
        // version avec argument en entree de " type float[] "
        // avec type Complex defini dans System.Numerics
        // arguments en sortie : 
        //      tableau des resultats sous forme de nombre complexe : Tc[N] : Re + i.Im
        //      tableau des parties imaginaires :  Im[N]
        //      tableau des parties Réelles :  Re[N]
        
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

        // Obtention de DFT (discrete Fourier Transform) calculé sur N points
        // version avec argument en entree de " type double[] "
        // avec type Complex defini dans System.Numerics
        // arguments en sortie : 
        //      tableau des resultats sous forme de nombre complexe : Tc[N] : Re + i.Im
        //      tableau des parties imaginaires :  Im[N]
        //      tableau des parties Réelles :  Re[N]
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





    public class FFT
    {
        //do nothing for now  .... it is for test phase 1
        public static double Multiply(double a, double b)
        { return a * b; }

        //Calcul dune FFT sur un tableau de 256 points 
        public static decimal[] FFT256(decimal[] y)
        {
            //calcul de la FFT surle tableau entrant y[]
            decimal[] T = new decimal[256];
            //resultant sortant dans le tableau T[]
            return T;
        }

        //Calcul dune FFT sur un tableau de 512 points 
        public static decimal[] FFT512(decimal[] y)
        {
            //calcul de la FFT surle tableau entrant y[]
            decimal[] T = new decimal[512];
            //resultant sortant dans le tableau T[]
            return T;
        }

        //Calcul dune FFT sur un tableau de 1024 points
        public static decimal[] FFT1024(decimal[] y)
        {
            //calcul de la FFT surle tableau entrant y[]
            decimal[] T = new decimal[1024];
            //resultant sortant dans le tableau T[]

            // code en deveopement 
            // prochaine version a venir
            //-----------------------------------
            //*****************************************8
            return T;
        }

        //Calcul d<une FFT sur un tableau de n points , longueur du tableau variable
        public static decimal[] FFTN(decimal[] y)
        {
            //calcul de la FFT surle tableau entrant y[]
            decimal[] T = new decimal[y.Length];
            //resultant sortant dans le tableau T[]

            // code en deveopement 
            // prochaine version a venir
            //-----------------------------------
            //*****************************************8

            return T;
        }

        
        
    }
    
} 



