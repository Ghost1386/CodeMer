using CodeMer.Models.Models;

namespace CodeMer.BusinessLogic.Interfaces;

public interface IUserService
{
    void Create(User user);
    
    User Get(string email, string password);

    bool CheckEmail(string email);
}