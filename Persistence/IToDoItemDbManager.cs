using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Persistence
{
    public interface IToDoItemDbManager
    {
        Task<int> AddToDoItem(ToDoItem item);
        Task<List<ToDoItemExt>> GetToDoItems(int userId);
        Task<int> UpdateToDoItem(ToDoItem item);
        Task<int> DeleteToDoItem(int itemId);
        Task<List<ToDoItemExt>> SearchToDoItems(int userId, string searchString, int pageNumber, int pageSize);
    }
}
