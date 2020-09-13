using Application.Helper;
using MediatR;
using Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ToDoItem.Query.DeleteToDoItemQuery
{
    public class DeleteToDoItemQueryHandler : IRequestHandler<DeleteToDoItemQuery, int>
    {
        public async Task<int> Handle(DeleteToDoItemQuery request, CancellationToken cancellationToken)
        {
            var db = GetInstance.Get<IToDoItemDbManager>();
            return await db.DeleteToDoItem(request.ItemId);
        }
    }
}
