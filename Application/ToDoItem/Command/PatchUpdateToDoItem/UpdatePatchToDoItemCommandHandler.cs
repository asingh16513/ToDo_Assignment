using Application.Helper;
using Application.Interface;
using MediatR;
using Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ToDoItem.Command.PatchUpdateToDoItem
{
    public class UpdatePatchToDoItemCommandHandler : IRequestHandler<UpdatePatchToDoItemCommand, int>
    {
        private readonly IUserManager _userAccessor;
        public UpdatePatchToDoItemCommandHandler(IUserManager userAccessor)
        {
            _userAccessor = userAccessor ?? throw new ArgumentNullException(nameof(userAccessor));
        }
        public async Task<int> Handle(UpdatePatchToDoItemCommand request, CancellationToken cancellationToken)
        {
            DTOHelper helper = new DTOHelper();
            request.ToDoItem.UserId = _userAccessor.GetUserId(); ;
            var db = GetInstance.Get<IToDoItemDbManager>();
            Domain.Models.ToDoItem item = helper.MapItemDTOToUpdateEntity(request.ToDoItem);
            return await db.UpdateToDoItem(item);
        }
    }
}
