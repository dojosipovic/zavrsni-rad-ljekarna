using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Exceptions
{
    public class PrimkaException : DrugstoreException
    {
        public PrimkaException(string message) : base(message)
        {
        }
    }
}
