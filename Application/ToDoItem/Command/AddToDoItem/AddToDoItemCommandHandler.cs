using Application.Helper;
using Application.Interface;
using MediatR;
using Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ToDoItem.Command.AddToDoItem
{
    public class AddToDoItemCommandHandler : IRequestHandler<AddToDoItemCommand, int>
    {
        private readonly IUserManager _userAccessor;
        public AddToDoItemCommandHandler(IUserManager userAccessor)
        {
            _userAccessor = userAccessor ?? throw new ArgumentNullException(nameof(userAccessor));
        }
        public async Task<int> Handle(AddToDoItemCommand request, CancellationToken cancellationToken)
        {
            DTOHelper helper = new DTOHelper();
            int userId = _userAccessor.GetUserId();
            request.ToDoItem.UserId = userId;
            Domain.Models.ToDoItem item = helper.MapItemDTOToAddEntity(request.ToDoItem);
            var db = GetInstance.Get<IToDoItemDbManager>();
            return await db.AddToDoItem(item);
        }
    }
}
