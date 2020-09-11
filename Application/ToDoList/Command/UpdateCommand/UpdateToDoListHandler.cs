using Application.Helper;
using Application.Interface;
using Application.ToDoList.Command.UpdateCommand;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ToDoItem.Command.UpdateCommand
{
    public class UpdateToDoListHandler : IRequestHandler<UpdateToDoListCommand, int>
    {
        private readonly IUserManager _userAccessor;
        public UpdateToDoListHandler(IUserManager userAccessor)
        {
            _userAccessor = userAccessor ?? throw new ArgumentNullException(nameof(userAccessor));
        }
        public async Task<int> Handle(UpdateToDoListCommand request, CancellationToken cancellationToken)
        {
            int userId = _userAccessor.GetUserId();
            request.ToDoList.UserId = userId;
            var db = GetInstance.Get<IToDoList>();
            return await db.UpdateToDoList(request.ToDoList);
        }
    }
}
