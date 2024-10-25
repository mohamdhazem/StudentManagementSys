using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace MvcDay2Task.Models
{
    public class UniqueAttribute : ValidationAttribute
    {
        private readonly Context context;

        public UniqueAttribute(Context context) 
        {
            this.context = context;
        }
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return null;
            string name = value.ToString();
            Course crs = context.courses.FirstOrDefault(c => c.name == name);
            if (crs == null)
                return ValidationResult.Success;
            return new ValidationResult("The name is not unique");
        }

    }
}
