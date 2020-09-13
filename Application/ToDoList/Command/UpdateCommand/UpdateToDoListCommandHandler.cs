using Application.Helper;
using Application.Interface;
using Application.ToDoList.Command.UpdateCommand;
using MediatR;
using Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ToDoItem.Command.UpdateCommand
{
    public class UpdateToDoListCommandHandler : IRequestHandler<UpdateToDoListCommand, int>
    {
        private readonly IUserManager _userAccessor;
        public UpdateToDoListCommandHandler(IUserManager userAccessor)
        {
            _userAccessor = userAccessor ?? throw new ArgumentNullException(nameof(userAccessor));
        }
        public async Task<int> Handle(UpdateToDoListCommand request, CancellationToken cancellationToken)
        {
            DTOHelper helper = new DTOHelper();
            int userId = _userAccessor.GetUserId();
            request.ToDoList.UserId = userId;
            Domain.Models.ToDoList list = helper.MapListDTOToUpdateEntity(request.ToDoList);
            var db = GetInstance.Get<IToDoListDbManager>();
            return await db.UpdateToDoList(list);
        }
    }
}
