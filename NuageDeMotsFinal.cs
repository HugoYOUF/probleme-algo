using System;
using SkiaSharp;
using System.Collections.Generic;
using System.Diagnostics;


namespace probleme_main
{
    internal class Nuage
    { 
        /*
        static void Main()
        {
            // Exemple de données : mots avec leur fréquence
            var mots = new Dictionary<string, int>();
            List<string> motsnuages =  new List<string> {  "cuisine", "voiture", "cheval", "helicoptere"  };
            int taille_nuage;
            for (int j = 0; j < motsnuages.Count; j++)
            {
                taille_nuage = Obtenir_Score_Mot(motsnuages[j]);
                mots.Add(motsnuages[j], taille_nuage);
            }

            string fichier = "nuage_de_mots.png";
            // Générer le nuage de mots
            GenererNuageDeMots(mots, fichier);

            Console.WriteLine("Nuage de mots généré dans le fichier : "+fichier);
            try
            {
                // Ouvre le fichier avec le programme par défaut
                Process.Start(new ProcessStartInfo(fichier) { UseShellExecute = true });
                Console.WriteLine("Fichier ouvert avec succès !");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de l'ouverture du fichier : {ex.Message}");
            }
        }
        */
        
        
        

        public static void GenererNuageDeMots(Dictionary<string, int> mots, string cheminFichier)
        {
            int largeur = 800;
            int hauteur = 600;

            using var surface = SKSurface.Create(new SKImageInfo(largeur, hauteur));
            var canvas = surface.Canvas;

            // Fond blanc
            canvas.Clear(SKColors.White);

            var random = new Random();

            foreach (var mot in mots)
            {
                // Taille du texte selon la fréquence du mot
                int tailleTexte = 10 + mot.Value * 5;
                float x = random.Next(50, largeur - 150);
                float y = random.Next(50, hauteur - 50);

                using var paint = new SKPaint
                {
                    TextSize = tailleTexte,
                    IsAntialias = true,
                    Color = new SKColor(
                        (byte)random.Next(50, 255),
                        (byte)random.Next(50, 255),
                        (byte)random.Next(50, 255)),
                    Typeface = SKTypeface.FromFamilyName("Arial")
                };

                // Dessiner le mot
                canvas.DrawText(mot.Key, x, y, paint);


            }
            // Sauvegarder l'image en PNG
            using var image = surface.Snapshot();
            using var data = image.Encode(SKEncodedImageFormat.Png, 100);
            using var stream = System.IO.File.OpenWrite(cheminFichier);
            data.SaveTo(stream);
        }


        public static int Obtenir_Score_Mot(string mot)
        {
            int score = 0;
                for (int i = 0; i < mot.Length; i++)
                {
                    mot = mot.ToUpper();
                    for (int j = 0; j < 25; j++)
                    {
                        if (mot[i] == Lettre.Tableau_de_lettres[j].symbole)
                        {
                            score += Lettre.Tableau_de_lettres[j].score_lettre;
                        }
                    }
                }
                return score;
            
        }
        
    }
}
