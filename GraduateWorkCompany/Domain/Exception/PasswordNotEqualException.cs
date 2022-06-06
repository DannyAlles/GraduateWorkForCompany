using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace GraduateWorkCompany.Domain.Exception
{
    [Serializable]
    public class PasswordNotEqualException : System.Exception
    {
        public PasswordNotEqualException()
        {

        }
        public PasswordNotEqualException(string message) : base(message)
        {
        }

        public PasswordNotEqualException(string message, SystemException innerException) : base(message, innerException)
        {
        }

        protected PasswordNotEqualException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
