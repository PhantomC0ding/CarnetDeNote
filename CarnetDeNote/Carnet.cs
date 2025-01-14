namespace CarnetDeNote;

public class Carnet
{
    public List<Disciplina> Discipline { get; set; }
    public List<Disciplina> DisciplineOptionale { get; set; }
    public List<Disciplina> DisciplineFacultative { get; set; }

    public Carnet()
    {
        Discipline = new List<Disciplina>
        {
            new DisciplinaObligatorie("Matematica", 1, 1), 
            new DisciplinaObligatorie("Romana", 1, 1),
            new DisciplinaObligatorie("Istorie", 1, 2), 
            new DisciplinaObligatorie("Geografie", 1, 2),
            new DisciplinaObligatorie("Biologie", 1, 3)
        };
        DisciplineOptionale = new List<Disciplina>
            {
                new DisciplinaOptionala("Informatica", 1, 1),
                new DisciplinaOptionala("Fizica", 2, 3),
                new DisciplinaOptionala("Chimie", 1, 2),
                new DisciplinaOptionala("Sport", 2, 2),
                new DisciplinaOptionala("Muzica", 1, 3)
            };
        DisciplineFacultative = new List<Disciplina>{
                new DisciplinaFacultativa("Desen", 2, 1),
                new DisciplinaFacultativa("Economie", 1, 2),
                new DisciplinaFacultativa("Filosofie", 2, 3),
                new DisciplinaFacultativa("Logica", 2, 3),
                new DisciplinaFacultativa("Psihologie", 2, 3)
            };;
        }
}