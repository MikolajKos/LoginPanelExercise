using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginPanelLesson.Validation.TypesOfValidation
{
    public class ValidateStringRange : ISpecyficValidation<string>
    {
        private int _minRange, _maxRange;

        public ValidateStringRange(int minRange, int maxRange) => (_minRange, _maxRange) = (minRange, maxRange);

        public bool Validate(string value, out string message)
        {
            message = "";

            if (value.Length <= _maxRange && value.Length >= _minRange)
                return true;

            message = $"must have {_minRange}-{_maxRange} characters.";
            return false;
        }
    }
}
