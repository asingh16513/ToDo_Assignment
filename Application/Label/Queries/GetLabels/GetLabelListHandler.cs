using Application.Helper;
using Application.Interface;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Label.Queries.GetLabels
{
    public class GetLabelListHandler : IRequestHandler<EmptyQuery<List<Domain.Models.Label>>,List<Domain.Models.Label>>
    {  
        public async Task<List<Domain.Models.Label>> Handle(EmptyQuery<List<Domain.Models.Label>> request, CancellationToken cancellationToken)
        {
            var db = GetInstance.Get<ILabel>();
            List<Domain.Models.Label> labels = new List<Domain.Models.Label>();
            labels = await db.GetLabels();
            return labels;
        }
    }
}
