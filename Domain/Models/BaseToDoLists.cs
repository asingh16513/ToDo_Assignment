using System.Collections.Generic;

namespace Domain.Models
{
    public class BaseToDoList : BaseItem
    {
        public List<BaseToDoItem> TodoItems { get; set; }
    }
}
