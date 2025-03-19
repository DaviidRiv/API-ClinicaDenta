using Clinica.Application.UseCase.UseCases.Result.Commands.CreateCommand;
using Clinica.Application.UseCase.UseCases.Result.Commands.UpdateCommand;
using Clinica.Application.UseCase.UseCases.Result.Queries.GetAllQuery;
using Clinica.Application.UseCase.UseCases.Result.Queries.GetByIdQuery;
using Clinica.Infraestructure.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ResultController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HasPermission(Permission.ListResults)]
        [HttpGet("ListResults")]
        public async Task<IActionResult> ListResults([FromQuery] GetAllResultQuery query)
        {
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HasPermission(Permission.ResultById)]
        [HttpGet("{resultId:int}")]
        public async Task<IActionResult> ResultById(int resultId)
        {
            var response = await _mediator.Send(new GetResultByIdQuery { ResultId = resultId });
            return Ok(response);
        }

        [HasPermission(Permission.RegisterResult)]
        //FromForm para archivos
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterResult([FromForm] CreateResultCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HasPermission(Permission.EditResult)]
        [HttpPut("Edit")]
        public async Task<IActionResult> EditResult([FromForm] UpdateResultCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);

        }
    }
}
