namespace CarnetDeNote;

public class NotaExamen<T> : Nota<T> where T: IComparable
{
    public NotaExamen(T nota) : base(nota)
    {
    }
    
}