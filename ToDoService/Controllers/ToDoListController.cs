using Application.Helper;
using Application.ToDoList.Command.AddToDoList;
using Application.ToDoList.Command.UpdateCommand;
using Application.ToDoList.Query.DeleteToDoListQuery;
using Application.ToDoList.Query.SearchToDoList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ToDoService.Controllers
{
    /// <summary>
    /// Controller for CRUD operations for todolist
    /// </summary>
    [Route("api/{v:apiVersion}/[controller]")]
    public class ToDoListController : BaseController
    {
        /// <summary>
        /// Mehtod to add new todolist
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [Route("AddToDoList")]
        public async Task<ActionResult> AddToDoList([FromBody]AddToDoListCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Method to update todolist by id
        /// </summary>
        /// <param name="itemId"></param>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [Route("UpdateToDoList")]
        public async Task<ActionResult> UpdateToDoList(int itemId, [FromBody]UpdateToDoListCommand command)
        {
            command.ToDoList.Id = itemId;
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Method to delete todolist by id
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [Route("DeleteToDoList")]
        public async Task<ActionResult> DeleteToDoList([FromQuery]DeleteToDoListQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Method to get collection of todolists
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Domain.Models.ToDoListExt>), (int)HttpStatusCode.OK)]
        [Route("GetToDoList")]
        public async Task<ActionResult> GetToDoList([FromQuery]EmptyQuery<List<Domain.Models.ToDoListExt>> command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Method to get collection of todolist based on search criteria and pagesize
        /// </summary>
        /// <param name="query"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Domain.Models.ToDoItemExt>), (int)HttpStatusCode.OK)]
        [Route("SearchToDoList")]
        public async Task<ActionResult> SearchToDoItems([FromQuery]SearchToDoListQuery query)
        {
            return Ok(await Mediator.Send(query));
        }
    }
}