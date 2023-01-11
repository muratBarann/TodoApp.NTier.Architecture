using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Udemy.TodoAppNTier.Common.ResponseObject
{
    public class CustomValidationError
    {
        //Validation hatalarını tutan bir nesne oluşturmak için bu sınıfı oluşturduk.
        public string ErrorMessage { get; set; }
        public string PropertyName { get; set; }
    }
}
