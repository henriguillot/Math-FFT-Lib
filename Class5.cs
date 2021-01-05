using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace FFTlib
{
    /// <summary>
    /// Classe dédiée aux fichiers 
    /// </summary>
    public class Fich
    {

        /// <summary>
        ///stockage des données de calcul d'une DFT ou d'un signal de Test dans un ficher au format texte.
        /// tableau Xi[] au format decimal
        /// </summary> 
        /// <param name="Xi"> donnees DFT ou signal de base  </param>
        /// <param name="Name"> nom du fichier de données  </param>
        /// <param name="Fe"> frequence dechantillonnage (en Hz) </param> 
        /// <param name="nbechant"> nombre d'échantillons(en Hz) </param> 
        //------------------------------------------------------------------------
        // argument en entree : 
        //        decimal Xi[] :  donnees DFT ou signal de base
        //        string Name  : nom du fichier de données
        //        double Fe    : frequence dechantillonnage (en Hz)
        //        int nbechant : nombre d'échantillons
        //-----------------------------------------------------------------------
        public static void StoficSign(decimal[] Xi, String Name, double Fe, int nbechant)    //Write decimal array to a text file 
        {
            // re-initialisation du fichier de test
            if (File.Exists(Name))
            {
                File.Delete(Name);
            }

            var outf = new StreamWriter(Name);     //creation du fichier texte
            outf.WriteLine(" {0} ", Fe);         // informations pour stockage des données de calcul d'une DFT dans un ficher au format texte.
            outf.WriteLine(" {0} ", nbechant);
            for (int i = 0; i < Xi.Length; i++)
                outf.WriteLine(" {0} ", Xi[i]);

            outf.Close();

        }

        /// <summary>
        ///stockage des données de calcul d'une DFT ou d'un signal de Test dans un ficher au format texte.
        /// tableau Xi[] au format decimal
        /// </summary> 
        /// <param name="Xi"> donnees DFT ou signal de base  </param>
        /// <param name="Name"> nom du fichier de données  </param>
        /// <param name="Fe"> frequence dechantillonnage (en Hz) </param> 
        /// <param name="nbechant"> nombre d'échantillons(en Hz) </param> 
        //------------------------------------------------------------------------
        // argument en entree : 
        //        double Xi[] :  donnees DFT ou signal de base
        //        string Name  : nom du fichier de données
        //        double Fe    : frequence dechantillonnage (en Hz)
        //        int nbechant : nombre d'échantillons
        //-----------------------------------------------------------------------
        public static void StoficSign(double[] Xi, String Name, double Fe, int nbechant)    //Write array (of type double) to a text file 
        {
            // re-initialisation du fichier de test
            if (File.Exists(Name))
            {
                File.Delete(Name);
            }

            var outf = new StreamWriter(Name);     //creation du fichier texte
            outf.WriteLine(" {0} ", Fe);         // informations pour stockage des données de calcul d'une DFT dans un ficher au format texte.
            outf.WriteLine(" {0} ", nbechant);
            for (int i = 0; i < Xi.Length; i++)
                outf.WriteLine(" {0} ", Xi[i]);

            outf.Close();

        }

    }
}
