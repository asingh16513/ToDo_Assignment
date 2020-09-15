using Application.ToDoItem.Command.PatchUpdateToDoItem;
using Application.ToDoItem.Command.UpdateCommand;
using Application.ToDoList.Command.UpdateCommand;
using Application.ToDoList.PatchUpdateToDoList;
using Microsoft.AspNetCore.JsonPatch;

namespace Application.Interface
{
    public interface IPatchToDo
    {
        UpdatePatchToDoItemCommand CommandToPatch(int id, JsonPatchDocument<UpdateToDoItemCommand> jsonPatchDocument);
        UpdateToDoItemCommand ItemToCommand(Domain.Models.ToDoItem item);

        UpdatePatchToDoListCommand CommandToPatch(int id, JsonPatchDocument<UpdateToDoListCommand> jsonPatchDocument);
        UpdateToDoListCommand ListToCommand(Domain.Models.ToDoList item);
    }
}
