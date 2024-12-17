using System;
using System.Reflection.Metadata;

namespace probleme_main
{
    internal class Joueur
    {
        //déclaration des attributs du joueurs
        public string nom;
        public int score;
        public List<string> mots_trouves;


        //constructeur naturel de la classe Joueur
        public Joueur(string nom)
        {
            this.nom = nom;
            score = 0;
            mots_trouves = new List<string>();

        }

        //déclaration des propriétés qu'on pourrait utiliser plus tard
        public string Nom
        {
            get { return nom; }
        }
        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        public List<string> Mots_trouves
        {
            get { return mots_trouves; }
            set { mots_trouves = value; }
        }

        //fonction qui vérifie si le mot trouvé par le joueur a déjà été trouvé par ce joueur avant
        public bool Contain(string mot)
        {
            bool a = false;
            for (int i = 0; i < mots_trouves.Count; i++)
            {
                if (mot == mots_trouves[i])
                {
                    a = true;
                }
            }
            return a;
        }

        //fonction qui ajoute le mot trouvé à la liste des mots trouvés par le joueur
        public void Add_mot(string mot)
        {
            mot = mot.ToUpper();
            if (Contain(mot) == false)
            {
                mots_trouves.Add(mot);
            }
        }


        //Méthode toString qui affiche les informations du joueur
        public string toString()
        {
            string mots = " ";
            if (mots_trouves.Count == 0)
            {
                mots = "Aucun mot trouvé";
            }
            else
            {
                foreach (string element in mots_trouves)
                {
                    mots += element + "   ";
                }
            }
            return ("Nom : " + this.nom + "\n" + "Score : " + score + "\n" + "Mots trouvés : " + mots);
        }

        public int ObtenirScore()
        {
            foreach(string element in mots_trouves)
            {
                foreach(char c in element)
                {
                    for (int i = 0; i < 25; i++) {
                        if (c == Lettre.Tableau_de_lettres[i].symbole)
                        {
                            score += Lettre.Tableau_de_lettres[i].score_lettre;
                        }
                    }
                }
            }
            return score;
        }

        
        //main temporaire pour voir la classe marche bien
        /*
        public static void Main(string[] args)
        {
            Joueur Joueur1 = new Joueur("Paul");
            Joueur Joueur2 = new Joueur("Alice");
            Joueur[] joueurs = {Joueur1, Joueur2}; 
            string mot = "voiture";
            string mot2 = "caravane";
            Joueur1.Add_mot(mot);
            Joueur1.Add_mot(mot2);
            for(int i = 0; i< joueurs.Length; i++)
            {
                joueurs[i].score = joueurs[i].ObtenirScore();
                Console.WriteLine(joueurs[i].toString());
            }

        }
        */
        
    }
}
