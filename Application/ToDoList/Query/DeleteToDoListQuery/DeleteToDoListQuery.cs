using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ToDoList.Query.DeleteToDoListQuery
{
    public class DeleteToDoListQuery : IRequest<int>
    {
       
        public int ItemId { get; set; }
    }
}
