using BookStore.Domain.Commands;
using BookStore.Domain.Contracts.Repositories;
using BookStore.Domain.Contracts.Validators;
using BookStore.Domain.Contracts.Workflows;
using BookStore.Domain.Validation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Workflows
{
    public class BooksWorkflow : IBooksWorklflow
    {
        private readonly IBooksRepository _booksRepository;
        private readonly IBooksValidator _booksValidator;

        public BooksWorkflow(IBooksRepository booksRepository, IBooksValidator booksValidator)
        {
            _booksRepository = booksRepository;
            _booksValidator = booksValidator;
        }

        public void Add(BookCommand bookCommand)
        {
            Book book = Book.FromBookCommand(bookCommand);
            _booksValidator.Validate(book);
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
            _booksValidator.Validate(book);
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
