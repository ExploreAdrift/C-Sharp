using System.ComponentModel.DataAnnotations;
namespace dateval.Models;






public class NewDate
{
    [Required]
    [FutureDate]

    public DateTime subDate { get; set; }
}
public class FutureDateAttribute : ValidationAttribute
{

    protected override ValidationResult IsValid(DateTime value, ValidationContext validationContext)
    {
        DateTime thisDay = DateTime.Today;
        DateTime comp = value;
        int result = DateTime.Compare(value, thisDay);

        if (result > 0)
        {
            return new ValidationResult("No Future Bro");
        }
    }

}

