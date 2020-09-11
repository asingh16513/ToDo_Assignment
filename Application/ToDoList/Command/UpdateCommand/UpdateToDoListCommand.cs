using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ToDoList.Command.UpdateCommand
{
    public class UpdateToDoListCommand : IRequest<int>
    {
        public Domain.Models.ToDoList ToDoList { get; set; }
    }
}
