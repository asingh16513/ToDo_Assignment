using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class ToDoListDbManager : IToDoList
    {
        public async Task<int> AddToDoList(ToDoList item)
        {
            using (var context = new ToDoServiceDBContext())
            {
                context.ToDoLists.Add(item);
                int result = await context.SaveChangesAsync();
                //int todoId = item.Id;
                //await InsertUpdateToDoItems(todoId, item.TodoItems, true);
                return result;
            }
        }

        private async Task<int> InsertUpdateToDoItems(int todoId, List<ToDoItem> todoItems, bool insert)
        {
            using (var context = new ToDoServiceDBContext())
            {
                if (todoItems != null && todoItems.Count > 0)
                {
                    for (int i = 0; i < todoItems.Count; i++)
                    {
                        ToDoItem item = todoItems[i];
                        item.ToDoListId = todoId;
                        if (insert)
                            context.ToDoItems.Add(item);
                        else
                            context.ToDoItems.Update(item);
                    }
                    return await context.SaveChangesAsync();
                }
                return 0;
            }
        }

        public async Task<List<ToDoListExt>> GetToDoList(int userId)
        {
            using (var context = new ToDoServiceDBContext())
            {
                //var dbEntityEntry = context.Entry(userId);
                //dbEntityEntry.CurrentValues.SetValues(ameValuePairProperties);
                List<ToDoListExt> items = await (from item in context.ToDoLists
                                                 join label in context.Labels
                                                 on item.LabelId equals label.Id
                                                 where item.UserId == userId
                                                 select new ToDoListExt
                                                 {
                                                     Id = item.Id,
                                                     Name=item.Name,
                                                     Label = label.Name
                                                 }).ToListAsync(); 
                 
                if (items != null&& items.Count>0)
                {
                    foreach (var item in items)
                    {
                        item.ToDoItems  = await (from to_do_item in context.ToDoItems
                                                 join label in context.Labels
                                                 on to_do_item.LabelId equals label.Id
                                                 where to_do_item.ToDoListId == item.Id
                                                 select new ToDoItemExt
                                                 {
                                                     Id = item.Id,
                                                     Name = item.Name,
                                                     Label = label.Name
                                                 }).ToListAsync();
                    }
                }                
                return items;
            }
        }

        public async Task<int> UpdateToDoList(ToDoList item)
        {
            int result = 0;
            int todoId = 0;
            using (var context = new ToDoServiceDBContext())
            {
                context.ToDoLists.Update(item);
                context.ToDoLists.Attach(item).Property(x => x.CreateDate).IsModified = false;
                result = await context.SaveChangesAsync();
                todoId = item.Id;
            }
            //await InsertUpdateToDoItems(todoId, item.TodoItems, false);
            return result;
        }

        public async Task<int> DeleteToDoList(int itemId)
        {
            using (var context = new ToDoServiceDBContext())
            {
                var item = await context.ToDoLists.FindAsync(itemId);
                context.ToDoLists.Remove(item);
                return await context.SaveChangesAsync();
            }
        }
    }
}
