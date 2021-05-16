using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppDomain.Common.Entities;
using AppDomain.ValueObjects;

namespace AppDomain.Entities
{
    public class ToDoList :BaseEntity<int>, IAuditableEntity
    {
        public string Title { get; set; }

        public Colour Colour { get; set; } = Colour.White;

        public IList<ToDoItem> Items { get; private set; } = new List<ToDoItem>();
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? LastModified { get; set; }
        public string LastModifiedBy { get; set; }
    }
}
