using CodeMer.Common.DTO.AuthDto;
using CodeMer.Models.Models;

namespace CodeMer.BusinessLogic.Interfaces;

public interface IAuthService
{
    bool Login(AuthUserDto authUserDto, out User user);

    bool Registration(RegistrationUserDto registrationUserDto);
}