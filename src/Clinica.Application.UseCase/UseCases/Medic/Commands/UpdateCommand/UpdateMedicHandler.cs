using AutoMapper;
using Clinica.Application.Interface.Interfaces;
using Clinica.Application.UseCase.Commons.Bases;
using Clinica.Utilities.Constants;
using Clinica.Utilities.HelperExtensions;
using MediatR;
using Entity = Clinica.Domain.Entities;

namespace Clinica.Application.UseCase.UseCases.Medic.Commands.UpdateCommand
{
    public class UpdateMedicHandler : IRequestHandler<UpdateMedicCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateMedicHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<BaseResponse<bool>> Handle(UpdateMedicCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var medic = _mapper.Map<Entity.Medic>(request);
                var parameters = medic.GetPropertiesWithValues();//solo propiedades con valores
                response.Data = await _unitOfWork.Medic.ExecAsync(StoredProcedure.uspMedicEdit, parameters);

                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = GlobalMessage.MESSAGE_UPDATE;
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
