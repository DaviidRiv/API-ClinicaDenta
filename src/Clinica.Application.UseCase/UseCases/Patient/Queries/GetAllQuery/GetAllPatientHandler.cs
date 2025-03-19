using Clinica.Application.Dtos.Patient.Reponse;
using Clinica.Application.Interface.Interfaces;
using Clinica.Application.UseCase.Commons.Bases;
using Clinica.Utilities.Constants;
using MediatR;

namespace Clinica.Application.UseCase.UseCases.Patient.Queries.GetAllQuery
{
    public class GetAllPatientHandler : IRequestHandler<GetAllPatientQuery, BasePaginationResponse<IEnumerable<GetAllPatientResponseDto>>>
    {
        //private readonly IExamRepository _examRepository;
        private readonly IUnitOfWork _unitOfWork;
        //private readonly IMapper _mapper;

        public GetAllPatientHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<BasePaginationResponse<IEnumerable<GetAllPatientResponseDto>>> Handle(GetAllPatientQuery request, CancellationToken cancellationToken)
        {
            var response = new BasePaginationResponse<IEnumerable<GetAllPatientResponseDto>>();

            try
            {
                var count = await _unitOfWork.Medic.CountAsync(Table.Patients); //Count Registers
                var patients = await _unitOfWork.Patient.GetAllPatients(StoredProcedure.uspPatientList, request);
                if (patients is not null)
                {
                    response.IsSuccess = true;

                    response.PageNumber = request.PageNumber;
                    response.TotalPages = (int)Math.Ceiling(count / (double)request.PageSize);
                    response.TotalCount = count;

                    response.Data = patients;
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
