using System.ComponentModel.DataAnnotations;

namespace MedRouter.Core.DTOs;

public class RegisterRequest
{
    [Required]
    public string Name { get; set; }

    [Required]
    [EmailAddress]
    public string Mail { get; set; }
    
    [Required]
    [MinLength(6)]
    public string Password { get; set; }

    [Required]
    [Compare("Password")]
    public string ConfirmPassword { get; set; }
    
}