namespace CarnetDeNote;

public class CalculatorMedieDisciplina
{
    public void MedieDisciplina(Disciplina disciplina)
    {
        float activitate=0;
        float examen=0;
        foreach (Nota grade in disciplina.note)
        {
            if (grade is NotaActivitate)
                activitate += grade.nota;
            if(grade is NotaExamen)
                examen += grade.nota;
        }
        disciplina.Medie = (int)Math.Round((examen*2+activitate)/3);
    }
}