using BlazorAppForClient.ViewModels;
using FluentValidation;

namespace BlazorAppForClient.Validation
{
    public class UserViewModelValidator : AbstractValidator<UserViewModel>
    {
        public UserViewModelValidator()
        {
            RuleFor(request => request.Email)
                .EmailAddress()
                .WithMessage("Wrong email address.");

            RuleFor(request => request.FirstName)
                .NotEmpty()
                .WithMessage(request => $"{nameof(request.FirstName)} can't be empty.")
                .MaximumLength(50)
                .WithMessage(request => $"{nameof(request.FirstName)} should be less than 50 characters.");

            RuleFor(request => request.LastName)
                .NotEmpty()
                .WithMessage(request => $"{nameof(request.LastName)} can't be empty.")
                .MaximumLength(50)
                .WithMessage(request => $"{nameof(request.LastName)} should be less than 50 characters.");

           

            
        }
    }
}
