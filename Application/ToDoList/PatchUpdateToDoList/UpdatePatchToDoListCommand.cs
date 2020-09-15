using Application.ToDoList.Command.UpdateCommand;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;

namespace Application.ToDoList.PatchUpdateToDoList
{
    public class UpdatePatchToDoListCommand : IRequest<int>
    {
        public JsonPatchDocument<UpdateToDoListCommand> JsonPatchDocument { get; set; }
        public int ItemId { get; set; }
    }
}
