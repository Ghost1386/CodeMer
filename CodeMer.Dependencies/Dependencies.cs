using CodeMer.BusinessLogic.Interfaces;
using CodeMer.BusinessLogic.Services;
using Microsoft.Extensions.DependencyInjection;

namespace CodeMer.Dependencies;

public static class Dependencies
{
    public static void AddIService(this IServiceCollection services)
    {
        services.AddTransient<IAuthService, AuthService>();
        services.AddTransient<ICompilerService, CompilerService>();
        services.AddTransient<IEmailService, EmailService>();
        services.AddTransient<IGeneratorService, GeneratorService>();
        services.AddTransient<IUserService, UserService>();
    }
}