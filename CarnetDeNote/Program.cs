using System;
using System.Collections.Generic;
using System.Linq;

namespace CarnetDeNote
{
    // Clasa principală
    class Program
    {
        static void Main(string[] args)
        {
            Carnet carnet = new Carnet();
            const string adminPassword = "admin123";

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n--- Carnet de Note ---");
                Console.WriteLine("1. Student");
                Console.WriteLine("2. Administrator");
                Console.WriteLine("3. Iesire");
                Console.Write("Alege o optiune: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        MeniuStudent(carnet);
                        break;
                    case "2":
                        Console.Write("Introduceti parola: ");
                        string password = Console.ReadLine();
                        if (password == adminPassword)
                        {
                            MeniuAdministrator(carnet);
                        }
                        else
                        {
                            Console.WriteLine("Parola incorecta!");
                            Console.ReadKey();
                        }

                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Optiune invalida. Incercati din nou.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void MeniuStudent(Carnet carnet)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n--- Meniu Student ---");
                Console.WriteLine("1. Vizualizeaza note");
                Console.WriteLine("2. Inroleaza-te la o disciplina");
                Console.WriteLine("3. Trimite o contestatie");
                Console.WriteLine("4. Inapoi la meniul principal");
                Console.Write("Alege o optiune: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        VizualizeazaNoteStudent(carnet);
                        break;
                    case "2":
                        InroleazaStudentLaDisciplina(carnet);
                        break;
                    case "3":
                        TrimiteContestatie(carnet);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Optiune invalida. Incercati din nou.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void MeniuAdministrator(Carnet carnet)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n--- Meniu Administrator ---");
                Console.WriteLine("1. Adauga o disciplina");
                Console.WriteLine("2. Publica note pentru o disciplina");
                Console.WriteLine("3. Adauga nota la o disciplina");
                Console.WriteLine("4. Inapoi la meniul principal");
                Console.Write("Alege o optiune: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        AdaugaDisciplina(carnet);
                        break;
                    case "2":
                        PublicaNoteAdministrator(carnet);
                        break;
                    case "3":
                        AdaugaNotaLaDisciplina(carnet);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Optiune invalida. Incercati din nou.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        static void VizualizeazaNoteStudent(Carnet carnet)
        {
            Console.Clear();
            Console.WriteLine("--- Notele tale ---");
            foreach (var disciplina in carnet.Discipline)
            {
                disciplina.PublicaNote();
            }

            Console.ReadKey();
        }

        static void InroleazaStudentLaDisciplina(Carnet carnet)
        {
            Console.Clear();
            Console.WriteLine("--- Inroleaza-te la o disciplina ---");
            Console.Write("Nume disciplina: ");
            string nume = Console.ReadLine();
            Console.Write("Semestru (1/2): ");
            int semestru = Int32.TryParse(Console.ReadLine(), out int s) ? s : 0;
            Console.Write("An: ");
            int an = Int32.TryParse(Console.ReadLine(), out int a) ? a : 0;
            Console.Write("Tip disciplina (1-Obligatorie, 2-Optionala, 3-Facultativa): ");
            int tip = Int32.TryParse(Console.ReadLine(), out int t) ? t : 0;

            try
            {
                Disciplina disciplina;
                switch (tip)
                {
                    case 1:
                        disciplina = new DisciplinaObligatorie(nume, semestru, an);
                        break;
                    case 2:
                        disciplina = new DisciplinaOptionala(nume, semestru, an);
                        break;
                    case 3:
                        disciplina = new DisciplinaFacultativa(nume, semestru, an);
                        break;
                    default:
                        Console.WriteLine("Tip disciplina invalid.");
                        return;
                }

                carnet.Discipline.Add(disciplina);
                Console.WriteLine("Disciplina adaugata cu succes!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare: {ex.Message}");
            }

            Console.ReadKey();
        }

        static void TrimiteContestatie(Carnet carnet)
        {
            Console.Clear();
            Console.WriteLine("--- Trimite o contestatie ---");
            Console.Write("Nume disciplina: ");
            string nume = Console.ReadLine();

            var disciplina =
                carnet.Discipline.FirstOrDefault(d => d.Nume.Equals(nume, StringComparison.OrdinalIgnoreCase));

            if (disciplina == null)
            {
                Console.WriteLine("Disciplina inexistenta.");
                Console.ReadKey();
                return;
            }

            Console.Write("Nota contestata: ");
            float nota = float.TryParse(Console.ReadLine(), out float n) ? n : 0;
            disciplina.AdaugaNota(new Nota(nota));
            Console.WriteLine("Contestatie trimisa cu succes.");
            Console.ReadKey();
        }

        static void AdaugaDisciplina(Carnet carnet)
        {
            Console.Clear();
            Console.WriteLine("--- Adauga o disciplina ---");
            Console.Write("Nume disciplina: ");
            string nume = Console.ReadLine();
            Console.Write("Semestru (1/2): ");
            int semestru = Int32.TryParse(Console.ReadLine(), out int s) ? s : 0;
            Console.Write("An: ");
            int an = Int32.TryParse(Console.ReadLine(), out int a) ? a : 0;
            Console.Write("Tip disciplina (1-Obligatorie, 2-Optionala, 3-Facultativa): ");
            int tip = Int32.TryParse(Console.ReadLine(), out int t) ? t : 0;

            try
            {
                Disciplina disciplina;
                switch (tip)
                {
                    case 1:
                        disciplina = new DisciplinaObligatorie(nume, semestru, an);
                        break;
                    case 2:
                        disciplina = new DisciplinaOptionala(nume, semestru, an);
                        break;
                    case 3:
                        disciplina = new DisciplinaFacultativa(nume, semestru, an);
                        break;
                    default:
                        Console.WriteLine("Tip disciplina invalid.");
                        return;
                }

                carnet.Discipline.Add(disciplina);
                Console.WriteLine("Disciplina adaugata cu succes!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Eroare: {ex.Message}");
            }

            Console.ReadKey();
        }

        static void PublicaNoteAdministrator(Carnet carnet)
        {
            Console.Clear();
            Console.WriteLine("--- Publica note ---");
            Console.Write("Nume disciplina: ");
            string nume = Console.ReadLine();

            var disciplina =
                carnet.Discipline.FirstOrDefault(d => d.Nume.Equals(nume, StringComparison.OrdinalIgnoreCase));

            if (disciplina == null)
            {
                Console.WriteLine("Disciplina inexistenta.");
                Console.ReadKey();
                return;
            }

            disciplina.PublicaNote();
            Console.ReadKey();
        }

        static void AdaugaNotaLaDisciplina(Carnet carnet)
        {
            Console.Clear();
            Console.WriteLine("--- Adauga Nota ---");
            Console.Write("Nume disciplina: ");
            string nume = Console.ReadLine();

            var disciplina =
                carnet.Discipline.FirstOrDefault(d => d.Nume.Equals(nume, StringComparison.OrdinalIgnoreCase));

            if (disciplina == null)
            {
                Console.WriteLine("Disciplina inexistenta.");
                Console.ReadKey();
                return;
            }

            Console.Write("Introduceti nota (1-10): ");
            float valoareNota = float.TryParse(Console.ReadLine(), out float nota) ? nota : 0;

            if (valoareNota < 1 || valoareNota > 10)
            {
                Console.WriteLine("Nota invalida. Trebuie sa fie intre 1 si 10.");
                Console.ReadKey();
                return;
            }

            disciplina.AdaugaNota(new Nota(valoareNota));
            Console.WriteLine("Nota adaugata cu succes!");
            Console.ReadKey();
        }
    }
}