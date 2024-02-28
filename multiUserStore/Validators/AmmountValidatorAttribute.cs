using System.ComponentModel.DataAnnotations;

namespace multiUserStore.Validators
{
    public class AmmountValidatorAttribute: ValidationAttribute
    {
        private readonly string _otherPropertyName;

        public AmmountValidatorAttribute(string otherPropertyName)
        {
            _otherPropertyName = otherPropertyName;
        }




        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var otherPropertyInfo = validationContext.ObjectType.GetProperty(_otherPropertyName);
            if (otherPropertyInfo == null)
            {
                return new ValidationResult($"Unknown property: {_otherPropertyName}");
            }

            var otherPropertyValue = (float)otherPropertyInfo.GetValue(validationContext.ObjectInstance);
            var quantity = (float)value;

            if (Math.Abs(quantity * otherPropertyValue - (float)validationContext.ObjectInstance.GetType().GetProperty("amount").GetValue(validationContext.ObjectInstance)) > 0.0001)
            {
                return new ValidationResult(ErrorMessage ?? $"The amount should be equal to the product of {validationContext.MemberName} and {_otherPropertyName}.");
            }

            return ValidationResult.Success;
        }
    }
}
