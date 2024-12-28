namespace CarnetDeNote;

public class NotaExamen:Nota<int>
{
    public NotaExamen(int Nota) : base(Nota)
    {
    }


    protected override bool Validare(int nota)
    {
        return nota >= 1 && nota <= 10;
    }
}