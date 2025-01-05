namespace CarnetDeNote;

public class CalculatorMedieDisciplina
{
    public void MedieDisciplina(Disciplina disciplina)
    {
        float activitate = disciplina.Note
            .OfType<NotaActivitate>() 
            .Sum(n => n.nota); 

        float examen = disciplina.Note
            .OfType<NotaExamen>() 
            .Sum(n => n.nota);

        disciplina.Medie = (int)Math.Round((examen * 2 + activitate) / 3);
    }
}