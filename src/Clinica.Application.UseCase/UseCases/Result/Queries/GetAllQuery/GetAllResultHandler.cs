using Clinica.Application.Dtos.Result.Response;
using Clinica.Application.Interface.Interfaces;
using Clinica.Application.UseCase.Commons.Bases;
using Clinica.Utilities.Constants;
using MediatR;

namespace Clinica.Application.UseCase.UseCases.Result.Queries.GetAllQuery
{
    public class GetAllResultHandler : IRequestHandler<GetAllResultQuery, BasePaginationResponse<IEnumerable<GetAllResultResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public GetAllResultHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BasePaginationResponse<IEnumerable<GetAllResultResponseDto>>> Handle(GetAllResultQuery request, CancellationToken cancellationToken)
        {
            var response = new BasePaginationResponse<IEnumerable<GetAllResultResponseDto>>();
            try
            {
                var count = await _unitOfWork.Result.CountAsync(Table.Results);
                var results = await _unitOfWork.Result.GetAllResults(StoredProcedure.uspResultList, request);
                if (results is not null)
                {
                    response.IsSuccess = true;
                    response.PageNumber = request.PageNumber;
                    response.TotalPages = (int)Math.Ceiling(count / (double)request.PageSize);
                    response.TotalCount = count;
                    response.Data = results;
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
