using System;

namespace AxaAssistanceTest.Models.ApplicationLogic.Exceptions
{
    /// <summary>
    /// Exception thrown when an entity is in a state that does not allow it's modification or the execution of an operation on it.
    /// </summary>
    public class UnavailableStateException : Exception
    {
        public UnavailableStateException(string message) : base(message)
        {
        }
    }
}