namespace CarnetDeNote;

public class Contestatie
{
    public Nota NotaContestata { get; private set; }
    public string Stare { get; private set; } = "În așteptare";

    public Contestatie(Nota nota)
    {
        NotaContestata = nota;
    }

    public void Rezolva(string rezultat)
    {
        Stare = rezultat;
    }

}