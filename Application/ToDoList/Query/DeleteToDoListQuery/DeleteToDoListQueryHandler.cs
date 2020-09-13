using Application.Helper;
using MediatR;
using Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ToDoList.Query.DeleteToDoListQuery
{
    public class DeleteToDoItemHandler : IRequestHandler<DeleteToDoListQuery, int>
    {
        public async Task<int> Handle(DeleteToDoListQuery request, CancellationToken cancellationToken)
        {
            var db = GetInstance.Get<IToDoListDbManager>();
            return await db.DeleteToDoList(request.ItemId);
        }
    }
}
