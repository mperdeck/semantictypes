Semantic Types
==============

Semantic Types help you reduce bugs and improve maintainability by letting the compiler ensure consistency in your code.

Install via NuGet:

```PM> Install-Package SemanticTypes```

Example
=======

Here is an example implementation of a Semantic type:

```csharp
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
```

And here is how you might use it:

```csharp
var validBirthDate = DateTime.Now - new TimeSpan(30 * 365, 0, 0, 0); // 30 years ago
var isValid = BirthDate.IsValid(validBirthDate); // True

var invalidBirthDate = DateTime.Now - new TimeSpan(130 * 365, 0, 0, 0); // 130 years ago
var isValid = BirthDate.IsValid(invalidBirthDate); // False
```

