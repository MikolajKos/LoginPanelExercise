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
        public bool Validate(string value, out string message)
        {
            string rgx = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{0,}$";
            message = "";

            if (Regex.IsMatch(value, rgx)) return true;

            message = "must have minimum one uppercase letter, one lowercase letter, number and special character.";
            return false;
        }
    }
}
