using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Exceptions
{
    public class ArtiklException : DrugstoreException
    {
        public ArtiklException(string message) : base(message)
        {
        }
    }
}
