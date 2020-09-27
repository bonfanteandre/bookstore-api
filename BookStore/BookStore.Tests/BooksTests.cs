using BookStore.Domain;
using BookStore.Domain.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BookStore.Tests
{
    public class BooksTests
    {
        [Fact]
        public void CreateBookFromBookCommand()
        {
            var bookCommand = new BookCommand()
            {
                Title = "Book",
                ISBN = "978–85–333–0227–3",
                LaunchYear = DateTime.Now.Year,
                Author = "Author",
                Category = "Category"
            };

            var book = Book.FromBookCommand(bookCommand);

            Assert.Equal(book.Title, bookCommand.Title);
            Assert.Equal(book.ISBN, bookCommand.ISBN);
            Assert.Equal(book.LaunchYear, bookCommand.LaunchYear);
            Assert.Equal(book.Author, bookCommand.Author);
            Assert.Equal(book.Category, bookCommand.Category);
        }

        [Fact]
        public void UpdateBookFromBookCommand()
        {
            var book = new Book(Guid.NewGuid(), "Wrong Title", "368–22–987–3658–5", 1990, "Wrong Author", "Wrong Category");

            var bookCommand = new BookCommand()
            {
                Title = "Book",
                ISBN = "978–85–333–0227–3",
                LaunchYear = DateTime.Now.Year,
                Author = "Author",
                Category = "Category"
            };

            book.Update(bookCommand);

            Assert.Equal(book.Title, bookCommand.Title);
            Assert.Equal(book.ISBN, bookCommand.ISBN);
            Assert.Equal(book.LaunchYear, bookCommand.LaunchYear);
            Assert.Equal(book.Author, bookCommand.Author);
            Assert.Equal(book.Category, bookCommand.Category);
        }
    }
}
