using CodeMer.BusinessLogic.Interfaces;
using CodeMer.Models;
using CodeMer.Models.Models;

namespace CodeMer.BusinessLogic.Services;

public class UserService : IUserService
{
    private readonly ApplicationContext _applicationContext;

    public UserService(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }

    public void Create(User user)
    {
        _applicationContext.Users.Add(user);
        _applicationContext.SaveChanges();
    }

    public User Get(string email, string password)
    {
        var user = _applicationContext.Users.FirstOrDefault(user => user.Email == email 
                                                                    && user.Password == password);

        return user;
    }

    public bool CheckEmail(string email)
    {
        var user = _applicationContext.Users.Any(user => user.Email == email);

        return user;
    }
}