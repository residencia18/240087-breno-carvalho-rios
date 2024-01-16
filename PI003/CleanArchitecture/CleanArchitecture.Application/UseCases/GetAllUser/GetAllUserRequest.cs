using MediatR;


namespace CleanArchitecture.Application.UseCases.GetAllUser
{
    public sealed record GetAllUserRequest(
        string Email, string Name) :
        IRequest<GetAllUserResponse>;
    
}
