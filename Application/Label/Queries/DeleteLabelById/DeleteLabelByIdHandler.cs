using Application.Helper;
using MediatR;
using Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Label.Queries.DeleteLabelById
{
    public class DeleteLabelByIdHandler : IRequestHandler<DeleteLabelByIdQuery, int>
    {
        public async Task<int> Handle(DeleteLabelByIdQuery request, CancellationToken cancellationToken)
        {
            var db = GetInstance.Get<ILabelDBManager>();
            return await db.DeleteLabelById(request.LableId);
        }
    }
}
