using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class ToDoList : BaseItem
    {
        public List<ToDoItem> TodoItems { get; set; }
    }
}
