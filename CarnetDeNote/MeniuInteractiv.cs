using System.Runtime.InteropServices.JavaScript;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CarnetDeNote;

public class MeniuInteractiv : IMeniuInteractiv
{
    private readonly ILogger<MeniuInteractiv> _logger;
    private readonly IConfiguration _configuration;

    public MeniuInteractiv(ILogger<MeniuInteractiv> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    public void Execute()
    {
            Carnet carnet = new Carnet();
            CalculatorMedieAnualaSiMulti calcMedie = new CalculatorMedieAnualaSiMulti();
            const string adminPassword = "admin123";

            while (true)
            {
                try
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
                                MeniuAdministrator(carnet, calcMedie);
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
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "A aparut o eroare in timpul executiei meniului principal.");
                }
            }
        
    }

    void MeniuStudent(Carnet carnet)
    {
        while (true) 
        { 
            try 
            {
                Console.Clear();
                Console.WriteLine("\n--- Meniu Student ---");
                Console.WriteLine("1. Vizualizeaza note");
                Console.WriteLine("2. Inroleaza-te la o disciplina optionala/facultativa"); 
                Console.WriteLine("3. Trimite si urmareste o contestatie"); 
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
                        TrimiteSiUrmaresteContestatie(carnet); 
                        break;
                    case "4": 
                        return;
                    default: 
                        Console.WriteLine("Optiune invalida. Incercati din nou."); 
                        Console.ReadKey();
                        break;
                    }
            }
            catch (Exception ex)
            {
                _logger.LogWarning(ex, "A aparut o eroare in meniul student.");
            }
        }
    }

    void MeniuAdministrator(Carnet carnet, CalculatorMedieAnualaSiMulti calcMedie)
    {
        try
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n--- Meniu Administrator ---");
                Console.WriteLine("1. Calculeaza media la disciplina");
                Console.WriteLine("2. Publica note");
                Console.WriteLine("3. Inapoi la meniul principal");
                Console.Write("Alege o optiune: ");

                switch (Console.ReadLine())
                {
                    case "1":
                        CalculeazaMedii(carnet, calcMedie);
                        break;
                    case "2":
                        PublicaNoteAdministrator(carnet);
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
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "A aparut o eroare in meniul administrator.");
        }
    }

    void VizualizeazaNoteStudent(Carnet carnet)
    {
        try
        {
            Console.Write("Introduceti anul: ");
            int an = int.Parse(Console.ReadLine());
            Console.Write("Introduceti semestrul: ");
            int semestru = int.Parse(Console.ReadLine());

            var disciplineFiltrate = carnet.Discipline
                .Where(d => d.An == an && d.Semestru == semestru)
                .ToList();

            if (!disciplineFiltrate.Any())
            {
                Console.WriteLine("Nu exista discipline pentru criteriile introduse.");
            }
            else
            {
                foreach (var disciplina in disciplineFiltrate)
                {
                    disciplina.PublicaNote();
                }
            }
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Eroare la vizualizarea notelor studentului.");
        }
    }

    void InroleazaStudentLaDisciplina(Carnet carnet)
    {
        try
        {
            Console.Write("Introduceti numele disciplinei: ");
            string nume = Console.ReadLine();
            Console.Write("Introduceti semestrul: ");
            int semestru = int.Parse(Console.ReadLine());
            Console.Write("Introduceti anul: ");
            int an = int.Parse(Console.ReadLine());

            var disciplina = new DisciplinaOptionala(nume, semestru, an);
            carnet.Discipline.Add(disciplina);

            Console.WriteLine("Studentul a fost inrolat la disciplina.");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Eroare la inrolarea studentului la disciplina.");
        }
    }

    void TrimiteSiUrmaresteContestatie(Carnet carnet)
    {
        try
        {
            Console.Write("Introduceti numele disciplinei: ");
            string nume = Console.ReadLine();
            var disciplina = carnet.Discipline.FirstOrDefault(d => d.Nume == nume);

            if (disciplina == null)
            {
                Console.WriteLine("Disciplina nu a fost gasita.");
                Console.ReadKey();
                return;
            }

            Console.Write("Introduceti nota contestata: ");
            float nota = float.Parse(Console.ReadLine());
            var contestatie = new Contestatie(nota);
            disciplina.AdaugaNota(contestatie);

            Console.Write("Introduceti noua nota dupa contestatie: ");
            float notaNoua = float.Parse(Console.ReadLine());
            contestatie.ActualizeazaNota(notaNoua, "Aprobata");

            Console.WriteLine($"Nota dupa contestatie: {contestatie.NotaDupaContestatie}");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Eroare la gestionarea contestatiei.");
        }
    }

    void CalculeazaMedii(Carnet carnet, CalculatorMedieAnualaSiMulti calcMedie)
    {
        try
        {
            Console.Write("Introduceti anul (sau 0 pentru toate): ");
            int an = int.Parse(Console.ReadLine());

            int medie = an == 0
                ? calcMedie.CalculeazaMedieMultianuala(carnet.Discipline)
                : calcMedie.CalculeazaMedieAnuala(carnet.Discipline, an);

            Console.WriteLine($"Media calculata este: {medie}");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Eroare la calcularea mediilor.");
        }
    }

    void PublicaNoteAdministrator(Carnet carnet)
    {
        try
        {
            foreach (var disciplina in carnet.Discipline)
            {
                disciplina.PublicaNote();
            }
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Eroare la publicarea notelor.");
        }
    }
}

    