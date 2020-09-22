using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Contracts.Validators
{
    public interface IBooksValidator
    {
        void Validate(Book book);
    }
}
