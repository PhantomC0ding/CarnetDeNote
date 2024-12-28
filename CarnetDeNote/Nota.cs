namespace CarnetDeNote;

public abstract class Nota<T> where T: IComparable
{
    protected T nota { get; set; }
    public Nota(T nota)
    {
        this.nota = nota;
    }

    protected virtual bool Validare(T nota)
    {
        return (nota.CompareTo(1)>=0) && (nota.CompareTo(10)<=0);
    }
}