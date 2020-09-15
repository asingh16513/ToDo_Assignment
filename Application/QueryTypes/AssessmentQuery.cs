using Persistence;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Application.QueryTypes
{
    public class AssessmentQuery
    {
        /// <summary>
        /// The product service
        /// </summary>
        private readonly IToDoListDbManager _todoListService;
        private readonly IToDoItemDbManager _todoitemService;
        private readonly ILabelDBManager _labelService;


        /// <summary>
        /// Initializes a new instance of the <see cref="Query"/> class.
        /// </summary>
        /// <param name="productService">The product service.</param>
        public AssessmentQuery(IToDoItemDbManager service, ILabelDBManager labelService, IToDoListDbManager todoListService)
        {
            _todoListService = todoListService;
            _todoitemService = service;
            _labelService = labelService;
        }


        public Task<List<Domain.Models.Label>> GetLabels() => _labelService.GetLabels();


        // public List<ToDoItemDTO> GetToDoItems(Contract.Core.Contract.PagingDTO dto) => _todoitemService.GetToDoItem(pagingDto).ToList();


    }








}
