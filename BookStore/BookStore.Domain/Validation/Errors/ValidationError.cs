using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Validation.Errors
{
    public class ValidationError
    {
        public string Message { get; private set; }

        public ValidationError(string message)
        {
            Message = message;
        }
    }
}
