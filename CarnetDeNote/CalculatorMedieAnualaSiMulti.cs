namespace CarnetDeNote;

public class CalculatorMedieAnuala
{
    private CalculatorMedieDisciplina calc= new CalculatorMedieDisciplina();

    public int MedieAnuala(List<Disciplina> discipline, bool check,int an)
    {
        int i = 0;
        float average = 0;
        if(check)
        foreach (Disciplina disciplina in discipline)
        {
            if (check)
            {

                if (!(disciplina is DisciplinaFacultativa) && disciplina.An == an)
                {
                    calc.MedieDisciplina(disciplina);
                    i++;
                    average += disciplina.Medie;
                }
            }
            else
            {
                if (!(disciplina is DisciplinaFacultativa))
                {
                    calc.MedieDisciplina(disciplina);
                    i++;
                    average += disciplina.Medie;
                }
            }
        }
        if(average>0)
            return (int)Math.Round(average/i);
        else 
            return 0;
    }
}