using System;

namespace AppDomain.Common.Entities
{
    public interface IAudit{}

    public interface  IAuditableEntity:IAudit
    {
        public DateTime Created { get; set; }

        public string CreatedBy { get; set; }

        public DateTime? LastModified { get; set; }

        public string LastModifiedBy { get; set; }
    }
}
