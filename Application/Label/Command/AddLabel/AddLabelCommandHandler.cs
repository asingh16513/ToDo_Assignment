using Application.Helper;
using MediatR;
using Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Label.Command.AddLabel
{
    public class AddLabelCommandHandler : IRequestHandler<AddLabelCommand, int>
    {
        public async Task<int> Handle(AddLabelCommand request, CancellationToken cancellationToken)
        {
            var db = GetInstance.Get<ILabelDBManager>();
            return await db.AddLabel(request.Label);
        }
    }
}
