using System.ComponentModel.DataAnnotations;

namespace AIProducts.Shared.Models;

public class ApplicationUserWithRolesDto : ApplicationUserDto
{
    public List<string>? Roles { get; set; }
}

