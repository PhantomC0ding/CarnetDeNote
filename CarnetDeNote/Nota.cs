namespace CarnetDeNote;
public class Nota
{
    public float Valoare { get; private set; }

    public Nota(float valoare)
    {
<<<<<<< HEAD
        if (valoare < 1 || valoare > 10)
            throw new ArgumentException("Nota trebuie sa fie intre 1 si 10.");
        Valoare = valoare;
=======
        this.nota = nota;
    }

    protected virtual bool Validare(float nota)
    {
        return nota>=1 && nota<=10;
>>>>>>> 075d2d7db751e6ad3695e02d2625596414cdd20c
    }
}