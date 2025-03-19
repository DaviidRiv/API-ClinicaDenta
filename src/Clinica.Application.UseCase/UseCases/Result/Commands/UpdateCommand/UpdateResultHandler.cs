using AutoMapper;
using Clinica.Application.Interface.Interfaces;
using Clinica.Application.Interface.Services;
using Clinica.Application.UseCase.Commons.Bases;
using Clinica.Domain.Entities;
using Clinica.Utilities.Constants;
using MediatR;
using Entity = Clinica.Domain.Entities;

namespace Clinica.Application.UseCase.UseCases.Result.Commands.UpdateCommand
{
    public class UpdateResultHandler : IRequestHandler<UpdateResultCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IFileStorage _fileStorage;

        public UpdateResultHandler(IUnitOfWork unitOfWork, IMapper mapper, IFileStorage fileStorage)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _fileStorage = fileStorage;
        }

        public async Task<BaseResponse<bool>> Handle(UpdateResultCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            using var transaction = _unitOfWork.BeginTransaction();

            try
            {
                var result = _mapper.Map<Entity.Result>(request);
                await _unitOfWork.Result.EditResult(result);

                foreach (var resultFile in request.ResultDetails)
                {
                    var pathFile = await _unitOfWork.Result.GetResultFile(request.ResultId, resultFile.ResultDetailId); //obtener archivo actual

                    var editResultDetail = new ResultDetail
                    {
                        ResultDetailId = resultFile.ResultDetailId,
                        ResultFile = await _fileStorage.EditFile(FileServerContainers.RESULT_FILES, resultFile.ResultFile!, pathFile.ResultFile!),
                        TakeExamDetailId = resultFile.TakeExamDetailId
                    };

                    await _unitOfWork.Result.EditResultDetail(editResultDetail);
                }

                transaction.Complete();
                response.IsSuccess = true;
                response.Message = GlobalMessage.MESSAGE_SAVE;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
