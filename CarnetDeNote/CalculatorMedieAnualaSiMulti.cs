namespace CarnetDeNote;

public class CalculatorMedieAnualaSiMulti
{
    private readonly CalculatorMedieDisciplina calc = new CalculatorMedieDisciplina();

    public int CalculeazaMedieAnuala(List<Disciplina> discipline, int an, bool includeFacultative = false)
    {
        var disciplineRelevante = discipline.Where(d => (includeFacultative || !(d is DisciplinaFacultativa)) && d.An == an)
            .ToList();
        
        disciplineRelevante.ForEach(d => calc.MedieDisciplina(d));
        
        return disciplineRelevante.Any() ? (int)Math.Round(disciplineRelevante.Average(d => d.Medie)) : 0;
    }

    public int CalculeazaMedieMultianuala(List<Disciplina> discipline, bool includeFacultative = false)
    {
        var disciplineRelevante = discipline.Where(d => includeFacultative || !(d is DisciplinaFacultativa)).ToList();
        
        disciplineRelevante.ForEach(d => calc.MedieDisciplina(d));
        
        return disciplineRelevante.Any() ? (int)Math.Round(disciplineRelevante.Average(d => d.Medie)) : 0;
    }
}