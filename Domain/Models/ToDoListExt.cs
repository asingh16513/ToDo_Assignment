using System.Collections.Generic;

namespace Domain.Models
{
    public class ToDoListExt : ToDoItemExt
    {
        public List<ToDoItemExt> ToDoItems { get; set; }
    }
}
