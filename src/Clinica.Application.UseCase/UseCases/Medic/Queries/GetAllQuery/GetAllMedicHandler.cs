using Clinica.Application.Dtos.Medic.Reponse;
using Clinica.Application.Interface.Interfaces;
using Clinica.Application.UseCase.Commons.Bases;
using Clinica.Utilities.Constants;
using MediatR;

namespace Clinica.Application.UseCase.UseCases.Medic.Queries.GetAllQuery
{
    public class GetAllMedicHandler : IRequestHandler<GetAllMedicQuery, BasePaginationResponse<IEnumerable<GetAllMedicResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllMedicHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BasePaginationResponse<IEnumerable<GetAllMedicResponseDto>>> Handle(GetAllMedicQuery request, CancellationToken cancellationToken)
        {
            var response = new BasePaginationResponse<IEnumerable<GetAllMedicResponseDto>>();

            try
            {
                var count = await _unitOfWork.Medic.CountAsync(Table.Medics); //Count Registers
                var medics = await _unitOfWork.Medic.GetAllMedics(StoredProcedure.uspMedicList, request);
                if (medics is not null)
                {
                    response.IsSuccess = true;

                    response.PageNumber = request.PageNumber;
                    response.TotalPages = (int)Math.Ceiling(count / (double)request.PageSize);
                    response.TotalCount = count;

                    response.Data = medics;
                    response.Message = GlobalMessage.MESSAGE_QUERY;
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
