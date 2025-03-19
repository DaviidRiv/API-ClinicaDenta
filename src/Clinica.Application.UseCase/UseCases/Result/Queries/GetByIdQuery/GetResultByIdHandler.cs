using AutoMapper;
using Clinica.Application.Dtos.Result.Response;
using Clinica.Application.Interface.Interfaces;
using Clinica.Application.UseCase.Commons.Bases;
using Clinica.Utilities.Constants;
using MediatR;

namespace Clinica.Application.UseCase.UseCases.Result.Queries.GetByIdQuery
{
    public class GetResultByIdHandler : IRequestHandler<GetResultByIdQuery, BaseResponse<GetResultByIdResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetResultByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetResultByIdResponseDto>> Handle(GetResultByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetResultByIdResponseDto>();
            try
            {
                var results = await _unitOfWork.Result.GetResultById(request.ResultId);
                results.ResultDetails = await _unitOfWork.Result.GetResultDetailByResultId(request.ResultId);

                response.IsSuccess = true;
                response.Data = _mapper.Map<GetResultByIdResponseDto>(results);
                response.Message = GlobalMessage.MESSAGE_QUERY;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
