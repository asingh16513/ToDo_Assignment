using Application.Helper;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Label.Command.AssignItemLabel
{
    public class AssignItemLabelHandler : IRequestHandler<AssignItemLabelCommand, int>
    {
        public async Task<int> Handle(AssignItemLabelCommand request, CancellationToken cancellationToken)
        {
            var db = GetInstance.Get<ILabel>();
            return await db.AssignLabelToItem(request.LabelId,request.ItemId);
        }
    }
}
