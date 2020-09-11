using Application.Helper;
using Application.Interface;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ToDoItem.Command.UpdateCommand
{
    public class UpdateToDoItemHandler : IRequestHandler<UpdateToDoItemCommand, int>
    {
        private readonly IUserManager _userAccessor;
        public UpdateToDoItemHandler(IUserManager userAccessor)
        {
            _userAccessor = userAccessor ?? throw new ArgumentNullException(nameof(userAccessor));
        }
        public async Task<int> Handle(UpdateToDoItemCommand request, CancellationToken cancellationToken)
        {
            int userId = _userAccessor.GetUserId();
            request.ToDoItem.UpdatedDate = DateTime.Now;
            request.ToDoItem.UserId = userId;
            var db = GetInstance.Get<IToDoItem>();
            return await db.UpdateToDoItem(request.ToDoItem);
        }
    }
}
