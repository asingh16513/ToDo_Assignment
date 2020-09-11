﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Application.Helper;
using Application.ToDoList.Command.AddToDoList;
using Application.ToDoList.Command.UpdateCommand;
using Application.ToDoList.Query.DeleteToDoListQuery;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ToDoService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoListController : BaseController
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [Route("AddToDoList")]
        public async Task<ActionResult> AddToDoList([FromBody]AddToDoListCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

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

        [HttpDelete]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(int), (int)HttpStatusCode.OK)]
        [Route("DeleteToDoList")]
        public async Task<ActionResult> DeleteToDoList([FromQuery]DeleteToDoListQuery command)
        {
            return Ok(await Mediator.Send(command));
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(List<Domain.Models.ToDoListExt>), (int)HttpStatusCode.OK)]
        [Route("GetToDoList")]
        public async Task<ActionResult> GetToDoList([FromQuery]EmptyQuery<List<Domain.Models.ToDoListExt>> command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}