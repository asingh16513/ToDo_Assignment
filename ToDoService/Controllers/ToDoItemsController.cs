using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Application.Helper;
using Application.ToDoItem.Command.AddToDoItem;
using Application.ToDoItem.Command.UpdateCommand;
using Application.ToDoItem.Query.DeleteToDoItemQuery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ToDoService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoItemsController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [Route("AddToDoItem")]
        public async Task<ActionResult> AddToDoItem([FromBody]AddToDoItemCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [Route("UpdateToDoItem")]
        public async Task<ActionResult> UpdateToDoItem(int itemId, [FromBody]UpdateToDoItemCommand command)
        {
            command.ToDoItem.Id = itemId;
            return Ok(await Mediator.Send(command));
        }


        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [Route("DeleteToDoItem")]
        public async Task<ActionResult> DeleteToDoItem([FromQuery]DeleteToDoItemQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Domain.Models.ToDoItemExt>), (int)HttpStatusCode.OK)]
        [Route("GetToDoItems")]
        public async Task<ActionResult> GetToDoItems([FromQuery]EmptyQuery<List<Domain.Models.ToDoItemExt>> command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}