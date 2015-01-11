using System;
using SemanticTypes;

namespace SemanticTypes.SemanticTypeExamples
{
    public class BirthDate : SemanticType<DateTime>
    {
        // Oldest person ever died at 122 year and 164 days
        // http://en.wikipedia.org/wiki/List_of_the_verified_oldest_people
        // To be safe, reject any age over 130 years.
        const int maxAgeForHumans = 130;
        const int daysPerYear = 365;

        public static bool IsValid(DateTime birthDate)
        {
            TimeSpan age = DateTime.Now - birthDate;
            return (age.TotalDays >= 0) && (age.TotalDays < daysPerYear * maxAgeForHumans);
        }

        public BirthDate(DateTime birthDate) : base(IsValid, typeof(BirthDate), birthDate) { }

        public static explicit operator DateTime(BirthDate value)
        {
            return value.Value;
        }

        public static implicit operator BirthDate(DateTime value)
        {
            return new BirthDate(value);
        }

    }
}
