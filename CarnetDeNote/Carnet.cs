namespace CarnetDeNote;

public class Carnet
{
    public List<Disciplina> Discipline= new List<Disciplina>();
    public void AdaugaDisciplina(Disciplina disciplina)
        {
            Discipline.Add(disciplina);
        }
    public void VizualizeazaNote() 
    { 
        foreach (var disciplina in Discipline) 
        { 
            disciplina.PublicaNote();
        }
    }
    public float CalculeazaMedieAnuala(int an)
    {
        var medii = Discipline.Where(d => d.An == an).Select(d => d.Medie);
        return medii.Any() ? medii.Average() : 0;
    } 
}
