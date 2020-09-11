using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Models
{
    public class ToDoListExt :ToDoItemExt
    {
        public List<ToDoItemExt> ToDoItems { get; set; }
    }
}
