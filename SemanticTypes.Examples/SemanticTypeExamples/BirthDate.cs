using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public static implicit operator DateTime(BirthDate t) { return t.Value; }

        // force dev to know that we're going to NonNullable
        public static explicit operator BirthDate(DateTime t) { return new BirthDate(t); }

    }
}
