using Application.Helper;
using Application.Interface;
using MediatR;
using Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ToDoItem.Command.UpdateCommand
{
    public class UpdateToDoItemCommandHandler : IRequestHandler<UpdateToDoItemCommand, int>
    {
        private readonly IUserManager _userAccessor;
        public UpdateToDoItemCommandHandler(IUserManager userAccessor)
        {
            _userAccessor = userAccessor ?? throw new ArgumentNullException(nameof(userAccessor));
        }
        public async Task<int> Handle(UpdateToDoItemCommand request, CancellationToken cancellationToken)
        {
            DTOHelper helper = new DTOHelper();
            int userId = _userAccessor.GetUserId();
            request.ToDoItem.UserId = userId;
            var db = GetInstance.Get<IToDoItemDbManager>();
            Domain.Models.ToDoItem item = helper.MapItemDTOToUpdateEntity(request.ToDoItem);
            return await db.UpdateToDoItem(item);
        }
    }
}
