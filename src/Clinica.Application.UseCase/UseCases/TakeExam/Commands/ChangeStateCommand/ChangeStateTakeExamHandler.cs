﻿using AutoMapper;
using Clinica.Application.Interface.Interfaces;
using Clinica.Application.UseCase.Commons.Bases;
using Clinica.Utilities.Constants;
using MediatR;
using Entity = Clinica.Domain.Entities;

namespace Clinica.Application.UseCase.UseCases.TakeExam.Commands.ChangeStateCommand
{
    public class ChangeStateTakeExamHandler : IRequestHandler<ChangeStateTakeExamCommand, BaseResponse<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ChangeStateTakeExamHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BaseResponse<bool>> Handle(ChangeStateTakeExamCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<bool>();
            try
            {
                var takeExam = _mapper.Map<Entity.TakeExam>(request);
                response.Data = await _unitOfWork.TakeExam.ChangeStateTakeExam(takeExam);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = GlobalMessage.MESSAGE_UPDATE_STATE;
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
