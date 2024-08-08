﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Exceptions
{
    public class DrugstoreException : ApplicationException
    {
        public string Message { get; set; }

        public DrugstoreException(string message)
        {
            Message = message;
        }
    }
}
