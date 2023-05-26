using FluentValidation;
using ServiceStation.BLL.DTO.Requests;

namespace ServiceStation.BLL.Validation
{
    public class ClientSignInRequestValidator : AbstractValidator<ClientSignInRequest>
    {
        public ClientSignInRequestValidator()
        {
            RuleFor(request => request.UserName)
                .NotEmpty()
                .WithMessage("UserName can't be empty.");

            RuleFor(request => request.Password)
                .NotEmpty()
                .WithMessage("Password can't be empty.");
        }
    }
}
