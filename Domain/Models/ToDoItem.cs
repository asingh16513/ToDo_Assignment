using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class ToDoItem : BaseItem
    {
        public bool IsComplete { get; set; }
        public int ToDoListId { get; set; }

    }
}
