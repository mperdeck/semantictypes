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
        static BirthDate()
        {
            InvalidMessage = "Birth date must be in the past and less than 130 years ago.";
            IsValid = v => {
                        TimeSpan age = DateTime.Now - v;
                        return (age.TotalDays >= 0) && (age.TotalDays < 365 * 130);
                    };
        }

        public BirthDate(DateTime birthDate)
            : base(birthDate)
        {
        }
    }
}
