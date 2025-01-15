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
        Fisiere initializare = new Fisiere();
        Carnet carnet = initializare.ReadFromFile();
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

    private void MeniuStudent(Carnet carnet)
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
                    Console.WriteLine("4. Salveaza modificarile");
                    Console.WriteLine("5. Inapoi la meniul principal");
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
                            TrimiteSiUrmaresteContestatie(carnet.Discipline);
                            break;
                        case "4":
                            Fisiere salvare = new Fisiere();
                            salvare.WriteToFile(carnet);
                            break;
                        case "5":
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

    private void MeniuAdministrator(Carnet carnet, CalculatorMedieAnualaSiMulti calcMedie)
    {
            while (true)
            {
                try
                {


                    Console.Clear();
                    Console.WriteLine("\n--- Meniu Administrator ---");
                    Console.WriteLine("1. Calculeaza media la disciplina");
                    Console.WriteLine("2. Publica note");
                    Console.WriteLine("3. Salveaza modificarile");
                    Console.WriteLine("4. Raspunde la contestatii");
                    Console.WriteLine("5. Inapoi la meniul principal");
                    Console.Write("Alege o optiune: ");

                    switch (Console.ReadLine())
                    {
                        case "1":
                            CalculeazaMedii(carnet, calcMedie);
                            break;
                        case "2":
                            PublicaNoteAdministrator(carnet.Discipline);
                            break;
                        case "3" :
                            Fisiere salvare = new Fisiere();
                            salvare.WriteToFile(carnet);
                            break;
                        case "4":
                            Contestatii(carnet.Discipline);
                            break;
                        case "5":
                            return;
                        default:
                            Console.WriteLine("Optiune invalida. Incercati din nou.");
                            Console.ReadKey();
                            break;
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogWarning(ex, "A aparut o eroare in meniul administrator.");
                }
            }
    }

    private void VizualizeazaNoteStudent(Carnet carnet)
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

    private void InroleazaStudentLaDisciplina(Carnet carnet)
    {
        try
        {   
            Console.WriteLine("Introduceti tipul disciplinei (1-optionala/2-facultativa): ");
            int tipDisciplina = int.Parse(Console.ReadLine());
            switch (tipDisciplina)
            {
                case 1:
                    Console.WriteLine("Discipline optionale:");
                    foreach (var disciplina in carnet.DisciplineOptionale)
                    {
                        Console.WriteLine($"Nume: {disciplina.Nume}, Semestru: {disciplina.Semestru}, An: {disciplina.An}");
                    }
                    Console.Write("Introduceti numele disciplinei: ");
                    string nume = Console.ReadLine();
                    
                    var optionala = new DisciplinaOptionala(carnet.DisciplineOptionale.Where(i=>i.Nume==nume).FirstOrDefault().Nume, 
                        carnet.DisciplineOptionale.Where(i=>i.Nume==nume).FirstOrDefault().Semestru, 
                        carnet.DisciplineOptionale.Where(i=>i.Nume==nume).FirstOrDefault().An);
                    if (carnet.Discipline.Contains(optionala))
                    {
                        Console.WriteLine("Deja te-ai inrolat la aceasta disciplina!");
                        Console.ReadKey();
                        return;
                    }
                    if (optionala == null)
                    {
                        Console.WriteLine("Disciplina nu a fost gasita.");
                        Console.ReadKey();
                        return;
                    }
                    carnet.Discipline.Add(optionala);
                    break;
                case 2:
                    Console.WriteLine("Discipline facultative:");
                    foreach (var disciplina in carnet.DisciplineFacultative)
                    {
                        Console.WriteLine($"Nume: {disciplina.Nume}, Semestru: {disciplina.Semestru}, An: {disciplina.An}");
                    }
                    Console.Write("Introduceti numele disciplinei: ");
                    string numeFacultativa = Console.ReadLine();
                    
                    var facultativa = new DisciplinaOptionala(carnet.DisciplineFacultative.Where(i=>i.Nume==numeFacultativa).FirstOrDefault().Nume, 
                        carnet.DisciplineFacultative.Where(i=>i.Nume==numeFacultativa).FirstOrDefault().Semestru, 
                        carnet.DisciplineFacultative.Where(i=>i.Nume==numeFacultativa).FirstOrDefault().An);
                    if (carnet.Discipline.Contains(facultativa))
                    {
                        Console.WriteLine("Deja te-ai inrolat la aceasta disciplina!");
                        Console.ReadKey();
                        return;
                    }
                    if (facultativa == null)
                    {
                        Console.WriteLine("Disciplina nu a fost gasita.");
                        Console.ReadKey();
                        return;
                    }
                    carnet.Discipline.Add(facultativa);
                    break;
                default:
                    Console.WriteLine("Tip de disciplina invalid.");
                    Console.ReadKey();
                    return;
            }
            

            Console.WriteLine("Studentul a fost inrolat la disciplina.");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Eroare la inrolarea studentului la disciplina.");
        }
    }

    private void TrimiteSiUrmaresteContestatie(List<Disciplina> discipline)
    {
        try
        {
            Console.WriteLine("1.Trimite contenstatie");
            Console.WriteLine("2.Urmareste contenstatii");
            string choice=Console.ReadLine();
            switch(choice)
            {
                case "1":
                Console.Write("Introduceti numele disciplinei: ");
                string nume = Console.ReadLine();
                var disciplina = discipline.FirstOrDefault(d => d.Nume == nume);

                if (disciplina == null)
                {
                    Console.WriteLine("Disciplina nu a fost gasita.");
                    Console.ReadKey();
                    return;
                }

                var notaContestata = disciplina.Note.Min(nota => nota.Valoare);
                var contestatie = new Contestatie(notaContestata);
                disciplina.Note.Remove(contestatie);
                discipline.Where(i=>i.Nume==nume).FirstOrDefault().AdaugaNota(contestatie);
                break;
                case "2": 
                    Console.Write("Introduceti numele disciplinei: "); 
                    string numeDisciplina = Console.ReadLine();
                    if (!(discipline.Where(i => i.Nume == numeDisciplina).FirstOrDefault().Note.Last() is Contestatie))
                    {
                        Console.WriteLine("Aceasta disciplina nu are contestatii.");
                        return;
                    }
                    else
                    {
                        Contestatie disciplinaContestata = (Contestatie)(discipline.Where(i => i.Nume == numeDisciplina).FirstOrDefault().Note.Last());
                        if(disciplinaContestata.StareContestatie=="In asteptare")
                            Console.WriteLine(disciplinaContestata.StareContestatie);
                        else
                            Console.WriteLine($"Nota dupa contestatie: {disciplinaContestata.NotaDupaContestatie}");
                            
                    }
                    break;
            }
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Eroare la gestionarea contestatiei.");
        }
    }

    private void CalculeazaMedii(Carnet carnet, CalculatorMedieAnualaSiMulti calcMedie)
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

    private void Contestatii(List<Disciplina> discipline)
    {
        Console.WriteLine("Introdu numele disciplinei pentru a verifica contestatiile: ");
        string numeDisciplina = Console.ReadLine();
        try
        {
            if (!(discipline.Where(i => i.Nume == numeDisciplina).FirstOrDefault().Note.Last() is Contestatie))
            {
                Console.WriteLine("Aceasta disciplina nu are contestatii.");
                return;
            }
            else
            {
                Contestatie disciplinaContestata =
                    (Contestatie)(discipline.Where(i => i.Nume == numeDisciplina).FirstOrDefault().Note.Last());
                Console.WriteLine("Introdu nota actualizata: ");
                float nota = float.Parse(Console.ReadLine());
                if (disciplinaContestata.Validare(disciplinaContestata.NotaDupaContestatie))
                    disciplinaContestata.ActualizeazaNota(nota, "Contestatie verificata");
                else
                    Console.WriteLine("Valoare invalida!");
            }
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex.Message);
        }
    }
    
    private void PublicaNoteAdministrator(List<Disciplina> discipline)
    {
        try
        {
            foreach (var disciplina in discipline)
            {
                Console.WriteLine($"Nume: {disciplina.Nume}, Semestru: {disciplina.Semestru}, An: {disciplina.An}");
            }
            Console.Write("Introduceti numele disciplinei: ");
            string nume = Console.ReadLine();
            Console.WriteLine("Introduceti tipul de nota (1-activitate/2-examen");
            string tip = Console.ReadLine();
            switch (tip)
            { 
                case "1": 
                    while (true) 
                    { 
                        Console.WriteLine("Introduceti nota(introduceti 0 pentru a iesi): ");
                        float nota = float.Parse(Console.ReadLine());
                        if (nota == 0)
                            return;
                        Nota notaActivitate = new NotaActivitate(nota);
                        if (notaActivitate.Validare(notaActivitate.Valoare))
                        {
                            discipline.Where(i=>i.Nume==nume).FirstOrDefault().AdaugaNota(notaActivitate);
                        }
                        else
                            Console.WriteLine("Nota invalida!");
                    }
                case "2":
                    if (discipline.Where(i => i.Nume == nume).FirstOrDefault().Note.OfType<NotaExamen>().Count() != 0)
                    {
                        Console.WriteLine("Disciplina are deja nota pentru examen!");
                        break;
                    }
                    Console.WriteLine("Introduceti nota: "); 
                    float notaExamen = float.Parse(Console.ReadLine());
                    if (notaExamen == 0) 
                        return;
                    Nota notaEx = new NotaExamen(notaExamen);
                    if (notaEx.Validare(notaEx.Valoare))
                    {
                        discipline.Where(i => i.Nume == nume).FirstOrDefault().AdaugaNota(notaEx);
                    }
                    else
                        Console.WriteLine("Nota invalida!");
                    break;
                default:
                    Console.WriteLine("Optiune invalida!");
                    break;
                }
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            _logger.LogWarning(ex, "Eroare la publicarea notelor.");
        }
    }
}

    