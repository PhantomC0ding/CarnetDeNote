namespace CarnetDeNote;

public class CalculatorMedieDisciplina
{
    public void MedieDisciplina(Disciplina disciplina)
    {
        if (disciplina.Note.Count() == 0)
        {
            disciplina.Medie =0;
            return;
        }
        float activitate = 0;
        activitate = disciplina.Note
            .OfType<NotaActivitate>() 
            .Sum(n => n.Valoare); 
        activitate=activitate/disciplina.Note.OfType<NotaActivitate>().Count();
        float examen = 0;
        examen = disciplina.Note
            .OfType<NotaExamen>() 
            .Sum(n => n.Valoare);
        disciplina.Medie = (int)Math.Round((examen * 2 + activitate) / 3);
    }
}