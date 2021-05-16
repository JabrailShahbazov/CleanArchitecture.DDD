using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomain.Common.DomainEvents;
using AppDomain.Entities;

namespace AppDomain.Events
{
    public class TodoItemCompletedEvent : DomainEvent
    {
        public TodoItemCompletedEvent(ToDoItem item)
        {
            Item = item;
        }

        public ToDoItem Item { get; }
    }
}
