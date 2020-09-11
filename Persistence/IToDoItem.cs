using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public interface IToDoItem
    {
        Task<int> AddToDoItem(Domain.Models.ToDoItem item);
        Task<List<ToDoItemExt>> GetToDoItems(int userId);
        Task<int> UpdateToDoItem(ToDoItem item);
        Task<int> DeleteToDoItem(int itemId);
    }
}
