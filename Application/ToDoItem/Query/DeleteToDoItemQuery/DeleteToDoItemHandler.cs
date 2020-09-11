using Application.Helper;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ToDoItem.Query.DeleteToDoItemQuery
{
    public class DeleteToDoItemHandler : IRequestHandler<DeleteToDoItemQuery, int>
    {
        public async Task<int> Handle(DeleteToDoItemQuery request, CancellationToken cancellationToken)
        {
            var db = GetInstance.Get<IToDoItem>();
            return await db.DeleteToDoItem(request.ItemId);
        }
    }
}
