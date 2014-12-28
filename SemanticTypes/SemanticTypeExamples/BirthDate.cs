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
        //
        // Note that validation info must be set in the static constructor, so other code
        // can call the static BirthDate.IsValid method to check if a given DateTime is a valid
        // birth date.
        static BirthDate()
        {
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
