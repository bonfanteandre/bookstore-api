using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Validation
{
    public interface IValidable
    {
        void Validate();
    }
}
