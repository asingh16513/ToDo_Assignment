using Database;
using Ninject.Modules;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Helper
{
    public class DependencyResolver : NinjectModule
    {
        /// <summary>
        /// Function to load dependency.
        /// </summary>
        public override void Load()
        {
            Bind<IUser>().To<UserDbManager>().InSingletonScope();
            Bind<ILabel>().To<LabelDbManager>().InSingletonScope();
            Bind<IToDoItem>().To<ToDoItemDbManager>().InSingletonScope();
            Bind<IToDoList>().To<ToDoListDbManager>().InSingletonScope();

        }
    }
}
