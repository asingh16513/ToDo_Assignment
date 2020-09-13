using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database
{
    public class ToDoListDbManager : IToDoListDbManager
    {
        public async Task<int> AddToDoList(ToDoList item)
        {
            int result = 0;
            using (var context = new ToDoServiceDBContext())
            {
                context.ToDoLists.Add(item);
                result = await context.SaveChangesAsync();
            }
            return result;
        }

        public async Task<List<ToDoListExt>> GetToDoList(int userId)
        {
            using (var context = new ToDoServiceDBContext())
            {
                List<ToDoListExt> items = await (from item in context.ToDoLists
                                                 join label in context.Labels
                                                 on item.LabelId equals label.Id
                                                 where item.UserId == userId
                                                 select new ToDoListExt
                                                 {
                                                     Id = item.Id,
                                                     Name = item.Name,
                                                     Label = label.Name
                                                 }).ToListAsync();

                if (items != null && items.Count > 0)
                {
                    foreach (var item in items)
                    {
                        item.ToDoItems = new List<ToDoItemExt>();
                        var db_item = await (from to_do_item in context.ToDoItems
                                             join label in context.Labels
                                             on to_do_item.LabelId equals label.Id
                                             where to_do_item.ToDoListId != null && to_do_item.ToDoListId.Value == item.Id
                                             select new ToDoItemExt
                                             {
                                                 Id = to_do_item.Id,
                                                 Name = to_do_item.Name,
                                                 Label = label.Name
                                             }).ToListAsync();

                        item.ToDoItems.AddRange(db_item);
                    }

                }
                return items;
            }
        }

        public async Task<List<ToDoListExt>> SearchToDoList(int userId, string searchString, int pageNumber, int pageSize)
        {
            List<ToDoListExt> toDoLists = null;
            using (var context = new ToDoServiceDBContext())
            {
                IQueryable<ToDoListExt> items = (from item in context.ToDoLists
                                                 join label in context.Labels
                                                 on item.LabelId equals label.Id
                                                 where item.UserId == userId
                                                 select new ToDoListExt
                                                 {
                                                     Id = item.Id,
                                                     Name = item.Name,
                                                     Label = label.Name
                                                 });

                if (!string.IsNullOrEmpty(searchString))
                {
                    toDoLists = await items.Where(s => s.Name.ToLower().Contains(searchString.ToLower())).DoPaging(pageNumber, pageSize).ToListAsync();
                }
                else
                    toDoLists = await items.DoPaging(pageNumber, pageSize).ToListAsync();


                if (toDoLists != null && toDoLists.Count > 0)
                {
                    foreach (var item in toDoLists)
                    {
                        item.ToDoItems = new List<ToDoItemExt>();
                        var db_item = await (from to_do_item in context.ToDoItems
                                             join label in context.Labels
                                             on to_do_item.LabelId equals label.Id
                                             where to_do_item.ToDoListId != null && to_do_item.ToDoListId.Value == item.Id
                                             select new ToDoItemExt
                                             {
                                                 Id = to_do_item.Id,
                                                 Name = to_do_item.Name,
                                                 Label = label.Name
                                             }).ToListAsync();

                        item.ToDoItems.AddRange(db_item);
                    }

                }
                return toDoLists;
            }
        }

        public async Task<int> UpdateToDoList(ToDoList item)
        {
            int result = 0;
            using (var context = new ToDoServiceDBContext())
            {
                context.ToDoLists.Update(item);
                result = await context.SaveChangesAsync();
            }
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
