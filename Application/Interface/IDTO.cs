using Domain.Models;

namespace Application.Interface
{
    /// <summary>
    /// Interface used for Mapping
    /// </summary>
    public interface IDTO
    {
        Domain.Models.ToDoItem MapItemDTOToAddEntity(BaseToDoItem baseToDo);
        Domain.Models.ToDoItem MapItemDTOToUpdateEntity(BaseToDoItem baseToDo);
        Domain.Models.ToDoList MapListDTOToAddEntity(BaseToDoList baseToDo);
        Domain.Models.ToDoList MapListDTOToUpdateEntity(BaseToDoList baseToDo);
    }
}
