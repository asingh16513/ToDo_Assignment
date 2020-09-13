using Domain.Models;
using MediatR;
using System.Collections.Generic;

namespace Application.ToDoList.Query.SearchToDoList
{
    public class SearchToDoListQuery : IRequest<List<ToDoListExt>>
    {
        public SearchFilter SearchFilter { get; set; }
    }
}
