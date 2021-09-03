using System;

namespace CA.Domain.Common
{
    public abstract class AuditableEntity
    {
        public DateTime CreateDate { get; set; }
        public DateTime? LastModifyDate { get; set; }
        public string CreateBy { get; set; }
        public string LastModifyBy { get; set; }
    }
}
