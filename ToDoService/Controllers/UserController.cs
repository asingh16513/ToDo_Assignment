using Application.User.Command.AuthenticateUser;
using Application.User.Command.RegisterUser;
using Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace ToDoService.Controllers
{
    [Route("api/{v:apiVersion}/[controller]")]
    public class UserController : BaseController
    {
        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(UserAuthResult), (int)HttpStatusCode.OK)]
        [Route("Login")]
        public async Task<ActionResult> Authenticate([FromBody]AuthenticateUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        [AllowAnonymous]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Domain.Models.User), (int)HttpStatusCode.OK)]
        [Route("RegisterUser")]
        public async Task<ActionResult> RegisterUser([FromBody]RegisterUserCommand command)
        {
            return Ok(await Mediator.Send(command));
        }
    }
}