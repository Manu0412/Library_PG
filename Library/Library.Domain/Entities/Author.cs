using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Domain.Entities
{
    public sealed class Author
    {
        public int Id { get; private set; }
        public string Name { get; private set; } = null;


        public Author(string name)
        {
            Name = name;
        }

        private Author()
        {
        }
    }
}
