using System.ComponentModel.DataAnnotations;

namespace AIProducts.Shared.Blazor.Models;

public class LoginModel
{
    [MaxLength(30)]
    [Required]
    [Display(Name = "User Name")]
    public string? UserName { get; set; }

    [MaxLength(20)]
    [Required]
    public string? Password { get; set; }
    public string? ClientId { get; set; } = "AIProducts_App";
    public string? GrantType { get; set; } = "password";
    public string? Scope { get; set; } = "AIProducts";
}