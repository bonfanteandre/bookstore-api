using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Contracts.Repositories
{
    public interface IBooksRepository
    {
        void Add(Book book);
        void Update(Book book);
        void Remove(Book book);
        ICollection<Book> AllOrderedByName();
        Book Find(Guid id);
    }
}
