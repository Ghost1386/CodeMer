using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AutoMapper;
using CodeMer.BusinessLogic.Interfaces;
using CodeMer.Common.DTO.AuthDto;
using CodeMer.Models.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace CodeMer.BusinessLogic.Services;

public class AuthService : IAuthService
{
    private readonly string? _jwtSubject;
    private readonly string? _jwtKey;
    private readonly string? _jwtIssuer;
    private readonly string? _jwtAudience;
    
    private readonly IMapper _mapper;
    private readonly IUserService _userService;
    private readonly IGeneratorService _generatorService;
    private readonly IEmailService _emailService;

    public AuthService(IConfiguration configuration, IMapper mapper, IUserService userService, 
        IGeneratorService generatorService, IEmailService emailService)
    {
        _mapper = mapper;
        _userService = userService;
        _generatorService = generatorService;
        _emailService = emailService;

        _jwtSubject = configuration["Jwt:Subject"];
        _jwtKey = configuration["Jwt:Key"];
        _jwtIssuer = configuration["Jwt:Issuer"];
        _jwtAudience = configuration["Jwt:Audience"];
    }
    
    public string Login(AuthUserDto authUserDto)
    {
        var user = _userService.Get(authUserDto.Email, authUserDto.Password);
        
        if (user != null)
        {
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, _jwtSubject),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(CultureInfo.CurrentCulture)),
                new Claim("Email", user.Email),
                new Claim("Password", user.Password)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtKey));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
                _jwtIssuer,
                _jwtAudience,
                claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: signIn);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        return string.Empty;
    }
    

    public void Registration(RegistrationUserDto registrationUserDto)
    {
        var check = _userService.CheckEmail(registrationUserDto.Email);

        if (!check)
        {
            var user = _mapper.Map<RegistrationUserDto, User>(registrationUserDto);

            var password = _generatorService.Generator(8);

            user.Password = password;

            var sendEmail = _emailService.RegistrationBody(registrationUserDto, password);

            if (sendEmail.Result)
            {
                _userService.Create(user);
            }
        }
    }
}