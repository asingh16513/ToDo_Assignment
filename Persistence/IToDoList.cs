using Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Persistence
{
    public interface IToDoList
    {
        Task<int> AddToDoList(Domain.Models.ToDoList item);

        Task<List<ToDoListExt>> GetToDoList(int userId);

        Task<int> UpdateToDoList(ToDoList item);
        Task<int> DeleteToDoList(int itemId);
    }
}
