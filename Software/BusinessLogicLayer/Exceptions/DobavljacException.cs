using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Exceptions
{
    public class DobavljacException : DrugstoreException
    {
        public DobavljacException(string message) : base(message)
        {
        }
    }
}
