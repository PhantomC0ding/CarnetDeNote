namespace CarnetDeNote;

public abstract class Nota<T>
{
    protected T nota { get; set; }
    public Nota(T Nota)
    {
        Nota = nota;
    }
    protected abstract bool Validare(T nota);
}