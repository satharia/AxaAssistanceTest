using System;

namespace AxaAssistanceTest.Models.ApplicationLogic.Exceptions
{
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message) : base(message)
        {
        }
    }
}