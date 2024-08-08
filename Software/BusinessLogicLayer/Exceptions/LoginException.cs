using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Exceptions
{
    public class LoginException : DrugstoreException
    {
        public LoginException(string message) : base(message)
        {
        }
    }
}
