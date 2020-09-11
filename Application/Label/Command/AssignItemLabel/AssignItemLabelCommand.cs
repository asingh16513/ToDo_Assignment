using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Label.Command.AssignItemLabel
{
    public class AssignItemLabelCommand : IRequest<int>
    {
        public int LabelId { get; set; }
        public int[] ItemId { get; set; }
    }
}
