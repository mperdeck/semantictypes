using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SemanticTypes.SemanticTypeExamples
{
    public class BirthDate : SemanticType<DateTime, BirthDate>
    {
        // Oldest person ever died at 122 year and 164 days
        // http://en.wikipedia.org/wiki/List_of_the_verified_oldest_people
        // To be safe, reject any age over 130 years.
        const int maxAgeForHumans = 130;
        const int daysPerYear = 365;

        static BirthDate()
        {
            IsValid = birthDate => {
                        TimeSpan age = DateTime.Now - birthDate;
                        return (age.TotalDays >= 0) && (age.TotalDays < daysPerYear * maxAgeForHumans);
                    };
        }

        public BirthDate(DateTime birthDate) : base(birthDate) { }
    }
}
