using System.Collections.Generic;

namespace AppDomain.Common.DomainEvents
{
    public abstract class HaveDomainEvent
    {
        public List<DomainEvent> Events = new List<DomainEvent>();
    }
}