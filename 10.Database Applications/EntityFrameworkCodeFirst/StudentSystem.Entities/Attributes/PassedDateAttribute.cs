namespace StudentSystem.Entities.Attributes
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class PassedDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime d = Convert.ToDateTime(value);
            return d <= DateTime.Now;
        }
    }
}
