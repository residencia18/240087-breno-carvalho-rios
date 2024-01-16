using FluentValidation;

namespace CleanArchitecture.Application.UseCases.GetAllUser
{
    public sealed class GetAllUserValidator : AbstractValidator<GetAllUserRequest>
    {
        public GetAllUserValidator() 
        {
            RuleFor(x => x.Email).NotEmpty().MaximumLength(50).EmailAddress();
            RuleFor(x => x.Name).NotEmpty().MaximumLength(3).MaximumLength(50);
        }
    }
}
