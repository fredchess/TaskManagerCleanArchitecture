using FluentValidation;
using MediatR;

namespace TaskManagerCleanArchitecture.Application.Contracts.Infrastructure
{
    public interface IApplicationValidator<T> where T : IValidator
    {
        Task ValidateAndThrow(T validator, IValidationContext request);
    }
}