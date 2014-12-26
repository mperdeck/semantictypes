using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SemanticTypes;

namespace SemanticTypes.SemanticTypeQualifiedByValueExamples
{
    public class Amount : SemanticDecimalTypeQualifiedByValue<string>
    {
        /// <summary>
        /// Constructor for an Amount
        /// </summary>
        /// <param name="value">
        /// The value
        /// </param>
        /// <param name="iso4217CurrencySymbol">
        /// The ISO 4217 symbol of the currency, such as USD.
        /// For a spreadsheet with all these symbols, see
        /// http://www.currency-iso.org/en/home/tables/table-a1.html
        /// http://www.iso.org/iso/home/standards/currency_codes.htm
        /// </param>
        public Amount(decimal value, string iso4217CurrencySymbol)
            : base(value, iso4217CurrencySymbol)
        {
        }
    }
}
