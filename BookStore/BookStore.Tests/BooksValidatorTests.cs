using BookStore.Domain;
using BookStore.Domain.Contracts.Validators;
using BookStore.Domain.Validation.Exception;
using BookStore.Domain.Validation.Validators;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BookStore.Tests
{
    public class BooksValidatorTests
    {
        [Fact]
        public void BookShouldNotBeValid()
        {
            var book = new Book();
            IBooksValidator validator = new BooksValidator();

            Assert.Throws<ValidationException>(() => validator.Validate(book));
        }

        [Fact]
        public void BookShouldBeValid()
        {
            var book = new Book(Guid.NewGuid(), "Title", "368–22–987–3658–5", DateTime.Now.Year, "Author", "Category");
            IBooksValidator validator = new BooksValidator();

            var validationException = Record.Exception(() => validator.Validate(book));

            Assert.Null(validationException);
        }
    }
}
