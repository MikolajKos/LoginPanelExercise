using LoginPanelLesson.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginPanelLesson.Validation.TypesOfValidation
{
    class ValidateAccountExist : ISpecyficValidation<string>
    {
        private string login;
        private string password;

        public ValidateAccountExist(string login, string password) => (this.login, this.password) = (login, password);

        public bool Validate(string value, out string message)
        {
            message = "";
            LinqQueries myQueries = new();

            if (myQueries.EnteredAndDbPasswordsAreSame(login, password)) return true;

            message = "or login incorrect";
            return false;
        }
    }
}
