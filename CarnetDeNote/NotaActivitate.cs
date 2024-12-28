namespace CarnetDeNote;

public class NotaActivitate:Nota<int>
{
    public NotaActivitate(int Nota) : base(Nota)
    {
    }

    protected override bool Validare(int nota)
    {
        return nota >= 1 && nota <= 10;
    }
}