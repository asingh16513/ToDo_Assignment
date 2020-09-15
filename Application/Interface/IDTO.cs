using Domain.Models;

namespace Application.Interface
{
    public interface IDTO
    {
        Domain.Models.ToDoItem MapItemDTOToAddEntity(BaseToDoItem baseToDo);
        Domain.Models.ToDoItem MapItemDTOToUpdateEntity(BaseToDoItem baseToDo);
        Domain.Models.ToDoList MapListDTOToAddEntity(BaseToDoList baseToDo);
        Domain.Models.ToDoList MapListDTOToUpdateEntity(BaseToDoList baseToDo);
    }
}
