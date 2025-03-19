using Clinica.Application.UseCase.UseCases.User.Command.CreateCommand;
using Clinica.Application.UseCase.UseCases.User.Queries.LoginQuery;
using Clinica.Infraestructure.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> LoginUser([FromBody] LoginQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HasPermission(Permission.RegisterUser)]
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterUser([FromBody] CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
