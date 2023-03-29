using CodeMer.Models.Models;

namespace CodeMer.BusinessLogic.Interfaces;

public interface IMentorService
{
    public bool Verify(string key);
    
    string Create(User user);
}