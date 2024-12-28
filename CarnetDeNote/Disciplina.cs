public abstract class Disciplina
{
    protected string Nume { get; set; }
    protected int Semestru { get; set; }
    protected int An { get; set; }
    protected int Medie { get; set; }

    public Disciplina(string nume, int semestru, int an)
    {
        if (string.IsNullOrWhiteSpace(nume))
        {
            throw new ArgumentException("Numele disciplinei nu poate fi gol.");
        }
        if (semestru < 1 || semestru > 2)
        {
            throw new ArgumentException("Semestrul trebuie să fie 1 sau 2.");
        }
        if (an < 1)
        {
            throw new ArgumentException("Anul trebuie să fie cel puțin 1.");
        }

        Nume = nume;
        Semestru = semestru;
        An = an;
    }
}