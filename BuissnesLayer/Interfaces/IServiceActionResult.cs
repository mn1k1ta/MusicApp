using System;
using System.Collections.Generic;
using System.Text;

namespace BuissnesLayer.Interfaces
{
    public interface IServiceActionResult<T>
    {
        bool Succeed { get; set; }
        string Message { get; set; }
        T ActionObject { get; set; }
    }
}
