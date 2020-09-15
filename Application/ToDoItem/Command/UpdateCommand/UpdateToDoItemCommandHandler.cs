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
        private readonly IInstanceDB _instanceDB;
        private readonly IDTO _dtoMapper;
        public UpdateToDoItemCommandHandler(IUserManager userAccessor, IDTO dtoMapper, IInstanceDB instanceDB)
        {
            _userAccessor = userAccessor ?? throw new ArgumentNullException(nameof(userAccessor));
            _dtoMapper = dtoMapper;
            _instanceDB = instanceDB;
        }
        public async Task<int> Handle(UpdateToDoItemCommand request, CancellationToken cancellationToken)
        {
            int userId = _userAccessor.GetUserId();
            request.ToDoItem.UserId = userId;
            var db = _instanceDB.Get<IToDoItemDbManager>();
            Domain.Models.ToDoItem item = _dtoMapper.MapItemDTOToUpdateEntity(request.ToDoItem);
            return await db.UpdateToDoItem(item);
        }
    }
}
