using Domain.Models;
using MediatR;

namespace Application.ToDoList.Command.AddToDoList
{
    public class AddToDoListCommand : IRequest<int>
    {
        public BaseToDoList ToDoList { get; set; }
    }
}
