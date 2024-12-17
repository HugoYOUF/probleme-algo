using probleme_main;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace probleme_main
{
    internal class Plateau
    {

        public Dé[,] plateau;
        public int taille; 

        public Plateau(int taille = 4)
        {
            this.taille = taille;
            plateau = new Dé[taille,taille];
            InitialiserPlateau();
        }

        // Méthode pour initialiser le plateau avec des dés
        private void InitialiserPlateau()
        {
            Random r = new Random();
            for (int i = 0; i < taille; i++)
            {
                for (int j = 0; j < taille; j++)
                {
                    plateau[i, j] = new Dé(r);
                    plateau[i, j].Lance(r);
                }
                
            }
        }

        


        //fonction toString qui affiche le plateau proprement
        public string toString()
        {
            string affichage = "";
            for (int i = 0; i < taille; i++)
            {
                
                for(int j = 0; j < taille; j++)
                {
                    affichage += plateau[i, j].lettre_tiree + " ";
                }
                affichage += "\n";
            }
            return affichage;
        }

        public bool Test_Plateau(string mot)
        {
            mot = mot.ToUpper();

            if (mot.Length < 2)
            {
                return false;
            }
            for(int i = 0; i< 4; i++)
            {
                for(int j = 0; j<4; j++)
                {
                    if (plateau[i, j].Lettre_tiree == mot[0])
                    {
                            if(Test_Plateau_Recursif(i, j, mot, 0))
                            {
                                return true;
                            }
                    }
                }
            }
            return false;
        }

        public bool Test_Plateau_Recursif(int x, int y, string mot, int index)
        {
           
            if (index == mot.Length)
            {
                return true;
            }

            if(x<0 || y<0 || x>=taille || y >=taille || plateau[x, y].lettre_tiree!=mot[index]){
                return false;
            }

            char temp = plateau[x, y].Lettre_tiree;
            plateau[x, y].Lettre_tiree = '!';

            //Ici on créer 2 tableaux qui permettent d'effectuer une vérification des lettres 8 letters adjacentes en fonction de leur coordonnée ((-1, -1) , (-1, 0), (-1,1).... de manière circulaire
            int[]directions_horizontales = {-1,-1,-1,0,1,1,1,0};
            int[]directions_verticales =   {-1,0,1,1,1,0,-1,-1}; 

            for(int f = 0; f < 8; f++)
            {
                if (Test_Plateau_Recursif(x + directions_horizontales[f], y + directions_verticales[f],mot, index + 1))
                {
                    plateau[x, y].lettre_tiree = temp;
                    return true;
                }
            }


            plateau[x, y].Lettre_tiree = temp;
            return false;

        }



        


        //Main temporaire pour voir si la fonction marche correctement
        /*
        public static void Main(string[] args)
        {
            DateTime début = DateTime.Now;
            DateTime fin = début.AddMinutes(1);
            Plateau plateau1 = new Plateau(4);
            plateau1.toString();
            Console.WriteLine(plateau1.toString());
            Console.WriteLine("Entrez un nouveau mot :");
            string mot = Convert.ToString(Console.ReadLine());
            Console.WriteLine(plateau1.Test_Plateau(mot));

        }
        */
        
        


    }
}
