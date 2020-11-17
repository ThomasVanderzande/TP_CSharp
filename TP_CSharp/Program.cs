using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP_CSharp
{    
    public class Classe
    {
        public string nomClasse;
        public Classe(string classe)
        {
                nomClasse = classe;
        }
        // Création liste d'élèves (utilisation méthode Count dans la classe Ecole)
        public List<Eleve> eleves = new List<Eleve>();
        // Création tableau élèves
        public Eleve[] tabEleves = new Eleve[30];

        // Remplissage liste et tableau élèves
        public void ajouterEleve(string prenom, string nom)
        {
            Eleve eleve = new Eleve(prenom, nom);
            eleves.Add(eleve);
            int index = eleves.IndexOf(eleve);
            // Test sur la capacité du tableau
            if (index >= 30)
                Console.WriteLine("Trop d'élèves !");
            else
                tabEleves[index] = eleve;
        }
        // Création liste matières (utilisation méthode Count dans la classe Ecole)
        public List<string> matieres = new List<string>();
        // Création tableau matières
        public string[] tabMatieres = new string[10];
        // Remplissage liste et tableau matières
        public void ajouterMatiere(string matiere)
        {
            matieres.Add(matiere);
            int index = matieres.IndexOf(matiere);
            // Test sur la capacité du tableau
            if (index >= 10)
                Console.WriteLine("Trop de matières !");
            else
                tabMatieres[index] = matiere;
        }
        // Calcul moyenne classe pour la matiere
        public string Moyenne(int matiere)
        {
            double cumulMoyennesElevesMatiere = 0;
            foreach (Eleve eleve in eleves)
            {
                double moyenneEleveMatiere = Convert.ToDouble(eleve.Moyenne(matiere));
                cumulMoyennesElevesMatiere += moyenneEleveMatiere;
            }
                
            double moyenneMatiereClasse = cumulMoyennesElevesMatiere / eleves.Count;
            return moyenneMatiereClasse.ToString("##.00");
        }
        // Calcul moyenne classe générale
        public string Moyenne()
        {
            double sommeMoyennesClasseMatieres = 0;
            for (int i = 0; i < matieres.Count; i++)
            {
                double moyenneClasseMatiere = Convert.ToDouble(Moyenne(i));
                sommeMoyennesClasseMatieres += moyenneClasseMatiere;
            }
            double moyenneGeneraleClasse = sommeMoyennesClasseMatieres / matieres.Count;
            return moyenneGeneraleClasse.ToString("##.00");
        }
    }
    public class Eleve
    {
        public string prenom;
        public string nom;
        public Eleve(string prenomEleve, string nomEleve)
        {
            prenom = prenomEleve;
            nom = nomEleve;
        }
        // Création liste de notes de l'élève
        private List<Note> notesEleve = new List<Note>();
        // Création tableau de notes de l'élève
        private Note[] tabNotes = new Note[200];

        public void ajouterNote(Note note)
        {
            notesEleve.Add(note);
            int index = notesEleve.IndexOf(note);
            // Test sur la capacité du tableau
            if (index >= 200)
                Console.WriteLine("Trop de notes !");
            else
                tabNotes[index] = note;
        }
        // Calcul moyenne matière de l'élève
        public string Moyenne(int matiere)
        {
            float sommeNotesMatiere = 0;
            int compteurNotesMatiere = 0;
            foreach (Note note in notesEleve)
            {
                if (note.matiere == matiere)
                {
                    sommeNotesMatiere += note.note;
                    compteurNotesMatiere++;
                }
            }
            return (sommeNotesMatiere / compteurNotesMatiere).ToString("##.00");
        }
        // Calcul moyenne générale de l'élève
        public string Moyenne()
        {
            double sommeMoyennesMatiere = 0;
            int nombreDeMatieres = notesEleve.Count / 5;
            for (int i = 0; i < nombreDeMatieres; i++)
            {
                double moyenneMatiere = Convert.ToDouble(Moyenne(i));
                sommeMoyennesMatiere += moyenneMatiere;
            }
            return (sommeMoyennesMatiere / nombreDeMatieres).ToString("##.00");
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Ecole ecole = new Ecole();
        }
    }
}
