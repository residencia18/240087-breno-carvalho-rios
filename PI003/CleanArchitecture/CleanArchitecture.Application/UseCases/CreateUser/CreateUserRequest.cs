using MediatR;

namespace ResTIConnect.Application.UseCases.CreateUser
{
    public sealed record CreateUserRequest(string Email, string Name) :
                                        IRequest<CreateUserResponse>;
}
