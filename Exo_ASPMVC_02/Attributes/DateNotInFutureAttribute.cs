using System.ComponentModel.DataAnnotations;

namespace Exo_ASPMVC_02.Attributes
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter, AllowMultiple = false)]
    public class DateNotInFutureAttribute : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            DateTime? date = value as DateTime?;

            if(date is null)
            {
                return false;
            }

            return date <= DateTime.Today;
        }
    }
}
