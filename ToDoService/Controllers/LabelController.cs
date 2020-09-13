using Application.Helper;
using Application.Label.Command.AddLabel;
using Application.Label.Command.AssignItemLabel;
using Application.Label.Command.AssignLabelToList;
using Application.Label.Queries.DeleteLabelById;
using Application.Label.Queries.GetLabelById;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;

namespace ToDoService.Controllers
{
    [Route("api/{v:apiVersion}/[controller]")]
    public class LabelController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Domain.Models.Label>), (int)HttpStatusCode.OK)]
        [Route("GetLabels")]
        public async Task<ActionResult> GetLabels([FromQuery]EmptyQuery<List<Domain.Models.Label>> query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [Route("AddLabel")]
        public async Task<ActionResult> AddLabel([FromBody]AddLabelCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Domain.Models.Label>), (int)HttpStatusCode.OK)]
        [Route("GetLabelById")]
        public async Task<ActionResult> GetLabelById([FromQuery]GetLabelByIdQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [Route("DeleteLabelById")]
        public async Task<ActionResult> DeleteLabelById([FromQuery]DeleteLabelByIdQuery query)
        {
            return Ok(await Mediator.Send(query));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [Route("AssignLabelToItem")]
        public async Task<ActionResult> AssignLabelToItem([FromBody]AssignItemLabelCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [Route("AssignLabelToList")]
        public async Task<ActionResult> AssignLabelToList([FromBody]AssignLabelToListCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}