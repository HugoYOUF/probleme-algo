using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace probleme_main
{
    internal class Lettre
    {

        //fréquence de la lettre = poids = probabilité qu'elle apparaisse sur chaque face
        public char symbole;
        public int score_lettre;
        public int frequence_lettre;
        public char[] tableau_lettres_frequence_score;
        
        //constructeur naturel de la classe Lettre qui va nous permettre de créer un tableau de Lettre avec chaque symbole, poids, et son score
        public Lettre(char symbole, int score_lettre, int frequence_lettre)
        {
            this.symbole = symbole;
            this.score_lettre = score_lettre;
            this.frequence_lettre = frequence_lettre;
        }


        //on créer les propriétés des lettres qu'on pourrait potentiellement utiliser plus tard
        public char Symbole
        {
            get { return symbole; }
        }
        public int Score_lettre
        {
            get { return score_lettre; }
        }
        public int Frequence_lettre
        {
            get { return frequence_lettre; }
        }
        public char[] Tableau_lettres_frequence_score
        {
            get
            {
                return tableau_lettres_frequence_score;
            }
        }

        //On créer le tableau de lettre avec chaque lettre, son poids, et son score
        public static Lettre[] Tableau_de_lettres = new Lettre[]
        {
            new Lettre('A',1,9),
            new Lettre('B',3,2),
            new Lettre('C',3,2),
            new Lettre('D',2,3),
            new Lettre('E',1,15),
            new Lettre('F',4,2),
            new Lettre('G',2,2),
            new Lettre('H',4,2),
            new Lettre('I',1,8),
            new Lettre('J',8,1),
            new Lettre('K',10,1),
            new Lettre('L',1,5),
            new Lettre('M',2,3),
            new Lettre('N',1,6),
            new Lettre('O',1,6),
            new Lettre('P',3,2),
            new Lettre('R',1,6),
            new Lettre('S',1,6),
            new Lettre('T',1,6),
            new Lettre('U',1,6),
            new Lettre('V',4,2),
            new Lettre('W',10,1),
            new Lettre('X',10,1),
            new Lettre('Y',10,1),
            new Lettre('Z',10,1),
        };

        public static char[] Obtenir_tableau_toutes_les_lettres_possibles()
        {
            //on trouve la taille du tableau de lettres, on pourrait simplement compter et additionner chaque poids de chaque lettre 
            int taille = 0;
            for (int i = 0; i < Tableau_de_lettres.Length; i++)
            {
                taille+= Tableau_de_lettres[i].frequence_lettre;
            }
            char[] tableau_lettres_frequence = new char[taille];
            int frequence = 0;
            int j = 0; 
            for (int i = 0; i < Tableau_de_lettres.Length; i++)
            {
                frequence = Tableau_de_lettres[i].frequence_lettre;
                while (frequence > 0)
                    {
                    tableau_lettres_frequence[j] = Tableau_de_lettres[i].symbole;
                    frequence--;
                    j++;
                    }
            }
            return tableau_lettres_frequence;
        }


        //public static void Main(string[] args)
        //{
        // char[] a = Obtenir_tableau_toutes_les_lettres_possibles();
        // for(int i =  0; i < a.Length; i++)
        // {
        //Console.Write(a[i] + ", ");
        // }

        // }





    }
}
