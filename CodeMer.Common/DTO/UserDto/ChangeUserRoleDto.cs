using CodeMer.Common.Enums;

namespace CodeMer.Common.DTO.UserDto;

public class ChangeUserRoleDto
{
    public string Email { get; set; }
    
    public Role NewRole { get; set; }
}