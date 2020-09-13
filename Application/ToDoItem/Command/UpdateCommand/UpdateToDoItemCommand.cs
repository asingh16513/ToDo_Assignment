using MediatR;

namespace Application.ToDoItem.Command.UpdateCommand
{
    public class UpdateToDoItemCommand : IRequest<int>
    {
        public Domain.Models.BaseToDoItem ToDoItem { get; set; }
    }
}
