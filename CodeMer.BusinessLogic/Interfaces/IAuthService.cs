using CodeMer.Common.DTO.AuthDto;

namespace CodeMer.BusinessLogic.Interfaces;

public interface IAuthService
{
    string Login(AuthUserDto authUserDto);

    void Registration(RegistrationUserDto registrationUserDto);
}