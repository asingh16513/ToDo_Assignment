using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ToDoService.Controllers
{
    /// <summary>
    /// Base controller for all API's.
    /// </summary>
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        //Brodcaster to pass on service request.
        private IMediator _mediator;
        protected IMediator Mediator => _mediator ?? (_mediator = (IMediator)HttpContext.RequestServices.GetService(typeof(IMediator)));
    }
}
