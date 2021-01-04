using System;
using System.Collections.Generic;
using ExportManagementAPI.Domain.Entities.API;
using FluentValidation.Results;

namespace ExportManagementAPI.Domain.Exceptions
{
    public class ValidationException : Exception
    {
        public List<ErrorEntity> Errors { get; }

        public ValidationException() : base("One or more validation failures have occurred.")
        {
            Errors = new List<ErrorEntity>();
        }

        public ValidationException(IEnumerable<ValidationFailure> failures)
            : this()
        {
            foreach (var failure in failures)
            {
                Errors.Add(new ErrorEntity()
                {
                    PropertyName = failure.PropertyName,
                    ErrorMessage = failure.ErrorMessage,
                });
            }
        }
    }
}