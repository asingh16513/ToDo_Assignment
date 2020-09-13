using MediatR;

namespace Application.ToDoList.Query.DeleteToDoListQuery
{
    public class DeleteToDoListQuery : IRequest<int>
    {

        public int ItemId { get; set; }
    }
}
