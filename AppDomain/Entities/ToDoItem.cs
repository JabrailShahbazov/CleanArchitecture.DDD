using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomain.Common.DomainEvents;
using AppDomain.Common.Entities;
using AppDomain.Enums;
using AppDomain.Events;

namespace AppDomain.Entities
{
    public abstract class ToDoItem : BaseEntity<int>, IAuditableEntity, IHasDomainEvent

    {

        public string Title { get; set; }

        public string Note { get; set; }

        public PriorityLevel Priority { get; set; }

        public DateTime? Reminder { get; set; }



        public int ListId { get; set; }
        public ToDoList List { get; set; }


        private bool _done;

        public bool Done
        {
            get => _done;
            set
            {
                if (value == true && _done == false)
                {
                    DomainEvents.Add(new ToDoItemCompletedEvent(this));
                }

                _done = value;
            }
        }

        public List<DomainEvent> DomainEvents { get; set; } = new List<DomainEvent>();
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
