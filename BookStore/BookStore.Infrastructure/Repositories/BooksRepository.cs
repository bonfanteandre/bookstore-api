using BookStore.Domain;
using BookStore.Domain.Contracts.Repositories;
using BookStore.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookStore.Infrastructure.Repositories
{
    public class BooksRepository : IBooksRepository
    {
        private readonly BookStoreContext _context;

        public BooksRepository(BookStoreContext context)
        {
            _context = context;
        }

        public void Add(Book book)
        {
            _context.Books.Add(book);
            _context.SaveChanges();
        }

        public ICollection<Book> AllOrderedByName()
        {
            return _context.Books.OrderBy(book => book.Title).ToList();
        }

        public Book Find(Guid id)
        {
            return _context.Books.FirstOrDefault(book => book.Id.Equals(id));
        }

        public void Remove(Book book)
        {
            _context.Books.Remove(book);
            _context.SaveChanges();
        }

        public void Update(Book book)
        {
            _context.Books.Update(book);
            _context.SaveChanges();
        }
    }
}
