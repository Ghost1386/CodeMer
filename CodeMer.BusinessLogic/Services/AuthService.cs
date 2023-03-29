using AutoMapper;
using CodeMer.BusinessLogic.Interfaces;
using CodeMer.Common.DTO.AuthDto;
using CodeMer.Common.Enums;
using CodeMer.Models.Models;

namespace CodeMer.BusinessLogic.Services;

public class AuthService : IAuthService
{
    private readonly IMapper _mapper;
    private readonly IUserService _userService;
    private readonly IGeneratorService _generatorService;
    private readonly IEmailService _emailService;

    public AuthService(IMapper mapper, IUserService userService, 
        IGeneratorService generatorService, IEmailService emailService)
    {
        _mapper = mapper;
        _userService = userService;
        _generatorService = generatorService;
        _emailService = emailService;
    }

    public bool Login(AuthUserDto authUserDto, out User user)
    {
        user = new User();

        var checkUser = _userService.Get(authUserDto.Email, authUserDto.Password);

        if (checkUser != null)
        {
            user = checkUser;

            return true;
        }

        return false;
    }

    public bool Registration(RegistrationUserDto registrationUserDto)
    {
        var usersCheckEmail = _userService.CheckEmail(registrationUserDto.Email);

        if (!usersCheckEmail)
        {
            var user = _mapper.Map<RegistrationUserDto, User>(registrationUserDto);

            user.Role = (int)Role.User;

            var password = _generatorService.Generator(8, 0);

            _emailService.RegistrationBody(registrationUserDto, password);
            
            user.Password = password;
            
            _userService.Create(user);

            return true;
        }

        return false;
    }

    public void ResetPassword(ResetPasswordUserDto resetPasswordUserDto)
    {
        var user = _userService.Get(resetPasswordUserDto.Email);
        
        if (user != null)
        {
            var newPassword = _generatorService.Generator(8, 0);
            
            _emailService.ResetPasswordBody(resetPasswordUserDto, newPassword);
            
            _userService.ResetPassword(user);
        }
    }
}