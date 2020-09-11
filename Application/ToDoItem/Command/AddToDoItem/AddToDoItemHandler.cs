using Application.Helper;
using Application.Interface;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ToDoItem.Command.AddToDoItem
{
    public class AddToDoItemHandler : IRequestHandler<AddToDoItemCommand, int>
    {
        private readonly IUserManager _userAccessor;
        public AddToDoItemHandler(IUserManager userAccessor)
        {
            _userAccessor = userAccessor ?? throw new ArgumentNullException(nameof(userAccessor));
        }
        public async Task<int> Handle(AddToDoItemCommand request, CancellationToken cancellationToken)
        {
            int userId = _userAccessor.GetUserId();
            request.ToDoItem.UserId = userId;
            request.ToDoItem.CreateDate = DateTime.Now;
            var db = GetInstance.Get<IToDoItem>();
            return await db.AddToDoItem(request.ToDoItem);
        }
    }
}
