using MediatR;

namespace Application.ToDoItem.Command.AddToDoItem
{
    public class AddToDoItemCommand : IRequest<int>
    {
        public Domain.Models.BaseToDoItem ToDoItem { get; set; }
    }
}
