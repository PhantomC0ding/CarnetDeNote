namespace CarnetDeNote;

public class NotaActivitate<T> : Nota<T> where T: IComparable
{
    public NotaActivitate(T nota) : base(nota)
    {
    }
    
}