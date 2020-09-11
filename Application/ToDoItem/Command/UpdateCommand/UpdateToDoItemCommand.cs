using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ToDoItem.Command.UpdateCommand
{
    public class UpdateToDoItemCommand : IRequest<int>
    {
        public Domain.Models.ToDoItem ToDoItem { get; set; }
    }
}
