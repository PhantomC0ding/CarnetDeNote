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
        float activitate = disciplina.Note
            .OfType<NotaActivitate>() 
            .Sum(n => n.Valoare); 
        activitate=activitate/disciplina.Note.OfType<NotaActivitate>().Count();
        float examen = disciplina.Note
            .OfType<NotaExamen>() 
            .Sum(n => n.Valoare);
        if(examen != 0 && activitate != 0)
            disciplina.Medie = (int)Math.Round((examen * 2 + activitate) / 3);
        else
            Console.WriteLine("Materia nu este incheiata!");
    }
}