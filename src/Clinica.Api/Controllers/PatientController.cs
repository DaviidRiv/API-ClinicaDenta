using Clinica.Application.UseCase.UseCases.Patient.Commands.ChangeStateCommand;
using Clinica.Application.UseCase.UseCases.Patient.Commands.CreateCommand;
using Clinica.Application.UseCase.UseCases.Patient.Commands.DeleteCommand;
using Clinica.Application.UseCase.UseCases.Patient.Commands.UpdateCommand;
using Clinica.Application.UseCase.UseCases.Patient.Queries.GetAllQuery;
using Clinica.Application.UseCase.UseCases.Patient.Queries.GetByIdQuery;
using Clinica.Infraestructure.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PatientController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HasPermission(Permission.ListPatients)]
        [HttpGet("ListPatients")]
        public async Task<IActionResult> ListPatients([FromQuery] GetAllPatientQuery query)
        {
            var response = await _mediator.Send(query); 
            return Ok(response);
        }

        [HasPermission(Permission.PatientById)]
        [HttpGet("{patientId:int}")]
        public async Task<IActionResult> PatientById(int patientId)
        {
            var response = await _mediator.Send(new GetPatientByIdQuery() { PatientId = patientId });
            return Ok(response);
        }

        [HasPermission(Permission.RegisterPatient)]
        [HttpPost("Register")]
        public async Task<IActionResult> RegisterPatient([FromBody] CreatePatientCommand command)
        {
            var response = await _mediator.Send(command);
            return Ok(response);
        }

        [HasPermission(Permission.EditPatient)]
        [HttpPut("Edit")]
        public async Task<IActionResult> EditPatient([FromBody] UpdatePatientCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HasPermission(Permission.DeletePatient)]
        [HttpDelete("Delete/{patientId:int}")]
        public async Task<IActionResult> DeletePatient(int patientId)
        {
            var response = await _mediator.Send(new DeletePatientCommand { PatientId = patientId });

            return Ok(response);
        }

        [HasPermission(Permission.ChangeStatePatient)]
        [HttpPut("ChangeState")]
        public async Task<IActionResult> ChangeStatePatient([FromBody] ChangeStatePatientCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}