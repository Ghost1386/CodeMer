using System.Text;
using CodeMer.BusinessLogic.Interfaces;

namespace CodeMer.BusinessLogic.Services;

public class GeneratorService : IGeneratorService
{
    private const string Valid = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";
    
    public string Generator(int length)
    {
        var result = new StringBuilder();
        var rnd = new Random();
                
        while (0 < length--)
        {
            result.Append(Valid[rnd.Next(Valid.Length)]);
        }
                
        return result.ToString();
    }
}