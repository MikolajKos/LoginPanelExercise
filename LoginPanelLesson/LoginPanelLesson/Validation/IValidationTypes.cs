using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginPanelLesson.Validation
{
    public interface IValidationTypes
    {
        public string Name { get; set; }
        bool Validate(out string message);
    }
}
