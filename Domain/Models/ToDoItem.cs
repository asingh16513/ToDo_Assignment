using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Models
{
    [Table("ToDoItems")]
    public class ToDoItem : BaseToDoItem
    {
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int? ToDoListId { get; set; }

    }
}
