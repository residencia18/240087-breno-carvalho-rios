using FluentValidation;
using MediatR;


namespace CleanArchitecture.Application.Shared.Behavior
{
    public sealed class ValidationBehavior<TRequest, TResponse> :
                                        IPipelineBehavior<TRequest, TResponse>
                                        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validatores;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validatores)
        {
            _validatores = validatores;
        }
        public async Task<TResponse> Handle(TRequest request, 
                                    RequestHandlerDelegate<TResponse> next, 
                                    CancellationToken cancellationToken )
        {
            if (!_validatores.Any()) return await next();
            var context = new ValidationContext<TRequest>(request);
            if(_validatores.Any())
            {
                context = new ValidationContext<TRequest>(request);
                var validationResults = await Task.WhenAll(_validatores.Select(v => v.ValidateAsync(context)));
                var failures = validationResults.SelectMany(r => r.Errors).Where(f => f != null).ToList();

                if (failures.Count != 0)
                {
                    throw new FluentValidation.ValidationException(failures);

                }
            }
            return await next();

        }
    }
}
