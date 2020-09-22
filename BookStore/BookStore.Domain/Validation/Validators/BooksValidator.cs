using BookStore.Domain.Contracts.Validators;
using BookStore.Domain.Validation.Errors;
using BookStore.Domain.Validation.Exception;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Validation.Validators
{
    public class BooksValidator : IBooksValidator
    {
        private ICollection<ValidationError> _validationErrors;

        public BooksValidator()
        {
            _validationErrors = new List<ValidationError>();
        }

        public void Validate(Book book)
        {
            if (string.IsNullOrWhiteSpace(book.Title))
            {
                _validationErrors.Add(new ValidationError("Título é um campo obrigatório"));
            }

            if (string.IsNullOrWhiteSpace(book.ISBN))
            {
                _validationErrors.Add(new ValidationError("ISBN é um campo obrigatório"));
            }

            if (book.LauchYear <= 0 || book.LauchYear > DateTime.Now.Year)
            {
                _validationErrors.Add(new ValidationError("Ano de lançamento inválido"));
            }

            if (string.IsNullOrWhiteSpace(book.Author))
            {
                _validationErrors.Add(new ValidationError("Autor é um campo obrigatório"));
            }

            if (string.IsNullOrWhiteSpace(book.Category))
            {
                _validationErrors.Add(new ValidationError("Categoria é um campo obrigatório"));
            }

            if (_validationErrors.Count > 0)
            {
                throw new ValidationException(_validationErrors);
            }
        }
    }
}
