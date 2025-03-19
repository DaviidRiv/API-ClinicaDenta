using Clinica.Application.UseCase.UseCases.Analysis.Commands.ChangeStateCommand;
using Clinica.Application.UseCase.UseCases.Analysis.Commands.CreateCommand;
using Clinica.Application.UseCase.UseCases.Analysis.Commands.DeleteCommand;
using Clinica.Application.UseCase.UseCases.Analysis.Commands.UpdateCommand;
using Clinica.Application.UseCase.UseCases.Analysis.Queries.GetAllQuery;
using Clinica.Application.UseCase.UseCases.Analysis.Queries.GetByIdQuery;
using Clinica.Infraestructure.Authentication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clinica.Api.Controllers
{
    //ENDPOINTS
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AnalysisController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnalysisController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HasPermission(Permission.ListAnalysis)]
        [HttpGet]
        public async Task<IActionResult> ListAnalysis([FromQuery] GetAllAnalysisQuery query)
        {
            var response = await _mediator.Send(query);

            return Ok(response);
        }

        [HasPermission(Permission.AnalysisById)]
        [HttpGet("{analysisId:int}")]
        public async Task<IActionResult> AnalysisById(int analysisId)
        {
            var response = await _mediator.Send(new GetAnalysisByIdQuery() { AnalysisId = analysisId });

            return Ok(response);
        }

        [HasPermission(Permission.AnalysisRegister)]
        [HttpPost("Register")]
        public async Task<IActionResult> AnalysisRegister([FromBody] CreateAnalysisCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }


        [HasPermission(Permission.AnalysisEdit)]
        [HttpPut("Edit")]
        public async Task<IActionResult> AnalysisEdit([FromBody] UpdateAnalysisCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }

        [HasPermission(Permission.AnalysisDelete)]
        [HttpDelete("Delete/{analysisId:int}")]
        public async Task<IActionResult> AnalysisDelete(int analysisId)
        {
            var response = await _mediator.Send(new DeleteAnalysisCommand() { AnalysisId = analysisId });

            return Ok(response);
        }

        [HasPermission(Permission.ChangeStateAnalysis)]
        [HttpPut("ChangeStateAnalysis")]
        public async Task<IActionResult> ChangeState([FromBody] ChangeStateAnalysisCommand command)
        {
            var response = await _mediator.Send(command);

            return Ok(response);
        }
    }
}
