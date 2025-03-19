using AutoMapper;
using Clinica.Application.Dtos.Analysis.Response;
using Clinica.Application.Interface.Interfaces;
using Clinica.Application.UseCase.Commons.Bases;
using Clinica.Utilities.Constants;
using MediatR;

namespace Clinica.Application.UseCase.UseCases.Analysis.Queries.GetAllQuery
{
    public class GetAllAnalysisHandler : IRequestHandler<GetAllAnalysisQuery, BasePaginationResponse<IEnumerable<GetAllAnalysisResponseDto>>>
    {
        //private readonly IAnalysisRepository _analysisRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllAnalysisHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BasePaginationResponse<IEnumerable<GetAllAnalysisResponseDto>>> Handle(GetAllAnalysisQuery request, CancellationToken cancellationToken)
        {
            var response = new BasePaginationResponse<IEnumerable<GetAllAnalysisResponseDto>>();

            try
            {
                var count = await _unitOfWork.Analysis.CountAsync(Table.Analysis); //Count Registers
                var analysis = await _unitOfWork.Analysis.GetAllWithPagination(StoredProcedure.uspAnalysisList, request);
                if (analysis is not null)
                {
                    response.IsSuccess = true;

                    response.PageNumber = request.PageNumber;
                    response.TotalPages = (int)Math.Ceiling(count /(double)request.PageSize);
                    response.TotalCount = count;

                    response.Data = _mapper.Map<IEnumerable<GetAllAnalysisResponseDto>>(analysis);
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


