using AutoMapper;
using Clinica.Application.Interface.Interfaces;
using Clinica.Application.UseCase.Commons.Bases;
using Clinica.Domain.Entities;
using Clinica.Utilities.Constants;
using MediatR;
using Entity = Clinica.Domain.Entities;

namespace Clinica.Application.UseCase.UseCases.TakeExam.Commands.UpdateCommand
{
    public class UpdateTakeExamHandler : IRequestHandler<UpdateTakeExamCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTakeExamHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateTakeExamCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            using var transaction = _unitOfWork.BeginTransaction();
            try
            {
                var takeExam = _mapper.Map<Entity.TakeExam>(request);
                await _unitOfWork.TakeExam.UpdateTakeExam(takeExam);

                foreach (var takeExamDetail in request.TakeExamDetails)
                {
                    var entity = new TakeExamDetail
                    {
                        ExamId = takeExamDetail.ExamId,
                        AnalysisId = takeExamDetail.AnalysisId,
                        TakeExamDetailId = takeExamDetail.TakeExamDetailId
                    };
                    await _unitOfWork.TakeExam.UpdateTakeExamDetail(entity);
                }
                transaction.Complete(); //completar a la base de datos
                response.IsSuccess = true;
                response.Message = GlobalMessage.MESSAGE_UPDATE;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
    }
}
