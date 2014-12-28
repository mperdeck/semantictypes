using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace SemanticTypes.SemanticTypeExamples
{
    public class EmailAddress : SemanticType<string, EmailAddress>
    {
        static EmailAddress()
        {
            // Set IsValid (inherited from base class) to a lambda that returns true if the given string is a valid 
            // email address.
            //
            // Note that validation info must be set in the static constructor, so other code
            // can call the static EmailAddress.IsValid method to check if a given string is a valid
            // email address.
            IsValid = s => 
                Regex.IsMatch(s,
                            @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                            RegexOptions.IgnoreCase);
        }

        // Constructor, taking an email address. The base constructor handles validation
        // and storage in the Value property.
        public EmailAddress(string emailAddress) : base(emailAddress) { }
    }
}
