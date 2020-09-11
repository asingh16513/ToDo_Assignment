using Application.Helper;
using Application.Interface;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ToDoList.Command.AddToDoList
{
    public class AddToDoListHandler : IRequestHandler<AddToDoListCommand, int>
    {
        private readonly IUserManager _userAccessor;
        public AddToDoListHandler(IUserManager userAccessor)
        {
            _userAccessor = userAccessor ?? throw new ArgumentNullException(nameof(userAccessor));
        }
        public async Task<int> Handle(AddToDoListCommand request, CancellationToken cancellationToken)
        {
            int userId = _userAccessor.GetUserId();
            request.ToDoList.UserId = userId;
            var db = GetInstance.Get<IToDoList>();
            return await db.AddToDoList(request.ToDoList);
        }
    }
}
