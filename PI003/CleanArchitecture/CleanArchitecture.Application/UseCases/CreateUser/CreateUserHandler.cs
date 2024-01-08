using AutoMapper;
using MediatR;
using ResTIConnect.Domain.Entities;
using ResTIConnect.Domain.Interfaces;

namespace ResTIConnect.Application.UseCases.CreateUser
{
    public class CreateUserHandler :
        IRequestHandler<CreateUserRequest, CreateUserResponse>
    {
        private readonly IUnitofWork _unitOfWork;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserHandler(IUnitofWork unitofWork, IUserRepository userRepository, IMapper mapper)
        {
            _unitOfWork = unitofWork;
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<CreateUserResponse> Handle(CreateUserRequest request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);

            _userRepository.Create(user);

            await _unitOfWork.Commit(cancellationToken);

            return _mapper.Map<CreateUserResponse>(user);
        }
    }
}
