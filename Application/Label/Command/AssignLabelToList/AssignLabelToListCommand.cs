using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Label.Command.AssignLabelToList
{
    public class AssignLabelToListCommand : IRequest<int>
    {
        public int LabelId { get; set; }
        public int[] ListId { get; set; }
    }
}
