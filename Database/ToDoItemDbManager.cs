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
    public class ToDoItemDbManager : IToDoItem
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
                                                  Name=item.Name,
                                                  Label = label.Name
                                              }).ToListAsync();
                //List<ToDoItem> items = await context.ToDoItems.Where(d => d.UserId == userId).ToListAsync();

                return items;
            }
        }

        public async Task<int> UpdateToDoItem(ToDoItem item)
        {
            using (var context = new ToDoServiceDBContext())
            {
                context.ToDoItems.Attach(item).Property(x => x.CreateDate).IsModified = false;
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
