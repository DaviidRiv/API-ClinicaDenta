using Clinica.Application.UseCase.UseCases.Medic.Commands.ChangeState;
using Clinica.Application.UseCase.UseCases.Medic.Commands.CreateCommand;
using Clinica.Application.UseCase.UseCases.Medic.Commands.DeleteCommand;
using Clinica.Application.UseCase.UseCases.Medic.Commands.UpdateCommand;
using Clinica.Application.UseCase.UseCases.Medic.Queries.GetAllQuery;
using Clinica.Application.UseCase.UseCases.Medic.Queries.GetByIdQuery;
using Clinica.Infraestructure.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class MedicController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MedicController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HasPermission(Permission.ListMedics)]
        [HttpGet]
        public async Task<IActionResult> ListMedics([FromQuery] GetAllMedicQuery query)
        {
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HasPermission(Permission.MedicById)]
        [HttpGet("{medicId:int}")]
        public async Task<IActionResult> MedicById(int medicId)
        {
            var response = await _mediator.Send(new GetMedicByIdQuery() { MedicId = medicId });
            return Ok(response);
        }

        [HasPermission(Permission.RegisterMedic)]
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterMedic([FromBody] CreateMedicCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HasPermission(Permission.EditMedic)]
        [HttpPut("Edit")]
        public async Task<IActionResult> EditMedic([FromBody] UpdateMedicCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HasPermission(Permission.DeleteMedic)]
        [HttpDelete("Delete/{medicId:int}")]
        public async Task<IActionResult> DeleteMedic(int medicId)
        {
            var response = await _mediator.Send(new DeleteMedicCommand { MedicId = medicId });

            return Ok(response);
        }

        [HasPermission(Permission.ChangeStateMedic)]
        [HttpPut("ChangeState")]
        public async Task<IActionResult> ChangeStateMedic([FromBody] ChangeStateMedicCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
