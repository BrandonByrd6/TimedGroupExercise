using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TGE.Data.Entities;

public class UserEntity : IdentityUser<int>
{
    public int Id {get; set;}
    [Required]
    public string Email {get; set; } = string.Empty;

    [MaxLength(100)]
    public string? FirstName {get; set;} = string.Empty;
    [MaxLength(100)]
    public string? LastName {get; set;} = string.Empty;
    public DateTime DateCreated {get; set;}
}