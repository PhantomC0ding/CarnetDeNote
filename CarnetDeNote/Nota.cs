namespace CarnetDeNote;

public abstract class Nota
{
    public float nota { get; private set; }
    public Nota(float nota)
    {
        if (!Validare(nota))
            throw new ArgumentException("Nota trebuie să fie între 1 și 10.");
        this.nota = nota;
    }

    protected virtual bool Validare(float nota)
    {
        return nota >= 1 && nota <= 10;
    }
}