
using probleme_main;
using SkiaSharp;
using System.Diagnostics;
using System.Runtime.InteropServices;

class Jeu
{
    
    public static void Main(string[] args)
    {
        
        
        
        //On affiche les règles et d'un plateau exemple pour les joueurs.
        Plateau plateau = new Plateau(4);
        plateau.toString();
        Console.WriteLine("Bienvenue sur le jeu Boogle\n\n" +
            "Règles : Un plateau composé de 16 lettres va s'afficher. Chaque joueur aura alors 1 minutes pour composer un maximum de mot du dictionnaire en allant lettre par lettre et de manière horizontale, verticale, et diagonale.\n\n" +
            "Voici un exemple de plateau du jeu :\n"+ plateau.toString());

        Console.WriteLine("Combien de joueurs êtes vous ? (2 minimum)");



        //On définit le nombre de joueurs qui vont jouer au jeu.
        int nombre_joueurs = Convert.ToInt32(Console.ReadLine());
        while (nombre_joueurs < 2)
        {
            Console.WriteLine("Il n'y a pas assez de joueur pour commencer la partie.");
            nombre_joueurs = Convert.ToInt32(Console.ReadLine());
        }


        //On créer un tableau de joueurs pour pouvoir ajouter chaque joueurs à la partie.
        Joueur[] joueurs = new Joueur[nombre_joueurs];
        Console.WriteLine("Veuillez maintenant renseigner le nom de chaque joueur : ");



        //on ajoute chaque joueurs au tableau précedemment créer.
        for(int i = 0; i < nombre_joueurs; i++)
        {
            Joueur joueur= new Joueur(Convert.ToString(Console.ReadLine()));
            joueurs[i] = joueur;
        }
        
        //On demande et définit la durée et la langue de la partie.
        Console.WriteLine("Vous allez donc pouvoir commencer votre partien, mais avant vous devez définir le temps de votre partie en minutes et la langue dans laquelle vous allez jouer.\n" +
            "Durée de la partie :  ");
        int durée_partie = Convert.ToInt32(Console.ReadLine());


        Console.WriteLine("Langue de Jeu (saisissez FR ou EN): ");
        string langue = (Console.ReadLine()).ToUpper();


        //ici on initialise le dictionnaire en fonction de la langue choisie par les joueurs.
        Dictionnaire Dico= new Dictionnaire(" "," ");
        if (langue == "FR")
        {
            Dictionnaire dico = new Dictionnaire("C:\\Users\\hugoy\\source\\repos\\probleme_main\\probleme_main\\bin\\Debug\\net6.0\\MotsPossiblesFR.txt", "Français");
            Dico = dico;
        }
        else if(langue== "EN")
        {
            Dictionnaire dico = new Dictionnaire("C:\\Users\\hugoy\\source\\repos\\probleme_main\\probleme_main\\bin\\Debug\\net6.0\\MotsPossiblesEN.txt", "English");
            Dico = dico;
            
        }
        
        //on fait attendre le joueur 1 seconde
        Thread.Sleep(1000);


        //On dit au joueur que la partie va commencer et qu'il faut presser la barre entrer pour débuter la manche
        Console.WriteLine("La partie va donc durer " + durée_partie + " minutes.\n\nDès que vous appuierai sur ENTRER un plateau va s'afficher, la première manche jouée par " + joueurs[0].Nom+" va commencer et le compte à rebours va se lancer");
        string entrer = Console.ReadLine();


        //On créer la date de et de début et des qu'elle sont égales la partie s'arrête. Donc tout le code du jeu va se trouver dans cette boucle.
        DateTime début = DateTime.Now;
        DateTime fin = début.AddMinutes(durée_partie);


        //Déclaration d'un ensemble de variable que l'on va utiliser
        var dictionnaire_de_mots = new Dictionary<string, int>(); // on déclare un dictionnaire qui va stocker tous les mots commptabilisés par chaque joueur avec le score de chaque mot, pour être affiché dans le nuage de mot.
        string mot; //on déclare la variable mot qui représente le mot inscrit par le joueur à chaque tentative.
        int compteur_de_mot; //ce compteur permet juste de réafficher le plateau de jeu au bout de 4 tentatives de mot soumises.
        int compteur_de_mot_pour_nuage; //on déclare un compteur de mot qui permet de savoir si un mot est déjà dans la liste des mots inscrits, permettant de ne pas mettre de doublons dans le dictionnaire de mot pour le nuage de mots.
        List<string> mots_pour_nuage = new List<string>(); // on déclare le dictionaire de clé mots_pour_nuages dans lequel on met chaque mot validé par le code et qui seront ensuite affiché par le nuage de mots.



        //Première boucle qui régis le temps total de la partie.
        while (DateTime.Now<=fin)    
        {
            

            //Boucle for qui permet de changer de joueur/manche une fois le chrono de 1 minute atteint.
            for (int i = 0; i<nombre_joueurs; i++)
            {
                //on créer les dates de début et de fin de manche pour pouvoir faire un timer de 1 minutes par joueur
                DateTime début_de_manche = DateTime.Now;
                DateTime fin_de_manche = début_de_manche.AddMinutes(1);

                //On indique quel joueur commence à jouer et on initialise son plateau
                Console.WriteLine("C'est au tour de " + joueurs[i].Nom + " de jouer \n " +
                    "Voici ton plateau :\n");
                plateau = new Plateau(4);
                Console.WriteLine(plateau.toString());

                //on initialise le compteur de mot qui va réafficher le plateau.
                compteur_de_mot = 0;



                //On créer le timer de chaque manche qui va servir de boucle pour la suite du jeu et la comptabilisation des mots
                do
                {
                    compteur_de_mot++;
                    Console.WriteLine("Saisissez un nouveau mot : ");
                    mot = Console.ReadLine();
                    if (mot.Length != 0)
                    {
                        int Debut = 0;
                        int Fin = -1;
                        //ici on affiche si la tentative du joueur est bonne ou pas et si elle l'est alors on ajoute le mot inscrit à la liste de mots du joueur
                        if (Dico.RechDichoRecursif(mot, Debut, Fin))
                        {
                            Console.WriteLine("Ce mot existe ");
                            if (plateau.Test_Plateau(mot))
                            {
                                Console.WriteLine("Ce mot est sur le plateau");
                                joueurs[i].Add_mot(mot);
                                if (joueurs[i].Contain(mot) == false)
                                {
                                    compteur_de_mot_pour_nuage = 0;
                                    foreach (string element in mots_pour_nuage)
                                    {
                                        if (mot == element)
                                        {
                                            compteur_de_mot_pour_nuage++;
                                        }
                                    }
                                    if (compteur_de_mot_pour_nuage == 0)
                                    {
                                        mots_pour_nuage.Add(mot);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Ce mot n'est pas sur le plateau");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ce mot n'existe pas");
                        }

                    }//ici comme précisé avant on réaffiche le plateau toutes les 5 tentatives pour que le joueur puisse voir le plateau
                    if (compteur_de_mot % 5 == 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine(plateau.toString());
                    }


                } while (DateTime.Now <= fin_de_manche);
                Console.WriteLine("Appuyer sur n'importe quelle touche de votre clavier pour passer la main au joueur suivant");

            }
        }
        
        //on affiche le score de chaque joueur à la fin de la partie
        Console.WriteLine("La partie est terminée. Voici le score de chaque joueur : ");
        for(int i = 0; i < nombre_joueurs;i++)
        {
            joueurs[i].score = joueurs[i].ObtenirScore();
            Console.WriteLine(joueurs[i].toString());
           
        }
        int score_du_mot;
        foreach(string element in mots_pour_nuage) 
        {
            
            score_du_mot = Nuage.Obtenir_Score_Mot(element);
            dictionnaire_de_mots.Add(element, score_du_mot);
        }

        string fichier = "nuage_de_mots.png";
        // Générer le nuage de mots
        Nuage.GenererNuageDeMots(dictionnaire_de_mots, fichier);

        // Ouvre le fichier photo contenant le nuage de mots
        Process.Start(new ProcessStartInfo(fichier) { UseShellExecute = true });
        

    }

    
       
    
    
    
    


}
