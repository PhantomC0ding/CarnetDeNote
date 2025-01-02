namespace CarnetDeNote;

public class Contestație : Nota
{
    public float NotaDupaContestatie { get; private set; }
    public string StareContestație { get; private set; }

    public Contestație(float nota, string stareInițială = "În așteptare") : base(nota)
    {
        StareContestație = stareInițială;
        NotaDupaContestatie = nota; 
    }

    public void ActualizeazaNota(float notaNoua, string stare)
    {
        NotaDupaContestatie = notaNoua;
        StareContestație = stare;
    }
}