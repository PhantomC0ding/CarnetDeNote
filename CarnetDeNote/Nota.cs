namespace CarnetDeNote;
public class Nota
{
    public float Valoare { get; private set; }

    public Nota(float valoare)
    {
        if (valoare < 1 || valoare > 10)
            throw new ArgumentException("Nota trebuie sa fie intre 1 si 10.");
        Valoare = valoare;
    }
}