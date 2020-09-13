using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Persistence;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database
{
    public class ToDoItemDbManager : IToDoItemDbManager
    {
        public async Task<int> AddToDoItem(ToDoItem item)
        {
            using (var context = new ToDoServiceDBContext())
            {
                context.ToDoItems.Add(item);
                int result = await context.SaveChangesAsync();
                return result;
            }
        }

        public async Task<List<ToDoItemExt>> GetToDoItems(int userId)
        {
            using (var context = new ToDoServiceDBContext())
            {
                List<ToDoItemExt> items = await (from item in context.ToDoItems
                                                 join label in context.Labels
                                                 on item.LabelId equals label.Id
                                                 where item.UserId == userId
                                                 select new ToDoItemExt
                                                 {
                                                     Id = item.Id,
                                                     Name = item.Name,
                                                     Label = label.Name
                                                 }).ToListAsync();
                return items;
            }
        }

        public async Task<List<ToDoItemExt>> SearchToDoItems(int userId, string searchString, int pageNumber, int pageSize)
        {
            using (var context = new ToDoServiceDBContext())
            {
                IQueryable<ToDoItemExt> items = (from item in context.ToDoItems
                                                 join label in context.Labels
                                                 on item.LabelId equals label.Id
                                                 where item.UserId == userId
                                                 select new ToDoItemExt
                                                 {
                                                     Id = item.Id,
                                                     Name = item.Name,
                                                     Label = label.Name
                                                 });

                if (!string.IsNullOrEmpty(searchString))
                {
                    return await items.Where(s => s.Name.ToLower().Contains(searchString.ToLower())).DoPaging(pageNumber, pageSize).ToListAsync();
                }
                else
                    return await items.DoPaging(pageNumber, pageSize).ToListAsync();

            }
        }


        public async Task<int> UpdateToDoItem(ToDoItem item)
        {
            using (var context = new ToDoServiceDBContext())
            {
                context.ToDoItems.Attach(item).Property(x => x.CreatedDate).IsModified = false;
                context.ToDoItems.Update(item);
                return await context.SaveChangesAsync();
            }
        }

        public async Task<int> DeleteToDoItem(int itemId)
        {
            using (var context = new ToDoServiceDBContext())
            {
                var item = await context.ToDoItems.FindAsync(itemId);
                context.ToDoItems.Remove(item);
                return await context.SaveChangesAsync();
            }
        }
    }
}
