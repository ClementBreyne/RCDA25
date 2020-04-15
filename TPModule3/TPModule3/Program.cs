using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPModule3.BO;

namespace TPModule3
{
    public class Program
    {
        private static List<Auteur> ListeAuteurs = new List<Auteur>();
        private static List<Livre> ListeLivres = new List<Livre>();

        private static void InitialiserDatas()
        {
            ListeAuteurs.Add(new Auteur("GROUSSARD", "Thierry"));
            ListeAuteurs.Add(new Auteur("GABILLAUD", "Jérôme"));
            ListeAuteurs.Add(new Auteur("HUGON", "Jérôme"));
            ListeAuteurs.Add(new Auteur("ALESSANDRI", "Olivier"));
            ListeAuteurs.Add(new Auteur("de QUAJOUX", "Benoit"));
            ListeLivres.Add(new Livre(1, "C# 4", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 533));
            ListeLivres.Add(new Livre(2, "VB.NET", "Les fondamentaux du langage", ListeAuteurs.ElementAt(0), 539));
            ListeLivres.Add(new Livre(3, "SQL Server 2008", "SQL, Transact SQL", ListeAuteurs.ElementAt(1), 311));
            ListeLivres.Add(new Livre(4, "ASP.NET 4.0 et C#", "Sous visual studio 2010", ListeAuteurs.ElementAt(3), 544));
            ListeLivres.Add(new Livre(5, "C# 4", "Développez des applications windows avec visual studio 2010", ListeAuteurs.ElementAt(2), 452));
            ListeLivres.Add(new Livre(6, "Java 7", "les fondamentaux du langage", ListeAuteurs.ElementAt(0), 416));
            ListeLivres.Add(new Livre(7, "SQL et Algèbre relationnelle", "Notions de base", ListeAuteurs.ElementAt(1), 216));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3500, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(0).addFacture(new Facture(3200, ListeAuteurs.ElementAt(0)));
            ListeAuteurs.ElementAt(1).addFacture(new Facture(4000, ListeAuteurs.ElementAt(1)));
            ListeAuteurs.ElementAt(2).addFacture(new Facture(4200, ListeAuteurs.ElementAt(2)));
            ListeAuteurs.ElementAt(3).addFacture(new Facture(3700, ListeAuteurs.ElementAt(3)));
        }
        static void Main(string[] args)
        {
            InitialiserDatas();

            IEnumerable<String> lstAuteurStartByG = new List<String>();
            lstAuteurStartByG = ListeAuteurs.Where(auteur => auteur.Nom.StartsWith("G")).Select(auteur => auteur.Prenom);
            Console.WriteLine("La liste des auteurs dont le nom commence par G :");
            foreach( string prenom in lstAuteurStartByG)
            {
                Console.WriteLine(prenom + "\n");
            }
            var AuteurPlusDeLivre = ListeLivres.GroupBy(auteur=>auteur.Auteur).OrderBy(auteur=>auteur.Count()).FirstOrDefault();

            Console.WriteLine("L'auteur ayant écrit le plus de livres : " + AuteurPlusDeLivre.Key);

            var MoyennePageLivre = ListeLivres.GroupBy(auteur => auteur.Auteur);
            foreach(var livres in MoyennePageLivre)
            {
                Console.WriteLine("La moyenne des pages de l'auteur : " + livres.Key.Nom + " " + livres.Key.Prenom + "Est de "
                + livres.Average(page => page.NbPages));
            }

            var LivrePlusdePage = ListeLivres.OrderByDescending(p=> p.NbPages).FirstOrDefault();
            Console.WriteLine("Le livre avec le plus de page est : " + LivrePlusdePage.Titre);
            

            var gainMoyen = ListeAuteurs.Average(f => f.Factures.Sum(l => l.Montant));
            Console.WriteLine("Les auteurs ont gagnés en moyenne : " + gainMoyen);

            var livreParAuteur = ListeLivres.GroupBy(a => a.Auteur);

            foreach(var livreAuteur in livreParAuteur)
            {
                Console.WriteLine("Les livres de l'auteur : " + livreAuteur.Key.Nom + " " + livreAuteur.Key.Prenom);
                foreach(var livres in livreAuteur)
                {
                    Console.WriteLine(livres.Titre);
                }
            }

            var livreOrdreAlphabetique = ListeLivres.OrderBy(l => l.Titre);
            foreach(var livre in livreOrdreAlphabetique)
            {
                Console.WriteLine("Liste des livres triés par odre alphabétique : "+livre.Titre+"\n");
            }
            
            var livreSupMoyenne = ListeLivres.Average(l => l.NbPages);
            Console.WriteLine("Les livres ayant plus de pages que la moyenne : \n");
            foreach (var livre in ListeLivres)
            {
                if (livre.NbPages > livreSupMoyenne)
                {
                    Console.WriteLine(livre.Titre + "\n");
                }
            }

            var AuteurMoinsdeLivres = ListeLivres.GroupBy(a => a.Auteur).OrderBy(c => c.Count()).FirstOrDefault().Key;
            Console.WriteLine("L'auteur ayant écrit le moins de livres est : " + AuteurMoinsdeLivres.Nom + " " + AuteurMoinsdeLivres.Prenom);
            Console.ReadKey();
        }
    }
}
