using BuissnesLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer.Helpers
{
    class ServiceActionResult<T> :IServiceActionResult<T>
    {
        public bool Succeed { get; set; }
        public string Message { get; set; }
        public T ActionObject { get; set; }

        public ServiceActionResult(bool succeed, string message, T actionobj)
        {
            Succeed = succeed;
            Message = message;
            ActionObject = actionobj;
        }

        public ServiceActionResult(bool succeed, string message) : this(succeed, message, default)
        { }

        public ServiceActionResult(bool succeed) : this(succeed, null, default)
        { }
    }
}
