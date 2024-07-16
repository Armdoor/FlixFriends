using System.ComponentModel.DataAnnotations;

namespace FlixFriends.Dtos;

public class EmailOrUsernameRequiredAttribute: ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var loginDto = (LoginDto)validationContext.ObjectInstance;

        if (string.IsNullOrWhiteSpace(loginDto.Email) && string.IsNullOrWhiteSpace(loginDto.Username))
        {
            return new ValidationResult("Either email or username must be provided.");
        }

        return ValidationResult.Success;
    }
}