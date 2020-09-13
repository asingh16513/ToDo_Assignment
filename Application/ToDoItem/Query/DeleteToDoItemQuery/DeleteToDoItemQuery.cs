using MediatR;

namespace Application.ToDoItem.Query.DeleteToDoItemQuery
{
    public class DeleteToDoItemQuery : IRequest<int>
    {
        public int ItemId { get; set; }
    }
}
