using CodeMer.Models.Models;

namespace CodeMer.BusinessLogic.Interfaces;

public interface IAdminService
{
    public bool Verify(string key);
    
    string Create(User user);
}