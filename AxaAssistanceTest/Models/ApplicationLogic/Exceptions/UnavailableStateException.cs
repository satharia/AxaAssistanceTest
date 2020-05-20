using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AxaAssistanceTest.Models.ApplicationLogic.Exceptions
{
    public class UnavailableStateException : Exception
    {
        public UnavailableStateException(string message) : base(message)
        {
        }
    }
}