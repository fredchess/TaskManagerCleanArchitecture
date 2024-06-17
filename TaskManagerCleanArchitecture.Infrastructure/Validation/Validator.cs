using FluentValidation;
using MediatR;
using TaskManagerCleanArchitecture.Application.Contracts.Infrastructure;
using TaskManagerCleanArchitecture.Application;
using TaskManagerCleanArchitecture.Application.Exceptions;

namespace TaskManagerCleanArchitecture.Infrastructure.Validation
{
    public class Validator<T> : IApplicationValidator<T> where T : IValidator
    {
        public async Task ValidateAndThrow(T validator, IValidationContext request)
        {
            var validationResult = await validator.ValidateAsync(request);

            if (validationResult.Errors.Count > 0)
            {
                throw new Application.Exceptions.ValidationException(validationResult);
            }
        }
    }
}