 using Clinica.Application.Dtos.Exam.Response;
using Clinica.Application.Interface.Interfaces;
using Clinica.Application.UseCase.Commons.Bases;
using Clinica.Application.UseCase.UseCases.Exam.Queries.GetAllQuerie;
using Clinica.Utilities.Constants;
using MediatR;

namespace Clinica.Application.UseCase.UseCases.Exam.Queries.GetAllQuery
{
    public class GetAllExamHandler : IRequestHandler<GetAllExamQuery, BasePaginationResponse<IEnumerable<GetAllExamResponseDto>>>
    {
        //private readonly IExamRepository _examRepository;
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IMapper _mapper;

        public GetAllExamHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BasePaginationResponse<IEnumerable<GetAllExamResponseDto>>> Handle(GetAllExamQuery request, CancellationToken cancellationToken)
        {
            var response = new BasePaginationResponse<IEnumerable<GetAllExamResponseDto>>();

            try
            {
                var count = await _unitOfWork.Exam.CountAsync(Table.Exams); //Count Registers
                var exams = await _unitOfWork.Exam.GetAllExams(StoredProcedure.uspExamList, request);
                if (exams is not null)
                {
                    response.IsSuccess = true;

                    response.PageNumber = request.PageNumber;
                    response.TotalPages = (int)Math.Ceiling(count / (double)request.PageSize);
                    response.TotalCount = count;
                    
                    response.Data = exams;
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
