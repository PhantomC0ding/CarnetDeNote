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
    
}
