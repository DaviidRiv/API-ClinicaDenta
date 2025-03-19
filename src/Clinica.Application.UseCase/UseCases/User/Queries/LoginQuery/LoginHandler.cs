using Clinica.Application.Interface.Authentication;
using Clinica.Application.Interface.Interfaces;
using Clinica.Application.UseCase.Commons.Bases;
using Clinica.Utilities.Constants;
using MediatR;
using BC = BCrypt.Net.BCrypt;

namespace Clinica.Application.UseCase.UseCases.User.Queries.LoginQuery
{
    public class LoginHandler : IRequestHandler<LoginQuery, BaseResponse<string>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public LoginHandler(IUnitOfWork unitOfWork, IJwtTokenGenerator jwtTokenGenerator)
        {
            _unitOfWork = unitOfWork;
            _jwtTokenGenerator = jwtTokenGenerator;
        }

        public async Task<BaseResponse<string>> Handle(LoginQuery request, CancellationToken cancellationToken)
        {
            var response = new BaseResponse<string>();
            try
            {
                var user = await _unitOfWork.User.GetUserByEmailAsync(StoredProcedure.uspUserByEmail, request.Email!);
                if (user == null)
                {
                    response.IsSuccess = false;
                    response.Message = GlobalMessage.MESSAGE_TOKEN_ERROR;
                    return response;
                }

                if (!BC.Verify(request.Password, user.Password))
                {
                    response.IsSuccess = false;
                    response.Message = GlobalMessage.MESSAGE_ERROR_PASSWORD;
                    return response;
                }

                response.IsSuccess = true;
                response.Data = _jwtTokenGenerator.GenerateToken(user);
                response.Message = GlobalMessage.MESSAGE_TOKEN;
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
