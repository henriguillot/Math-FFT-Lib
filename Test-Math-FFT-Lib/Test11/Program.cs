using System;
using System.Numerics;
using FFTlib;
using PlotLib;


namespace Test11
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
            double Duree = 2; // 2 secondes

            double Te; //pas temporel d echantillonnage : Te
            Te = Duree / nbechant;

            Fe = 1 / Te;  // frequence d echantillonnage : Fe
            Console.WriteLine("Frequence d echantillonnage : Fe = {0}", Fe);

            double Freq;  //Frequence de base (max) du signal de test : 1*sin(2*pi*40*t)
            Freq = 40;  // 40 Hz

            //autre méthode pour calculer la fréquence d'écahntillonnage adéquate '
            Fe = DFT.CalcFreqSamp(nbechant, Freq, Duree);
            Console.WriteLine("Frequence d echantillonnage recalculée : Fe = {0}", Fe);


            decimal[] S2 = new decimal[nbechant];
            decimal[] S3 = new decimal[nbechant];
            decimal[] Si = new decimal[nbechant];

            // Generation du signal de test suivant : avec les parametres : 
            //     frequence dechantillonnage Fe
            //     nombre dechantillons : nbechant
            //     amplitude et frequence propre de chaque sinus
            //S = 1 * sin(2 * pi * 40 * t) + 0.5*sin(2 * pi * 80 * t)

             S2 = SiTest.GenSin2piF(nbechant, Freq, 1, Fe);
             //S3 = SiTest.GenSin2piF(nbechant, Freq*2, 0.5, Fe);

            // signal resultant "Additopn des deux signaux sinusoidaux
            for (int i = 0; i < nbechant; i++)
            {
                Si[i] = S2[i] + S3[i];
            }

            // resultat de la DFT (Discret Fourier Transform) dans le tableau de complexe : Ts[]
            //----------------------------------------------------------------------------------
            Complex[] Ts = new Complex[nbechant];
            Ts = DFT.DFTv2(S2);

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