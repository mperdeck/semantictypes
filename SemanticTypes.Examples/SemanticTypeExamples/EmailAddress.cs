using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace SemanticTypes.SemanticTypeExamples
{
    public class EmailAddress : SemanticType<string>
    {
        public static bool IsValid(string value)
        {
            return (Regex.IsMatch(value,
                            @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
                            @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                            RegexOptions.IgnoreCase));
        }

        // Constructor, taking an email address. The base constructor handles validation
        // and storage in the Value property.
        public EmailAddress(string emailAddress) : base(IsValid, typeof(EmailAddress), emailAddress) { }
    }
}
