using System.ComponentModel.DataAnnotations;

namespace Image_upload.Attributes
{
    public class AllowedExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] _allowedExtensions;

        public AllowedExtensionsAttribute(params string[] allowedExtensions)
        {
            _allowedExtensions = allowedExtensions;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                var fileExtension = Path.GetExtension(file.FileName).ToLowerInvariant();

                if (!_allowedExtensions.Contains(fileExtension))
                {
                    return new ValidationResult($"Only {_allowedExtensions} file types are allowed.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
