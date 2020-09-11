using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Label.Queries.DeleteLabelById
{
    public class DeleteLabelByIdQuery : IRequest<int>
    {
        public int LableId { get; set; }
    }
}
