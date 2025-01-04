namespace CarnetDeNote;

public class CalculatorMedieAnualaSiMulti
{
    private CalculatorMedieDisciplina calc = new CalculatorMedieDisciplina();

    public int MedieAnuala(List<Disciplina> discipline, bool check, int an)
    {
        var disciplineFiltrate = discipline
            .Where(d => !(d is DisciplinaFacultativa) && (!check || d.An == an))
            .ToList();

        foreach (var disciplina in disciplineFiltrate)
        {
            calc.MedieDisciplina(disciplina);
        }

        var average = disciplineFiltrate
            .Where(d => d.Medie > 0)
            .Average(d => d.Medie);

        return average > 0 ? (int)Math.Round(average) : 0;
    }
}
