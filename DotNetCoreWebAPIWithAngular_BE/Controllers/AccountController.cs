﻿using DotNetCoreWebAPIWithAngular_BE.Application.Commands.UserFeatures;
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
    }
}
