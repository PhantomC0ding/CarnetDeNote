using System.Runtime.InteropServices.JavaScript;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CarnetDeNote;

public class MeniuInteractiv : IMeniuInteractiv
{
    private readonly ILogger<MeniuInteractiv> _logger;
    private readonly IConfiguration _configuration;

    public MeniuInteractiv(ILogger<MeniuInteractiv> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }
    //sa fie completat mai departe, aici e test
    public void Execute()
    {
        while (true)
        {
            switch (Console.ReadLine())
            {
                case "1": Console.WriteLine("Test");
                    break;
                case "2":
                    try
                    {
                        int number = int.TryParse(Console.ReadLine(), out int result) ? result : 0;
                        Console.WriteLine(10 / number);
                    }
                    catch (Exception ex)
                    {
                        _logger.LogWarning($"Invalid number: {ex.Message}");
                    }

                    break;
                default: return;
            }
        }
    }
}