using MediatR;

namespace Application.ToDoItem.Command.PatchUpdateToDoItem
{
    public class UpdatePatchToDoItemCommand : IRequest<int>
    {
        public Domain.Models.BaseToDoItem ToDoItem { get; set; }
    }
}
