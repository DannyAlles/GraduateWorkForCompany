using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkCompany.Domain.Exception
{
    [Serializable]
    public class PhoneIsAlreadyExistsException : System.Exception
    {
        public PhoneIsAlreadyExistsException()
        {

        }
    }
}
