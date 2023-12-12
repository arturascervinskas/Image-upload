using System.ComponentModel.DataAnnotations;

namespace Image_upload.Attributes
{
    public class MaxFileSizeAttribute : ValidationAttribute
    {
        private readonly long _maxFileSizeInBytes;

        public MaxFileSizeAttribute(long maxFileSizeInBytes)
        {
            _maxFileSizeInBytes = maxFileSizeInBytes;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                if (file.Length > _maxFileSizeInBytes)
                {
                    var maxFileSizeInMB = _maxFileSizeInBytes / (1024 * 1024);
                    return new ValidationResult($"File size should not exceed {maxFileSizeInMB} MB.");
                }
            }

            return ValidationResult.Success;
        }
    }
}
