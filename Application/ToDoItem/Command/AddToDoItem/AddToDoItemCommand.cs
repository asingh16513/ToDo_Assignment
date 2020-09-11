using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ToDoItem.Command.AddToDoItem
{
    public class AddToDoItemCommand : IRequest<int>
    {
        public Domain.Models.ToDoItem ToDoItem { get; set; }
    }
}
