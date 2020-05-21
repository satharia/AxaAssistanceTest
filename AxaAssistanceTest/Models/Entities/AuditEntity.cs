using System;

namespace AxaAssistanceTest.Models.Entities
{
    /// <summary>
    /// Class defining common audit data for entities.
    /// </summary>
    public class AuditEntity
    {
        public DateTime? CreationTime { get; set; }
        public DateTime? ModificationTime { get; set; }

        public AuditEntity()
        {
            this.CreationTime = DateTime.Now;
        }
    }
}