using Application.Helper;
using MediatR;
using Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Label.Command.AssignItemLabel
{
    public class AssignItemLabelCommandHandler : IRequestHandler<AssignItemLabelCommand, int>
    {
        public async Task<int> Handle(AssignItemLabelCommand request, CancellationToken cancellationToken)
        {
            var db = GetInstance.Get<ILabelDBManager>();
            return await db.AssignLabelToItem(request.LabelId, request.ItemId);
        }
    }
}
