using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ToDoList.Command.AddToDoList
{
    public class AddToDoListCommand : IRequest<int>
    {
        public Domain.Models.ToDoList ToDoList { get; set; }
    }
}
