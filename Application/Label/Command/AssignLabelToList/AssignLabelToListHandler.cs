using Application.Helper;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Label.Command.AssignLabelToList
{
    public class AssignItemLabelHandler : IRequestHandler<AssignLabelToListCommand, int>
    {
        public async Task<int> Handle(AssignLabelToListCommand request, CancellationToken cancellationToken)
        {
            var db = GetInstance.Get<ILabel>();
            return await db.AssignLabelToList(request.LabelId,request.ListId);
        }
    }
}
