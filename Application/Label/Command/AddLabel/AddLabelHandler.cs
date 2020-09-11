using Application.Helper;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Label.Command.AddLabel
{
    public class AddLabelHandler : IRequestHandler<AddLabelCommand, int>
    {
        public async Task<int> Handle(AddLabelCommand request, CancellationToken cancellationToken)
        {
            var db = GetInstance.Get<ILabel>(); 
            return await db.AddLabel(request.Label);
        }
    }
}
