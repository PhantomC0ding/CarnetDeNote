namespace CarnetDeNote;

public abstract class Nota
{
    public float nota { get; private set; }
    public Nota(float nota)
    {
        this.nota = nota;
    }

    protected virtual bool Validare(float nota)
    {
        return nota>=1 && nota<=10;
    }
}