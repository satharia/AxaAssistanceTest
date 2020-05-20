using System;

namespace AxaAssistanceTest.Models.Entities
{
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