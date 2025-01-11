namespace CarnetDeNote;

public class Contestatie : Nota
{
    public float NotaDupaContestatie { get; private set; }
    public string StareContestatie { get; private set; }

    public Contestatie(float nota, string stareInitiala = "In asteptare") : base(nota)
    {
        StareContestatie = stareInitiala;
        NotaDupaContestatie = nota; 
    }

    public void ActualizeazaNota(float notaNoua, string stare)
    {
        NotaDupaContestatie = notaNoua;
        StareContestatie = stare;
    }
}