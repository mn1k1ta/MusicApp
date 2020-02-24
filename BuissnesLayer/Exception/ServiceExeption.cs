﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer.Exception
{
    public class ServiceException : System.Exception
    {
        public ServiceException()
        {
        }

        public ServiceException(string message) : base(message)
        {
        }

        public ServiceException(string message, System.Exception innerException) : base(message, innerException)
        {
        }
    }
}
