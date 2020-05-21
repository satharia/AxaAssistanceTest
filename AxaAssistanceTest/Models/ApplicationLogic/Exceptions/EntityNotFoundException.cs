using System;

namespace AxaAssistanceTest.Models.ApplicationLogic.Exceptions
{
    /// <summary>
    /// Exception thrown when a particular entity is not found in the Data Source.
    /// </summary>
    public class EntityNotFoundException : Exception
    {
        public EntityNotFoundException(string message) : base(message)
        {
        }
    }
}