namespace CarnetDeNote;

public class Contestație
{
    public Nota NotaContestata { get; private set; }
    public string Stare { get; private set; } = "În așteptare";

    public Contestație(Nota nota)
    {
        NotaContestata = nota;
    }

    public void Rezolva(string rezultat)
    {
        Stare = rezultat;
    }
    ///afiseaza nota dupa contestatie
}