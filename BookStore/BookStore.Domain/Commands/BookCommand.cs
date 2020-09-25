using System;
using System.Collections.Generic;
using System.Text;

namespace BookStore.Domain.Commands
{
    public class BookCommand
    {
        public string Title { get; set; }
        public string ISBN { get; set; }
        public int LaunchYear { get; set; }
        public string Author { get; set; }
        public string Category { get; set; }
    }
}
