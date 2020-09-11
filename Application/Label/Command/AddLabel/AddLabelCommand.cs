using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Label.Command.AddLabel
{
    public class AddLabelCommand : IRequest<int>
    {
        public Domain.Models.Label Label { get; set; }
    }
}
