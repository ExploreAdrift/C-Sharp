#pragma warning disable CS8618
namespace WeddingPlanner.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;



// Wont create a new table for LoginUser
[NotMapped]
public class UserLogin
{
    [Required(ErrorMessage = "You must enter your email!")]
    [EmailAddress]
    [Display(Name = "Email:")]

    public string LoginEmail { get; set; }


    [Required(ErrorMessage = "You must enter your password!")]
    [DataType(DataType.Password)]
    [Display(Name = "Password:")]
    [MinLength(8, ErrorMessage = "Password must be 8 characters or longer!")]
    public string LoginPassword { get; set; }



}