using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Label.Queries.GetLabelById
{
    public class GetLabelByIdQuery : IRequest<Domain.Models.Label>
    {
        public int LabelId { get; set; }
    }
}
