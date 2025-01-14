namespace CarnetDeNote;
public abstract class Nota
{
    public float Valoare { get; private set; }
    public Nota(float nota)
    {
        this.Valoare = nota;
    }

    protected virtual bool Validare(float nota)
    {
        return nota >= 1 && nota <= 10;
    }
}