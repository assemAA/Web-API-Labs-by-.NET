using System.ComponentModel.DataAnnotations;

namespace Cars.Validations
{
    public class DateInPastAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            var date = value as DateTime?;

            if (date == null) return false;

            if (date < DateTime.Now) return true;

            else return false;
        }
    }
}
