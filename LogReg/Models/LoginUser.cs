#pragma warning disable CS8618
namespace LogReg.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;



// Wont create a new table for LoginUser
[NotMapped]
public class LoginUser
{
    [EmailAddress]
    [Required]
    public string LoginEmail { get; set; }


    [DataType(DataType.Password)]
    [Required]
    [MinLength(8, ErrorMessage = "Password must be 8 characters or longer!")]
    public string LoginPassword { get; set; }



}