using Application.Interface;
using MediatR;
using Persistence;
using System.Threading;
using System.Threading.Tasks;

namespace Application.ToDoItem.Command.PatchUpdateToDoItem
{
    public class UpdatePatchToDoItemCommandHandler : IRequestHandler<UpdatePatchToDoItemCommand, int>
    {
        private readonly IPatchToDo _patchToDo;
        private readonly IDTO _dtoMapper;
        private readonly IInstanceDB _instanceDB;

        public UpdatePatchToDoItemCommandHandler(IPatchToDo patchToDo, IDTO dtoMapper, IInstanceDB instanceDB)
        {
            _patchToDo = patchToDo;
            _dtoMapper = dtoMapper;
            _instanceDB = instanceDB;
        }
        public async Task<int> Handle(UpdatePatchToDoItemCommand request, CancellationToken cancellationToken)
        {
            var db = _instanceDB.Get<IToDoItemDbManager>();
            Domain.Models.ToDoItem item = _dtoMapper.MapItemDTOToUpdateEntity(await db.GetToDoItem(request.ItemId));
            var patch = _patchToDo.ItemToCommand(item);
            if (item != null)
            {
                request.JsonPatchDocument.ApplyTo(patch);
            }
            return await db.UpdateToDoItem(item);
        }
    }
}
