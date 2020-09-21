using BookStore.Domain.Commands;
using BookStore.Domain.Contracts.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Workflows
{
    public class BooksWorkflow
    {
        private readonly IBooksRepository _booksRepository;

        public BooksWorkflow(IBooksRepository booksRepository)
        {
            _booksRepository = booksRepository;
        }

        public void Add(BookCommand bookCommand)
        {
            Book book = Book.FromBookCommand(bookCommand);
            _booksRepository.Add(book);
        }
        
        public void Update(Guid id, BookCommand bookCommand)
        {
            Book book = _booksRepository.Find(id);

            if (book == null)
            {
                throw new Exception();
            }

            book.Update(bookCommand);

            _booksRepository.Update(book);
        }
        
        public void Remove(Guid id)
        {
            Book book = _booksRepository.Find(id);
            if (book != null)
            {
                _booksRepository.Remove(book);
            }
        }
        
        public ICollection<Book> AllOrderedByName()
        {
            return _booksRepository.AllOrderedByName();
        }

        public Book Find(Guid id)
        {
            return _booksRepository.Find(id);
        }
    }
}
