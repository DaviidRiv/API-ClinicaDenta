using AutoMapper;
using Clinica.Application.Dtos.Medic.Reponse;
using Clinica.Application.Dtos.Patient.Reponse;
using Clinica.Application.Interface.Interfaces;
using Clinica.Application.UseCase.Commons.Bases;
using Clinica.Utilities.Constants;
using MediatR;

namespace Clinica.Application.UseCase.UseCases.Medic.Queries.GetByIdQuery
{
    public class GetMedicByIdHandler : IRequestHandler<GetMedicByIdQuery, BaseResponse<GetMedicByIdResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetMedicByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetMedicByIdResponseDto>> Handle(GetMedicByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetMedicByIdResponseDto>();
            try
            {
                var medic = await _unitOfWork.Medic.GetByIdAsync(StoredProcedure.uspMedicById, request); //pasar id como object

                if (medic is null)
                {
                    response.IsSuccess = false;
                    response.Message = GlobalMessage.MESSAGE_QUERY_EMPTY;
                    return response;
                }
                response.IsSuccess = true;
                response.Data = _mapper.Map<GetMedicByIdResponseDto>(medic);
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
