using System;
using System.Collections.Generic;
using System.Text;

namespace CallForCode.App.Models
{
    public class AppException : Exception
    {
        public AppException(string message) : base(message)
        {
        }
    }
}
