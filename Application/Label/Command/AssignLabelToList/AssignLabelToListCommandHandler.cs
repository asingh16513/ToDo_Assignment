using Application.Helper;
using MediatR;
using Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Label.Command.AssignLabelToList
{
    public class AssignItemLabelCommandHandler : IRequestHandler<AssignLabelToListCommand, int>
    {
        public async Task<int> Handle(AssignLabelToListCommand request, CancellationToken cancellationToken)
        {
            var db = GetInstance.Get<ILabelDBManager>();
            return await db.AssignLabelToList(request.LabelId, request.ListId);
        }
    }
}
