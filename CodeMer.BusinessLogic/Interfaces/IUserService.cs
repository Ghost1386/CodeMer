using CodeMer.Common.DTO.UserDto;
using CodeMer.Models.Models;

namespace CodeMer.BusinessLogic.Interfaces;

public interface IUserService
{
    void Create(User user);
    
    User Get(string email, string password);

    User Get(string email);

    void ResetPassword(User user);

    bool CheckEmail(string email);

    void ChangeRole(ChangeUserRoleDto changeUserRoleDto);
}