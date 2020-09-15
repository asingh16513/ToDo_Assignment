using Application.Interface;
using Application.ToDoItem.Command.PatchUpdateToDoItem;
using Application.ToDoItem.Command.UpdateCommand;
using Application.ToDoList.Command.UpdateCommand;
using Application.ToDoList.PatchUpdateToDoList;
using Domain.Models;
using Microsoft.AspNetCore.JsonPatch;
using System;

namespace Application.Helper
{
    public class PatchHelper : IPatchToDo
    {
        public UpdatePatchToDoItemCommand CommandToPatch(int id, JsonPatchDocument<UpdateToDoItemCommand> jsonPatchDocument)
        {
            UpdatePatchToDoItemCommand command = new UpdatePatchToDoItemCommand();
            command.ItemId = id;
            command.JsonPatchDocument = jsonPatchDocument;
            return command;
        }

        public UpdateToDoItemCommand ItemToCommand(Domain.Models.ToDoItem item)
        {
            UpdateToDoItemCommand command = new UpdateToDoItemCommand();
            command.ToDoItem = item;
            return command;
        }

        public UpdatePatchToDoListCommand CommandToPatch(int id, JsonPatchDocument<UpdateToDoListCommand> jsonPatchDocument)
        {
            UpdatePatchToDoListCommand command = new UpdatePatchToDoListCommand();
            command.ItemId = id;
            command.JsonPatchDocument = jsonPatchDocument;
            return command;
        }

        public UpdateToDoListCommand ListToCommand(BaseToDoList item)
        {
            UpdateToDoListCommand command = new UpdateToDoListCommand();
            command.ToDoList = item;
            return command;
        }

        public UpdateToDoListCommand ListToCommand(Domain.Models.ToDoList item)
        {
            throw new NotImplementedException();
        }
    }
}