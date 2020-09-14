using Domain.Models;
using System;
using System.Collections.Generic;

namespace Application.Helper
{
    /// <summary>
    /// Class to hold methods for converting dto's and vice-versa
    /// </summary>
    public class DTOHelper
    {
        public Domain.Models.ToDoItem MapItemDTOToAddEntity(BaseToDoItem baseToDo)
        {
            Domain.Models.ToDoItem item = new Domain.Models.ToDoItem()
            {
                CreatedDate = DateTime.Now,
                LabelId = baseToDo.LabelId,
                Name = baseToDo.Name,
                UserId = baseToDo.UserId,
                IsComplete = baseToDo.IsComplete,

            };
            return item;
        }
        public Domain.Models.ToDoItem MapItemDTOToUpdateEntity(BaseToDoItem baseToDo)
        {
            Domain.Models.ToDoItem item = new Domain.Models.ToDoItem()
            {
                Id = baseToDo.Id,
                UpdatedDate = DateTime.Now,
                LabelId = baseToDo.LabelId,
                Name = baseToDo.Name,
                UserId = baseToDo.UserId,
                IsComplete = baseToDo.IsComplete,

            };
            return item;
        }

        public Domain.Models.ToDoList MapListDTOToAddEntity(BaseToDoList baseToDo)
        {
            Domain.Models.ToDoList itemList = new Domain.Models.ToDoList()
            {
                CreatedDate = DateTime.Now,
                LabelId = baseToDo.LabelId,
                UpdatedDate = (DateTime?)null,
                Name = baseToDo.Name,
                UserId = baseToDo.UserId,
            };
            if (baseToDo.TodoItems != null && baseToDo.TodoItems.Count > 0)
            {
                itemList.TodoItems = new List<Domain.Models.ToDoItem>();
                foreach (var item in baseToDo.TodoItems)
                {
                    itemList.TodoItems.Add(MapItemDTOToAddEntity(item));
                }
            }
            return itemList;
        }

        public Domain.Models.ToDoList MapListDTOToUpdateEntity(BaseToDoList baseToDo)
        {
            Domain.Models.ToDoList itemList = new Domain.Models.ToDoList()
            {
                Id = baseToDo.Id,
                UpdatedDate = DateTime.Now,
                LabelId = baseToDo.LabelId,
                Name = baseToDo.Name,
                UserId = baseToDo.UserId,
            };
            if (baseToDo.TodoItems != null && baseToDo.TodoItems.Count > 0)
            {
                itemList.TodoItems = new List<Domain.Models.ToDoItem>();
                foreach (var item in baseToDo.TodoItems)
                {
                    itemList.TodoItems.Add(MapItemDTOToUpdateEntity(item));
                }
            }
            return itemList;
        }
    }
}
