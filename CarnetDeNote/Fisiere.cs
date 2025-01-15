using System.Text.Json;
namespace CarnetDeNote;

public class Fisiere
{

    
    public void WriteToFile(Carnet text)
    {
        string basePath = AppDomain.CurrentDomain.BaseDirectory;
        string filePath = Path.Combine(basePath, "DisciplineCarnet.txt");
        File.WriteAllText(filePath, string.Empty);
        foreach (var disciplina in text.Discipline)
        {
            string json = JsonSerializer.Serialize(disciplina);
            File.AppendAllText(filePath, json);
        }
    }
    
    public Carnet ReadFromFile()
    {
        string basePath = AppDomain.CurrentDomain.BaseDirectory;
        string filePath = Path.Combine(basePath, "DisciplineCarnet.txt");
        if (!File.Exists(filePath))
        {
            return new Carnet();
        }
        if (filePath != null)
        {
            string json = File.ReadAllText(filePath);
            List<Disciplina> discipline = JsonSerializer.Deserialize<List<Disciplina>>(json);
            Carnet carnet = new Carnet();
            carnet.Discipline = discipline;
            return carnet;
        }
        return new Carnet();
    }
}