using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginPanelLesson.Validation.TypesOfValidation
{
    public interface ISpecyficValidation<T>
    {
        bool Validate(T value, out string message);
    }
}
