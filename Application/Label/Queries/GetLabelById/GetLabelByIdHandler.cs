using Application.Helper;
using MediatR;
using Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Label.Queries.GetLabelById
{
    public class GetLabelByIdHandler : IRequestHandler<GetLabelByIdQuery, Domain.Models.Label>
    {
        public async Task<Domain.Models.Label> Handle(GetLabelByIdQuery request, CancellationToken cancellationToken)
        {
            var db = GetInstance.Get<ILabelDBManager>();
            return await db.GetLabelById(request.LabelId);
        }
    }
}
