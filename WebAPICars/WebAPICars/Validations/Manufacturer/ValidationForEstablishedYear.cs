﻿using System.ComponentModel.DataAnnotations;

namespace WebAPICars.Validations.Manufacturer
{
    public class ValidationForEstablishedYear : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is int establishedYear)
            {

                int currentYear = DateTime.Now.Year;

                if(establishedYear < 0)
                {
                    return new ValidationResult("Year cannot be negative");
                }


                if (establishedYear > currentYear)
                {
                    return new ValidationResult($"Year cannot be greater than {currentYear}.");
                }
            }

            return ValidationResult.Success;
        }


    }
}
