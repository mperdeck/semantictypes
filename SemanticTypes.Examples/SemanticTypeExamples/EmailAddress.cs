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
        public EmailAddress(string emailAddress) : base(IsValid, emailAddress) { }

        // ---------------------------------------
        // Be careful with implementing casts, and especially implicit casts. They move you away from 
        // compile time checking to run time checking. Also, going from EmailAddress to string and vice versa
        // shouldn't be a common thing, so having a cast will not save you a lot of typing.

        public static explicit operator string(EmailAddress value)
        {
            return value.Value;
        }

        public static implicit operator EmailAddress(string value)
        {
            return new EmailAddress(value);
        }
    }
}
