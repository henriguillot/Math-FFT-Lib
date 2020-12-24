using System;
using System.Numerics;
using FFTlib;
using PlotLib;


namespace Test_DFT
{
    class Program
    {

        static void Main(string[] args)
        {

            string argument;

            // script python a executer pour ploter les resultats
            //-------------------------------------------------
            argument = "C:\\C#\\MathsLib\\Test_sysarg-v4.py" + " ";

            //test de plusieurs fonctionnalites
            //-------------------------------------------------

            int nbechant;
            //nombre de points a echantillonner 
            nbechant = SiTest.Nbechant(1000, 0.25);  //crenau de 0.25 secondes (250 milisecondes) et frequence de 1000 Hz

            //Form a signal containing a 50 Hz sinusoid of amplitude 1 and a 120 Hz sinusoid of amplitude 1.
            //S = 1*sin(2*pi*50*t) + sin(2*pi*120*t);

            decimal[] S1 = new decimal[nbechant];
            decimal[] S2 = new decimal[nbechant];

            S1 = SiTest.GenSin(nbechant, 50, 1);
            S2 = SiTest.GenSin(nbechant, 120, 1);

            // Instantiate random number generator using system-supplied value as seed.
            // signal de bruit blanc ( random noise signal)
            //-----------------------------------------------------------------------
            decimal[] Rand = new decimal[nbechant];
            Rand = SiTest.Random(nbechant);


            // genere le signal de test : s1 + s2  + bruit blanc d Amplidtude 2
            //-----------------------------------------------------------------------
            decimal[] Ti = new decimal[nbechant];
            for (int i = 0; i < nbechant; i++)
            { Ti[i] = S1[i] + S2[i] + (2 * Rand[i]);
            }
            
            // resultat de la DFT (Discret Fourier Transform) dans le tableau de complexe : Ts[]
            //----------------------------------------------------------------------------------
            Complex[] Ts = new Complex[nbechant];
            Ts = DFT.DFTv2(Ti);

            //Recuperation du module de la DFT  
            decimal[] Module = new decimal[nbechant];
            //Module = DFT.Dsdec(Ts);

            //Densite spectrale de puissance du signal 
            //---------------------------------------------------------------------------
            decimal[] Module1 = new decimal[nbechant];
            Module1 = DSP.Dspdeci(Ts);

            // Densite spectrale de puissance du signal
            double[] Module3 = new double[nbechant];
            //Module3 = DSP.Dspdoub(Ts);

            //impression partie reelle (amplitude du signal transforme par la DFT
            //PlotPython.Plot1(Ti1, argument);

            //impression partie imaginaire (phase du signal transforme par la DFT
            //PlotPython.Plot1(Tc2, argument);

            //plot signal de test : Tableau Ti1[]
            //-------------------------------------------------------------------
            PlotPython.Plot1(Ti, argument);

            //plot magnitude du sgignal calcule par DFTv2  
            //PlotPython.Plot1(Module, argument);

            //plot Densite spectrale de puissance du sgignal
            //------------------------------------------------------------------
            PlotPython.Plot1(Module1, argument);




        }


    }
}



