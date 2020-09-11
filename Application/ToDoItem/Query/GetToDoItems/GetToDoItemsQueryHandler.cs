using Application.Helper;
using Application.Interface;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ToDoItem.Query.GetToDoItems
{
    public class GetToDoItemsQueryHandler : IRequestHandler<EmptyQuery<List<Domain.Models.ToDoItemExt>>, List<Domain.Models.ToDoItemExt>>
    {
        private readonly IUserManager _userAccessor;
        public GetToDoItemsQueryHandler(IUserManager userAccessor)
        {
            _userAccessor = userAccessor ?? throw new ArgumentNullException(nameof(userAccessor));
        }
        public async Task<List<Domain.Models.ToDoItemExt>> Handle(EmptyQuery<List<Domain.Models.ToDoItemExt>> request, CancellationToken cancellationToken)
        {
            var db = GetInstance.Get<IToDoItem>();
            return await db.GetToDoItems(_userAccessor.GetUserId());
        }
    }
}
