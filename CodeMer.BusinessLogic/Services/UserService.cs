using CodeMer.BusinessLogic.Interfaces;
using CodeMer.Common.DTO.UserDto;
using CodeMer.Common.Enums;
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
    
    public User Get(string email)
    {
        var user = _applicationContext.Users.FirstOrDefault(user => user.Email == email);

        return user;
    }

    public bool CheckEmail(string email)
    {
        var checkUser = _applicationContext.Users.Any(user => user.Email == email);

        return checkUser;
    }

    public void ResetPassword(User user)
    {
        _applicationContext.Users.Update(user);
        _applicationContext.SaveChanges();
    }
    
    public void ChangeRole(ChangeUserRoleDto changeUserRoleDto)
    {
        var user = _applicationContext.Users.FirstOrDefault(user => user.Email == changeUserRoleDto.Email);

        if (user != null)
        {
            user.Role = (int)changeUserRoleDto.NewRole;

            _applicationContext.Users.Update(user);
            
            if (changeUserRoleDto.NewRole == Role.Admin)
            {
                
            }
        }
    }
}