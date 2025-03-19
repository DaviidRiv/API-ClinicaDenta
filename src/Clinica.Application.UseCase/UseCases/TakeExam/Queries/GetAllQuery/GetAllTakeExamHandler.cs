using AutoMapper;
using Clinica.Application.Dtos.TakeExam.Response;
using Clinica.Application.Interface.Interfaces;
using Clinica.Application.UseCase.Commons.Bases;
using Clinica.Utilities.Constants;
using MediatR;

namespace Clinica.Application.UseCase.UseCases.TakeExam.Queries.GetAllQuery
{
    public class GetAllTakeExamHandler : IRequestHandler<GetAllTakeExamQuery, BasePaginationResponse<IEnumerable<GetAllTakeExamResponseDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllTakeExamHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BasePaginationResponse<IEnumerable<GetAllTakeExamResponseDto>>> Handle(GetAllTakeExamQuery request, CancellationToken cancellationToken)
        {
            var response = new BasePaginationResponse<IEnumerable<GetAllTakeExamResponseDto>>();

            try
            {
                var count = await _unitOfWork.TakeExam.CountAsync(Table.TakeExam); //Count Registers
                var takeExams = await _unitOfWork.TakeExam.GetAllTakeExams(StoredProcedure.uspTakeExamList, request);
                if (takeExams is not null)
                {
                    response.IsSuccess = true;

                    response.PageNumber = request.PageNumber;
                    response.TotalPages = (int)Math.Ceiling(count / (double)request.PageSize);
                    response.TotalCount = count;

                    response.Data = takeExams;
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
