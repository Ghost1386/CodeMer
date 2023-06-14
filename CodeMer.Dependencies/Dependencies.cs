using CodeMer.BusinessLogic.Interfaces;
using CodeMer.BusinessLogic.Services;
using CodeMer.BusinessLogicTests;
using Microsoft.Extensions.DependencyInjection;

namespace CodeMer.Dependencies;

public static class Dependencies
{
    public static void AddIService(this IServiceCollection services)
    {
        services.AddTransient<Tests>();
        services.AddTransient<IAdminService, AdminService>();
        services.AddTransient<IAuthService, AuthService>();
        services.AddScoped<ICompilerService, CompilerService>();
        services.AddTransient<IEmailService, EmailService>();
        services.AddTransient<IGeneratorService, GeneratorService>();
        services.AddTransient<IProblemFinishService, ProblemFinishService>();
        services.AddTransient<IProblemService, ProblemService>();
        services.AddTransient<IUserService, UserService>();
        
        services.AddScoped<FileSystemWatcher>();
    }
}