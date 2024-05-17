using DotNetCoreWebAPIWithAngular_BE.Application.Commands.UserFeatures;
using DotNetCoreWebAPIWithAngular_BE.Application.Commands.UserFeatures.Models;
using DotNetCoreWebAPIWithAngular_BE.Application.Queries.UserFeatures.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace DotNetCoreWebAPIWithAngular_BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Resgister(CreateUserCommand command)
        {
            var result = await _mediator.Send(command);

            return result.IsSuccessed ? Ok(result) : BadRequest(result);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(CreateUserCommand command)
        {
            var result = await _mediator.Send(command);

            return result.IsSuccessed ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetAllUser")]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetAllUserQuery());

            return result.IsSuccessed ? Ok(result) : BadRequest(result);
        }

        [HttpGet("GetUserById/{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var result = await _mediator.Send(new GetUserByIdQuery { Id = id });

            return result.IsSuccessed ? Ok(result) : BadRequest(result);
        }
    }
}
