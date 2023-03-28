using System.Text;
using CodeMer.BusinessLogic.Interfaces;

namespace CodeMer.BusinessLogic.Services;

public class GeneratorService : IGeneratorService
{
    private const string LettersAndNumbers = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
    private const string Numbers = "1234567890";
    
    public string Generator(int length, int type)
    {
        string valid = type == 0 ? LettersAndNumbers : Numbers;

        var result = new StringBuilder();
        var rnd = new Random();
                
        while (0 < length--)
        {
            result.Append(valid[rnd.Next(valid.Length)]);
        }
                
        return result.ToString();
    }
}