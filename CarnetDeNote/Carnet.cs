namespace CarnetDeNote;

public class Carnet
{
    public List<Disciplina> Discipline { get; private set; }

    public Carnet()
    {
        Discipline = new List<Disciplina>();
    }
}