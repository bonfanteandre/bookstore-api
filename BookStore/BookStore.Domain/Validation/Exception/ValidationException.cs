using BookStore.Domain.Validation.Errors;
using System;
using System.Collections;
using System.Collections.Generic;

namespace BookStore.Domain.Validation.Exception
{
    public class ValidationException : SystemException
    {
        public ICollection<ValidationError> Errors { get; private set; }

        public ValidationException(ICollection<ValidationError> errors)
        {
            Errors = errors;
        }
    }
}
