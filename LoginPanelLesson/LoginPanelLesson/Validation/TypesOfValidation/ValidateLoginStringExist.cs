using LoginPanelLesson.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginPanelLesson.Validation.TypesOfValidation
{
    public class ValidateLoginStringExist : ISpecyficValidation<string>
    {
        public bool Validate(string value, out string message)
        {
            message = "";
            LinqQueries myQueries = new();

            if (!myQueries.DoesLoginExist(value))
                return true;

            message = "already exist.";
            return false;
        }
    }
}
