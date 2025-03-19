using AutoMapper;
using Clinica.Application.Dtos.TakeExam.Response;
using Clinica.Application.Interface.Interfaces;
using Clinica.Application.UseCase.Commons.Bases;
using Clinica.Domain.Entities;
using Clinica.Utilities.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clinica.Application.UseCase.UseCases.TakeExam.Queries.GetByIdQuery
{
    public class GetTakeExamByIdHandler : IRequestHandler<GetTakeExamByIdQuery, BaseResponse<GetTakeExamByIdResponseDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetTakeExamByIdHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<GetTakeExamByIdResponseDto>> Handle(GetTakeExamByIdQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<GetTakeExamByIdResponseDto>();

            try
            {
                var takeExams = await _unitOfWork.TakeExam.GetTakeExamById(request.TakeExamId);
                
                if (takeExams is null)
                {
                    response.IsSuccess = false;
                    response.Message = GlobalMessage.MESSAGE_QUERY_EMPTY;
                    return response;
                }

                takeExams.TakeExamDetails = await _unitOfWork.TakeExam.GetTakeExamDetailByTakeExamId(request.TakeExamId);
                response.IsSuccess = true;
                response.Data = _mapper.Map<GetTakeExamByIdResponseDto>(takeExams);
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
