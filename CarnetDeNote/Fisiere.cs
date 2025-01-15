using System.Text.Json;
using Newtonsoft.Json;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace CarnetDeNote;

public class Fisiere
{
    public void WriteToFile(Carnet text)
    {
        string basePath = AppDomain.CurrentDomain.BaseDirectory;
        string filePath = Path.Combine(basePath, "DisciplineCarnet.txt");
        string json = JsonConvert.SerializeObject(text.Discipline, new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.All,
            Formatting = Formatting.Indented,
            FloatParseHandling = FloatParseHandling.Double
        });
        File.WriteAllText(filePath, string.Empty);
        File.WriteAllText(filePath, json);
    }
    
    public Carnet ReadFromFile()
    {
        string basePath = AppDomain.CurrentDomain.BaseDirectory;
        string filePath = Path.Combine(basePath, "DisciplineCarnet.txt");
        if (!File.Exists(filePath))
        {
            return new Carnet();
        }
        if (new FileInfo(filePath).Length != 0)
        {
            try
            {
                var json = File.ReadAllText(filePath);
                Carnet carnet = new Carnet();
                carnet.Discipline = JsonConvert.DeserializeObject<List<Disciplina>>(json, new JsonSerializerSettings
                {
                    TypeNameHandling = TypeNameHandling.All,
                    FloatParseHandling = FloatParseHandling.Double
                });
                return carnet;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }
        return new Carnet();
    }
}