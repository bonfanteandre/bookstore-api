using BookStore.Domain.Commands;
using BookStore.Domain.Validation;
using BookStore.Domain.Validation.Errors;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain
{
    public class Book
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string ISBN { get; private set; }
        public int LaunchYear { get; private set; }
        public string Author { get; private set; }
        public string Category { get; private set; }

        public static Book FromBookCommand(BookCommand bookCommand)
        {
            return new Book()
            {
                Id = Guid.NewGuid(),
                Title = bookCommand.Title,
                ISBN = bookCommand.ISBN,
                LaunchYear = bookCommand.LaunchYear,
                Author = bookCommand.Author,
                Category = bookCommand.Category
            };
        }

        public void Update(BookCommand bookCommand)
        {
            Title = bookCommand.Title;
            ISBN = bookCommand.ISBN;
            LaunchYear = bookCommand.LaunchYear;
            Author = bookCommand.Author;
            Category = bookCommand.Category;
        }
    }
}
