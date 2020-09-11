using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ToDoItem.Query.DeleteToDoItemQuery
{
    public class DeleteToDoItemQuery : IRequest<int>
    { 
        public int ItemId { get; set; }
    }
}
