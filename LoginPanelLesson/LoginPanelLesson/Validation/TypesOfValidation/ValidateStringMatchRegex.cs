using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LoginPanelLesson.Validation.TypesOfValidation
{
    public class ValidateStringMatchRegex : ISpecyficValidation<string>
    {
        private string rgx;
        private string errorMessage;

        public ValidateStringMatchRegex(string rgx, string errorMessage) => (this.rgx, this.errorMessage) = (rgx, errorMessage); 

        public bool Validate(string value, out string message)
        {
            message = "";

            if (Regex.IsMatch(value, rgx)) return true;

            message = errorMessage;
            return false;
        }
    }
}
