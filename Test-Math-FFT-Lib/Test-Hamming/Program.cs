using System;
using System.Numerics;
using FFTlib;
using PlotLib;


namespace Test13
{
    class Program
    {
        static void Main(string[] args)
        {

            string argument;

            // script python a executer pour ploter les resultats
            //-------------------------------------------------
            argument = "C:\\C#\\MathsLib\\Test_sysarg-v4.py" + " ";

            int nbechant;
            double Fe;  //Frequence d echantllonnage

            //calcul de la frequence d echantillonnage FE
            //sampling frequency of Fe Hz  and a signal duration of 2 secondes.  avec une fréquence d'échantillonnage de Fe 

            nbechant = 256;
            double Duree = 0.05; // 0.05 secondes

            double Te; //pas temporel d echantillonnage : Te
            Te = Duree / nbechant;

            Fe = 1 / Te;  // frequence d echantillonnage : Fe
            Console.WriteLine("Frequence d echantillonnage : Fe = {0}", Fe);

            decimal[] S2 = new decimal[nbechant];
            decimal[] S3 = new decimal[nbechant];
            decimal[] Si = new decimal[nbechant];
            decimal[] Sign = new decimal[nbechant];
            decimal[] H = new decimal[nbechant];

            // Generation du signal de test suivant : avec les parametres : 
            //     frequence dechantillonnage Fe
            //     nombre dechantillons : nbechant
            //     frequence snusoidale : 2 Khz et 2.35 Khz
            //----------------------------------------------------------
            // S = 1 * sin(2 * pi * 2000 * t) + 1*sin(2 * pi * 2350 * t)
            //---------------------------------------------------------

            S2 = SiTest.GenSin2piF(nbechant, 2000, 1, Fe);
            S3 = SiTest.GenSin2piF(nbechant, 2350, 1, Fe);

            // signal resultant "Addition des deux signaux sinusoidaux
            for (int i = 0; i < nbechant; i++)
            {   Si[i] = S2[i] + S3[i];
            }

            //----------------------------------------------------
            // Fenetre de Hamming
            //--------------------------------------------------
            H = Fenetre.HammingD(nbechant);

            // Mutiplication du signal par la fenetre de Hamming
            for (int i = 0; i < nbechant; i++)
            {   Sign[i] = Si[i] * H[i];
            }


            //--------------------------------------------------------------------------------
            // resultat de la DFT (Discret Fourier Transform)  
            //----------------------------------------------------------------------------------
            Complex[] Ts = new Complex[nbechant];
            Ts = DFT.DFTv2(Sign);

            //----------------------------------------------------------------------------
            //Densite spectrale de puissance du signal 
            //---------------------------------------------------------------------------
            decimal[] Module1 = new decimal[nbechant];
            Module1 = DSP.Dspdeci(Ts);

            //Magnitude du signal
            //------------------------------------------
            decimal[] Module2 = new decimal[nbechant];
            Module2 = DFT.DspMagnDec(Ts);

            //plot signal de test : 
            //-------------------------------------------------------------------
            PlotPython.Plot1(Si, argument);

            //plot signal multiplié parla fenetre de Hamming  
            //-------------------------------------------------------------------
            PlotPython.Plot1(Sign, argument);

            //plot Densite spectrale de puissance du sgignal 
            //------------------------------------------------------------------
            PlotPython.Plot1(Module1, argument);

            //plot MAgnitude du sgignal 
            //------------------------------------------------------------------
            PlotPython.Plot1(Module2, argument);




        }


    }
}