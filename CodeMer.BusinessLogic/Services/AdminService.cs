using CodeMer.BusinessLogic.Interfaces;
using CodeMer.Common.Enums;
using CodeMer.Models;
using CodeMer.Models.Models;

namespace CodeMer.BusinessLogic.Services;

public class AdminService : IAdminService
{
    private readonly ApplicationContext _applicationContext;
    private readonly IGeneratorService _generatorService;

    public AdminService(ApplicationContext applicationContext, IGeneratorService generatorService)
    {
        _applicationContext = applicationContext;
        _generatorService = generatorService;
    }

    public bool Verify(string key)
    {
        var check = _applicationContext.Admins.Any(admin => admin.Key == key);

        return check;
    }

    public string Create(User user)
    {
        var key = _generatorService.Generator(8, 1);
        
        var admin = new Admin
        {
            Key = key,
            UserId = user.Id,
            User = user,
            Role = (int)Role.Admin
        };

        _applicationContext.Admins.Add(admin);
        _applicationContext.SaveChanges();

        return key;
    }
}