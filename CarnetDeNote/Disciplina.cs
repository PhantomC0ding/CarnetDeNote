namespace CarnetDeNote;

public abstract class Disciplina
{
    private string Nume;
    private int Semestru;
    private int An;

    public Disciplina(string nume, int semestru, int an)
    {
        Nume = nume;
        Semestru = semestru;
        An = an;
    }
}