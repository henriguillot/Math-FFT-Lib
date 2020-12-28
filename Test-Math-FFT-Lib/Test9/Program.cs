using System;
using System.Numerics;
using FFTlib;
using PlotLib;


namespace Test9
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
            double Fe;
            Fe = 1000.0;   //1000 Hz

            

            //calcul du nombre de points a echantillonner 
            //sur un crénau de 0.25 secondes (250 milisecondes) avec une fréquence d'échantillonnage de 1000 Hz
            // échantillonnage a 1 points toutes les 1/1000 = 0.001 secondes

            nbechant = SiTest.Nbechant(1000, 0.25);  
            
            Console.WriteLine("nbechant = {0}", nbechant);

            decimal[] S2 = new decimal[nbechant];
            double[] S1 = new double[nbechant];

            //Form a signal containing a 50 Hz sinusoid of amplitude 4
            //S2 = 4*sin(2*pi*50*t)  

            S2 = SiTest.GenSin2piF(nbechant, 50.0, 4.0, Fe);

            // resultat de la DFT (Discret Fourier Transform) dans le tableau de complexe : Ts[]
            //----------------------------------------------------------------------------------
            Complex[] Ts = new Complex[nbechant];
            Ts = DFT.DFTv2(S2);

            //Recuperation du module de la DFT  
            decimal[] Module = new decimal[nbechant];
            //Module = DFT.Dsdec(Ts);

            //Densite spectrale de puissance du signal 
            //---------------------------------------------------------------------------
            decimal[] Module1 = new decimal[nbechant];
            Module1 = DSP.Dspdeci(Ts);

            //plot signal de test : Tableau Ti1[]
            //-------------------------------------------------------------------
            PlotPython.Plot1(S2, argument);

             
            //plot Densite spectrale de puissance du sgignal
            //------------------------------------------------------------------
            PlotPython.Plot1(Module1, argument);




        }


    }
}
