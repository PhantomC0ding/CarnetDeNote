using CarnetDeNote;
public abstract class Disciplina
    {
        public string Nume { get; protected set; }
        public int Semestru { get; protected set; }
        public int An { get; private set; }
        public List<Nota> Note { get; private set; }
        public float Medie { get; set; }

        public Disciplina(string nume, int semestru, int an)
        {
            if (string.IsNullOrWhiteSpace(nume))
                throw new ArgumentException("Numele disciplinei nu poate fi gol.");
            if (semestru < 1 || semestru > 2)
                throw new ArgumentException("Semestrul trebuie să fie 1 sau 2.");
            if (an < 1)
                throw new ArgumentException("Anul trebuie să fie cel puțin 1.");

            Nume = nume;
            Semestru = semestru;
            An = an;
            Note = new List<Nota>();
        }

        public void AdaugaNota(Nota nota)
        {
            if (nota == null)
                throw new ArgumentNullException(nameof(nota));
            Note.Add(nota);
        }

        public void CalculeazaMedie()
        {
            var activitate = Note.OfType<NotaActivitate>().Sum(n => n.nota);
            var examen = Note.OfType<NotaExamen>().Sum(n => n.nota);
            Medie = (examen * 2 + activitate) / 3;
        }

        public void PublicaNote()
        {
            Console.WriteLine($"Disciplină: {Nume} (An: {An}, Semestru: {Semestru})");
            foreach (var nota in Note)
            {
                Console.WriteLine($"Nota: {nota.nota}");
            }
        }
    }