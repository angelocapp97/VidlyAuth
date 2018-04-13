using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VidlyAuth.Models
{
    public class CustomDateTimeValid : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var user = (RegisterViewModel)validationContext.ObjectInstance;

            var today = DateTime.Today;
            var birthdate = user.Birthdate;
            var age = today.Year - birthdate.Year;

            // Go back to the year the person was born in case of a leap year
            if (birthdate > today.AddYears(-age)) age--;

            if (age < 0)
                return new ValidationResult("Birthdate cannot exceed today's date.");

            return ValidationResult.Success;
        }
    }
}