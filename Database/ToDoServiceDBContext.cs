using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Database
{
    public class ToDoServiceDBContext : DbContext
    {
        public ToDoServiceDBContext(DbContextOptions<ToDoServiceDBContext> options) : base(options)
        {

        }

        public ToDoServiceDBContext()
        {

        }
        public DbSet<ToDoList> ToDoLists { get; set; }
        public DbSet<ToDoItem> ToDoItems { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Label> Labels { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile(@Directory.GetCurrentDirectory() + "/appsettings.json").Build();
            var builder = new DbContextOptionsBuilder<ToDoServiceDBContext>();
            var connectionString = configuration.GetConnectionString("ToDoServiceDb");
            optionsBuilder.UseSqlServer(connectionString);

           
        }
    }
}
