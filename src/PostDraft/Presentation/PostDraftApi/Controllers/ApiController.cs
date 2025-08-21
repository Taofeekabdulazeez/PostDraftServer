using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PostDraftApi.Controllers
{
    public class ApiController : ControllerBase
    {
        protected IMediator _mediator => HttpContext.RequestServices.GetRequiredService<IMediator>();
    }
}
