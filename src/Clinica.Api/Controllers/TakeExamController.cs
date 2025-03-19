using Clinica.Application.UseCase.UseCases.TakeExam.Commands.ChangeStateCommand;
using Clinica.Application.UseCase.UseCases.TakeExam.Commands.CreateCommand;
using Clinica.Application.UseCase.UseCases.TakeExam.Commands.UpdateCommand;
using Clinica.Application.UseCase.UseCases.TakeExam.Queries.GetAllQuery;
using Clinica.Application.UseCase.UseCases.TakeExam.Queries.GetByIdQuery;
using Clinica.Infraestructure.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class TakeExamController : Controller
    {
        private readonly IMediator _mediator;

        public TakeExamController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HasPermission(Permission.ListTakeExams)]
        [HttpGet]
        public async Task<IActionResult> ListTakeExams([FromQuery] GetAllTakeExamQuery query)
        {
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HasPermission(Permission.TakeExamById)]
        [HttpGet("{takeExamId:int}")]
        public async Task<IActionResult> TakeExamById(int takeExamId)
        {
            var response = await _mediator.Send(new GetTakeExamByIdQuery() { TakeExamId = takeExamId });

            return Ok(response);
        }

        [HasPermission(Permission.RegisterTakeExam)]
        [HttpPost]
        public async Task<IActionResult> RegisterTakeExam([FromBody] CreateTakeExamCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HasPermission(Permission.UpdateTakeExam)]
        [HttpPut("Edit")]
        public async Task<IActionResult> UpdateTakeExam([FromBody] UpdateTakeExamCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HasPermission(Permission.ChangeStateTakeExam)]
        [HttpPut("ChangeState")]
        public async Task<IActionResult> ChangeStateTakeExam([FromBody] ChangeStateTakeExamCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }
    }
}
