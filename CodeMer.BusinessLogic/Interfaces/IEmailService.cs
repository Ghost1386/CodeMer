using CodeMer.Common.DTO.AuthDto;

namespace CodeMer.BusinessLogic.Interfaces;

public interface IEmailService
{
    Task<bool> RegistrationBody(RegistrationUserDto registrationUserDto, string password);
}