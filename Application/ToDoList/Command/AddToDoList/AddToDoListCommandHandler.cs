using Application.Helper;
using Application.Interface;
using MediatR;
using Persistence;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ToDoList.Command.AddToDoList
{
    public class AddToDoListCommandHandler : IRequestHandler<AddToDoListCommand, int>
    {
        private readonly IUserManager _userAccessor;
        public AddToDoListCommandHandler(IUserManager userAccessor)
        {
            _userAccessor = userAccessor ?? throw new ArgumentNullException(nameof(userAccessor));
        }
        public async Task<int> Handle(AddToDoListCommand request, CancellationToken cancellationToken)
        {
            DTOHelper helper = new DTOHelper();
            int userId = _userAccessor.GetUserId();
            request.ToDoList.UserId = userId;
            var db = GetInstance.Get<IToDoListDbManager>();
            Domain.Models.ToDoList list = helper.MapListDTOToAddEntity(request.ToDoList);
            return await db.AddToDoList(list);
        }


    }
}
