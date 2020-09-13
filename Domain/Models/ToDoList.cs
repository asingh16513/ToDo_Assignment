using System;
using System.Collections.Generic;

namespace Domain.Models
{
    public class ToDoList : BaseItem
    {
        public List<ToDoItem> TodoItems { get; set; }
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
