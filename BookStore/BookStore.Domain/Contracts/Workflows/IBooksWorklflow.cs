using BookStore.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Contracts.Workflows
{
    public interface IBooksWorklflow
    {
        void Add(BookCommand bookCommand);
        void Update(Guid id, BookCommand bookCommand);
        void Remove(Guid id);
        ICollection<Book> AllOrderedByName();
        Book Find(Guid id);
    }
}
